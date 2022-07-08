using RapidPayService.Domain.Entities;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Card> Insert(Card card);

        Task<Card> GetById(int cardId);
    }
}
