using System.Threading.Tasks;

namespace RapidPayService.Domain.Interfaces
{
    public interface IValidableDto
    {
        Task<string> Validate();
    }
}
