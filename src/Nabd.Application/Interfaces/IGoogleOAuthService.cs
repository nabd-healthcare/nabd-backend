using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Application.DTOs.Responses.Auth;

namespace Nabd.Application.Interfaces
{
    public interface IGoogleOAuthService
    {
        Task<GoogleUserInfo?> ValidateGoogleTokenAsync(string idToken);
    }
}
