using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nabd.Core.Entities.System;
using Nabd.Core.Enums;
using Nabd.Infrastructure.Data;
using Nabd.Shared.Configurations;

namespace Nabd.Application.Interfaces
{
    public interface IOtpService
    {
        Task<string> GenerateAndStoreOtpAsync(Guid userId, string email, VerificationTypes verificationType, string? ipAddress = null);
        Task<bool> ValidateOtpAsync(string email, string otpCode, VerificationTypes verificationType);
        Task<bool> CanResendOtpAsync(string email);
        Task InvalidateAllOtpsAsync(Guid userId, VerificationTypes verificationType);
        string GenerateSecureOtp(int length);
    }
}