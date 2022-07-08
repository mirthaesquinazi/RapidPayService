using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Interfaces;
using RapidPayService.Domain.Repositories;
using RapidPayService.Domain.ResponseExceptions;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUniversalFeesExchangeService _feeService;
        private readonly ICardService _cardService;
        private readonly IPaymentRepository _balanceRepository;

        public PaymentService(IPaymentRepository balanceRepository, IUniversalFeesExchangeService ufeService, ICardService cardService)
        {
            _balanceRepository = balanceRepository;
            _feeService = ufeService;
            _cardService = cardService;
        }

        public async Task<PaymentDto> Insert(PaymentDto data)
        {
            var card = await _cardService.GetById(data.CardId);
            if (card == null)
            {
                throw new BadRequestException()
                {
                    ErrorMessage = "Card does not exist."
                };
            }

            var totalAmount = data.Amount + _feeService.CalculateFee();

            var balance = await _balanceRepository.Insert(totalAmount, data.CardId);

            var newPaymentDto = new PaymentDto
            {
                Amount = balance.Amount,
                CardId = balance.CardId
            };

            return newPaymentDto;
        }

        public async Task<BalanceDto> GetCardBalance(int cardId)
        {
            var card = await _cardService.GetById(cardId);

            if (card == null)
            {
                throw new NotFoundException()
                {
                    ErrorMessage = "Card does not exists",
                };
            }

            var paymentLists = await _balanceRepository.GetByCard(card.CardId);

            var payments = paymentLists.Select(c => new PaymentDto
            {
                Amount = c.Amount,
                CardId = c.CardId
            }).ToList();

            var total = payments.Sum(p => p.Amount);

            var result = new BalanceDto
            {
                Amount = total,
            };

            return result;
        }
    }
}
