using RapidPayService.Domain.Interfaces;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Dtos
{
    public class CardDto : IValidableDto
    {

        public int CardId { get; set; }

        public string Number { get; set; }

        public Task<string> Validate()
        {
            var errorMsge = string.Empty;
            if (string.IsNullOrEmpty(Number) || Number.Length != 15)
            {
                errorMsge = "Invalid card number.It must be not empty and have 15 digits.";
            }
            return Task.FromResult(errorMsge);
        }

    }
}
