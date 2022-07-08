using RapidPayService.Domain.Dtos;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Interfaces
{
    public interface IBalanceService
    {
        Task<BalanceDto> GetByCard(int cardId);
    }
}
