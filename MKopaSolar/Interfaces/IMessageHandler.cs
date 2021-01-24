using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;

namespace MKopaSolar.Interfaces
{
    public interface IMessageHandler
    {
        Task Handle(SendSmsCommand body);
    }
}
