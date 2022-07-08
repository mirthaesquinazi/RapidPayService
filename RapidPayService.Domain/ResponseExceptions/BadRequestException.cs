using System;

namespace RapidPayService.Domain.ResponseExceptions
{
    public class BadRequestException : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
