using RapidPayService.Domain.Interfaces;
using System;
using System.Globalization;

namespace RapidPayService.Domain.Services
{
    public class UniversalFeesExchangeService : IUniversalFeesExchangeService
    {
        private decimal lastFee = 1;

        public decimal CalculateFee()
        {
            var random = new Random();
            var next = random.Next(0, 2);

            var decimalPart = next == 2 ? 0 : random.Next(0, 99);

            var randomValue = Convert.ToDecimal($"{next}{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}{decimalPart}");
           
            var finalFee = randomValue * lastFee;
            
            lastFee = randomValue;

            return finalFee;

        }
    }
}
