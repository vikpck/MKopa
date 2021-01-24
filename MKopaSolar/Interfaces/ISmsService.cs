using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;

namespace MKopaSolar.Interfaces
{
    public interface ISmsService
    {
        Task SendAndRaise(SendSmsCommand body);
    }
}
