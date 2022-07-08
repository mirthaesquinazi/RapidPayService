using RapidPayService.Domain.Dtos;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDto> Insert(PaymentDto data);
    }
}
