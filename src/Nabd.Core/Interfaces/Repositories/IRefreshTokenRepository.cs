using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nabd.Core.Entities.Identity;

namespace Nabd.Core.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(Guid userId);
        Task RevokeTokenAsync(string token, string? reason = null, string? revokedByIp = null);
        Task RevokeAllUserTokensAsync(Guid userId, string? reason = null);
        Task DeleteExpiredTokensAsync();
        Task<bool> IsTokenActiveAsync(string token);
    }
}