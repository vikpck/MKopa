using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;

namespace MKopaSolar.Interfaces
{
    public interface ISmsConfirmationService
    {
        Task SendAndRaise(SendSmsCommand body);
    }
}
