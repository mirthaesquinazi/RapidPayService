using System;

namespace RapidPayService.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CardId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
