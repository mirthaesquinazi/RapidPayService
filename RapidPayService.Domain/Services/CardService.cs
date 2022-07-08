using Mapster;
using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Entities;
using RapidPayService.Domain.Interfaces;
using RapidPayService.Domain.Repositories;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardDto> Insert(CardDto cardDto)
        {
            Card card = cardDto.Adapt<Card>();

            var newCard = await _cardRepository.Insert(card);

            return newCard.Adapt<CardDto>();

        }

        public async Task<CardDto> GetById(int cardId)
        {
            var card = await _cardRepository.GetById(cardId);

            return card.Adapt<CardDto>();
        }

    }
}
