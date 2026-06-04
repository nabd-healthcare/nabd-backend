using FluentValidation;
using Microsoft.OpenApi.Models;
using Nabd.API.Services;
using Nabd.Application.AI.Diagnosis;
using Nabd.Application.Interfaces;
using Nabd.Application.Services;
using Nabd.Application.Services.Auth;
using Nabd.Application.Services.Email;
using Nabd.Application.Services.Token;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Core.Interfaces.UnitOfWork;
using Nabd.Infrastructure.Repositories.
Doctors;
using Nabd.Infrastructure.Repositories.Medical;
using Nabd.Infrastructure.Repositories.Patients;
using Nabd.Infrastructure.UnitOfWork;
using Nabd.Shared.Configurations;

namespace Nabd.API.Extensions
{
    public static class ServiceExtensions
    {
        #region Register all application configuration settings
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<OAuthSettings>(configuration.GetSection("OAuthSettings"));
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.Configure<Nabd.Core.Settings.PaymobSettings>(configuration.GetSection("Paymob"));
            services.Configure<Nabd.Core.Settings.FrontendSettings>(configuration.GetSection("FrontendSettings"));

            return services;
        }
        #endregion

        #region Register all repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorConsultationRepository, DoctorConsultationRepository>();
            services.AddScoped<IConsultationRecordRepository, ConsultationRecordRepository>();

            return services;
        }
        #endregion

        #region Register Unit of Work pattern
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        #endregion

        #region Register all application services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Authentication & Authorization Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IGoogleOAuthService, GoogleOAuthService>();

            // Email Service
            services.AddScoped<IEmailService, EmailService>();

            // File Upload Service
            // File Upload Service (Local for Development)
            services.AddScoped<IFileUploadService, LocalFileUploadService>();

            // Business Services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IVerifierService, VerifierService>();

            // Doctor Profile Services
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IDoctorServicePricingService, DoctorServicePricingService>();
            services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();


            // Prescription Service
            services.AddScoped<IPrescriptionService, PrescriptionService>();

            // Session Management Services
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IDocumentationService, DocumentationService>();


            // AI Models (Singleton - for persistent Python process)
            services.AddSingleton<MainDiagnosisLocalModel>();
            services.AddSingleton<IMainDiagnosisModel>(sp => sp.GetRequiredService<MainDiagnosisLocalModel>());



            // Simple Symptom Parser
            services.AddScoped<IArabicSymptomParser, Nabd.Application.Services.AI.SimpleSymptomParser>();

            // Diagnosis Service
            services.AddScoped<IDiagnosisService, DiagnosisService>();

            // Payment Services
            services.AddHttpClient<IPaymobService, PaymobService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentProcessingService, PaymentProcessingService>();

            // Review Services
            services.AddScoped<IDoctorReviewService, DoctorReviewService>();

            // Notification Services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationHubService, NotificationHubService>();

            return services;
        }
        #endregion

        #region Register FluentValidation validators
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();

            return services;
        }
        #endregion

        #region Register AutoMapper profiles
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Nabd.Application.Mappers.MappingProfile));

            return services;
        }
        #endregion

        #region Configure Swagger/OpenAPI documentation
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nabd Healthcare API",
                    Version = "v1",
                    Description = "Healthcare Management System API",
                });

                // Custom Schema ID to avoid conflicts
                options.CustomSchemaIds(type => type.FullName?.Replace("+", "."));

                // Add JWT Authentication to Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid JWT token.\n\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...\""
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
        #endregion
    }
}
