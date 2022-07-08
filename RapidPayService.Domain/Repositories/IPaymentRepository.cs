using RapidPayService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> Insert(decimal totalAmount, int cardId);

        Task<IEnumerable<Payment>> GetByCard(int cardId);
    }
}
