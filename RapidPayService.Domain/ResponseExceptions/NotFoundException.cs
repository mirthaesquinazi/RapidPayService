using System;

namespace RapidPayService.Domain.ResponseExceptions
{
    public class NotFoundException : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
