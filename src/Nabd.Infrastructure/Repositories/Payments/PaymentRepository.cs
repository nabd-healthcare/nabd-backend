using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.External.Payments;
using Nabd.Core.Enums.Payment;
using Nabd.Core.Interfaces.Repositories;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Repositories.Payments
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(NabdDbContext context) : base(context)
        {
        }

        public async Task<Payment?> GetPaymentWithTransactionsAsync(Guid paymentId)
        {
            return await _context.Set<Payment>()
                .Include(p => p.Transactions)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(Guid userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Set<Payment>()
                .Include(p => p.Transactions)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByOrderAsync(string orderType, Guid orderId)
        {
            return await _context.Set<Payment>()
                .Include(p => p.Transactions)
                .Where(p => p.OrderType == orderType && p.OrderId == orderId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByProviderTransactionIdAsync(string providerTransactionId)
        {
            return await _context.Set<Payment>()
                .Include(p => p.Transactions)
                .FirstOrDefaultAsync(p => p.ProviderTransactionId == providerTransactionId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(PaymentStatus status, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Set<Payment>()
                .Include(p => p.Transactions)
                .Where(p => p.Status == status)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPendingPaymentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await GetPaymentsByStatusAsync(PaymentStatus.Pending, pageNumber, pageSize);
        }

        public async Task<decimal> GetTotalRevenueAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Set<Payment>()
                .Where(p => p.Status == PaymentStatus.Completed);

            if (startDate.HasValue)
                query = query.Where(p => p.CompletedAt >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.CompletedAt <= endDate.Value);

            return await query.SumAsync(p => p.Amount - (p.RefundedAmount ?? 0));
        }

        public async Task<int> GetPaymentCountByStatusAsync(PaymentStatus status)
        {
            return await _context.Set<Payment>()
                .CountAsync(p => p.Status == status);
        }
    }
}
