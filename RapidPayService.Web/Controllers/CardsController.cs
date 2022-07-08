using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Interfaces;
using System.Threading.Tasks;

namespace RapidPayService.Web.Controllers
{
    public class CardsController : ApiControllerBase 
    {
        private readonly ICardService _cardService;
        private readonly IBalanceService _balanceService;
        public CardsController(ICardService cardService, IBalanceService balanceService)
        {
            _cardService = cardService;
            _balanceService = balanceService;
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<CardDto>> InsertCreditCard(CardDto card)
        {

            var error = await card.Validate();

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);

            }

            var newCard = await _cardService.Insert(card);
            return Ok(newCard);

        }

        [HttpGet("{cardId}/Balance")]
        [Authorize(Roles = "Owner,Viewer")]
        public async Task<ActionResult<BalanceDto>> GetCardBalance(int cardId)
        {
            var result = await _balanceService.GetByCard(cardId);
            return Ok(result);
        }
    }
}
