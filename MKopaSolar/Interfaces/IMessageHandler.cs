using System.Threading.Tasks;

namespace MKopaSolar.Interfaces
{
    public interface IMessageHandler
    {
        Task Handle(byte[] body);
    }
}
