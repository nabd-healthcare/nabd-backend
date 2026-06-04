using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Nabd.Application.DTOs.Common.FileUpload;
using Nabd.Application.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nabd.API.Services
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<LocalFileUploadService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalFileUploadService(IWebHostEnvironment environment, ILogger<LocalFileUploadService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<FileUploadDto> UploadProfileImageAsync(IFormFile file, string userId)
        {
            return await UploadFileAsync(file, "profiles", userId);
        }

        public async Task<FileUploadDto> UploadDocumentAsync(IFormFile file, string userId)
        {
            return await UploadFileAsync(file, "documents", userId);
        }

        public async Task<FileUploadDto> UploadVideoAsync(IFormFile file, string userId)
        {
             return await UploadFileAsync(file, "videos", userId);
        }

        public async Task<FileUploadDto> UploadClinicImageAsync(IFormFile file, string doctorId)
        {
             return await UploadFileAsync(file, "clinics", doctorId);
        }

        public Task<bool> DeleteFileAsync(string fileUrl)
        {
             try
            {
                // Basic cleanup logic - extraction from URL
                if (string.IsNullOrEmpty(fileUrl)) return Task.FromResult(false);

                // Assuming URL format: scheme://host/uploads/folder/filename
                var uri = new Uri(fileUrl);
                var path = uri.AbsolutePath.TrimStart('/'); // uploads/folder/filename
                
                // Only allow deleting from uploads folder
                if (!path.StartsWith("uploads", StringComparison.OrdinalIgnoreCase)) return Task.FromResult(false);

                // Ensure WebRootPath is not null
                if (string.IsNullOrEmpty(_environment.WebRootPath))
                {
                    _logger.LogWarning("WebRootPath is not configured. Cannot delete file.");
                    return Task.FromResult(false);
                }

                var fullPath = Path.Combine(_environment.WebRootPath, path);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    _logger.LogInformation($"File deleted: {fullPath}");
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error deleting file");
                return Task.FromResult(false);
            }
        }

        private async Task<FileUploadDto> UploadFileAsync(IFormFile file, string folderName, string identifier)
        {
             if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            // Ensure WebRootPath is not null
            if (string.IsNullOrEmpty(_environment.WebRootPath))
            {
                 // Create wwwroot if it doesn't exist in development
                 var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                 if(!Directory.Exists(wwwroot)) Directory.CreateDirectory(wwwroot);
                 _environment.WebRootPath = wwwroot;
            }

            // folder path relative to wwwroot
            var relativeFolderPath = Path.Combine("uploads", folderName);
            var uploadsFolder = Path.Combine(_environment.WebRootPath, relativeFolderPath);
            
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // Generate unique filename
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{identifier}_{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Generate URL
            string url;
            var relativeUrl = Path.Combine(relativeFolderPath, fileName).Replace("\\", "/");

            if (_httpContextAccessor.HttpContext != null)
            {
                var request = _httpContextAccessor.HttpContext.Request;
                var schema = request.Scheme;
                var host = request.Host.Value;
                url = $"{schema}://{host}/{relativeUrl}";
            }
            else 
            {
                 url = $"http://localhost:5117/{relativeUrl}";
            }

            return new FileUploadDto
            {
                FileName = fileName,
                FileUrl = url,
                FileSize = file.Length,
                ContentType = file.ContentType
            };
        }
    }
}
