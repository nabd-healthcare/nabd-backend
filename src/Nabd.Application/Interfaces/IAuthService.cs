using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Application.DTOs.Common.Base;
using Nabd.Application.DTOs.Requests.Auth;
using Nabd.Application.DTOs.Responses.Auth;

namespace Nabd.Application.Interfaces
{
    public interface IAuthService
    {
        #region Registration
        Task<ApiResponse<AuthResponseDto>> RegisterPatientAsync(RegisterPatientRequest dto, string? ipAddress = null);
        Task<ApiResponse<AuthResponseDto>> RegisterDoctorAsync(RegisterDoctorRequest dto, string? ipAddress = null);
        Task<ApiResponse<AuthResponseDto>> RegisterVerifierAsync(RegisterVerifierRequest dto, string? ipAddress = null);
        #endregion

        #region Email Verification
        Task<ApiResponse<AuthResponseDto>> VerifyEmailAsync(VerifyEmailRequest dto, string? ipAddress = null);
        Task<ApiResponse<bool>> ResendVerificationOtpAsync(ResendOtpRequest dto);
        #endregion

        #region Login
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequest dto, string? ipAddress = null);
        #endregion

        #region Google OAuth
        Task<ApiResponse<AuthResponseDto>> GoogleLoginAsync(GoogleLoginRequest dto, string? ipAddress = null);
        #endregion

        #region Password Management
        Task<ApiResponse<bool>> ForgotPasswordAsync(ForgotPasswordRequest dto);
        Task<ApiResponse<bool>> VerifyResetOtpAndResetPasswordAsync(VerifyResetOtpRequest dto);
        Task<ApiResponse<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequest dto);
        #endregion

        #region
        Task<ApiResponse<AuthResponseDto>> RefreshTokenAsync(RefreshTokenRequest dto, string? ipAddress = null);
        Task<ApiResponse<bool>> LogoutAsync(string refreshToken, string? ipAddress = null);
        #endregion

        #region User Info
        Task<ApiResponse<UserInfoDto>> GetCurrentUserAsync(Guid userId);
        #endregion

        #region Account Management
        Task<ApiResponse<bool>> DeleteAccountAsync(Guid userId, DeleteAccountRequest dto);
        Task<ApiResponse<bool>> DebugDeleteAccountByEmailAsync(DeleteAccountRequest dto);
        #endregion
    }
}