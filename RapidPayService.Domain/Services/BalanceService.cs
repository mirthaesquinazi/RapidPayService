using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Interfaces;
using RapidPayService.Domain.Repositories;
using RapidPayService.Domain.ResponseExceptions;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ICardService _cardService;
        private readonly IPaymentRepository _paymentRepository;

        public BalanceService(IPaymentRepository balanceRepository, IUniversalFeesExchangeService ufeService, ICardService cardService)
        {
            _paymentRepository = balanceRepository;
            _cardService = cardService;
        }

        public async Task<BalanceDto> GetByCard(int cardId)
        {
            var card = await _cardService.GetById(cardId);

            if (card == null)
            {
                throw new NotFoundException()
                {
                    ErrorMessage = "Card does not exists",
                };
            }

            var paymentLists = await _paymentRepository.GetByCard(card.CardId);

            var total = paymentLists.Sum(p => p.Amount);

            var result = new BalanceDto
            {
                Amount = total,
            };

            return result;
        }
    }
}
