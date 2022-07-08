using RapidPayService.Domain.Dtos;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> Insert(CardDto cardDto);
        Task<CardDto> GetById(int cardId);
    }
}
