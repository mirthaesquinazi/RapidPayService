using Microsoft.EntityFrameworkCore;
using RapidPayService.Domain.Entities;
using RapidPayService.Domain.Repositories;
using RapidPayService.Domain.ResponseExceptions;
using System.Threading.Tasks;

namespace RapidPayService.Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly RapidPayDbContext _context;

        public CardRepository(RapidPayDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Insert(Card card)
        {
            var existingCard = await GetById(card.CardId);

            if (existingCard != null)
            {
                throw new BadRequestException()
                {
                    ErrorMessage = "Card already exists."
                };
            }

            var result = _context.Cards.Add(new Card
            {
                Number = card.Number
            });

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Card> GetById(int cardId)
        {
            var result = await _context.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);

            return result;
        }

    }
}
