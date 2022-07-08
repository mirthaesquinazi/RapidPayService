using Microsoft.EntityFrameworkCore;
using RapidPayService.Domain.Entities;
using RapidPayService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPayService.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RapidPayDbContext _context;

        public PaymentRepository(RapidPayDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> Insert(decimal totalAmount, int cardId)
        {
            var result = _context.Payments.Add(new Payment
            {
                Date = DateTime.Today,
                Amount = totalAmount,
                CardId = cardId
            });

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Payment>> GetByCard(int cardId)
        {
            List<Payment> result = await _context.Payments.Where(x => x.CardId == cardId).ToListAsync();

            return result;

        }
    }
}
