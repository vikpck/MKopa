using System.Threading.Tasks;
using MKopaSolar.Contracts.Requests;

namespace MKopaSolar.Interfaces
{
    public interface ISmsService
    {
        Task SendAndRaise(SendSmsRequest body);
    }
}
