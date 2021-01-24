using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Messages;

namespace MKopaSolar.Interfaces
{
    public interface IMapMessageToCommand
    {
        SendSmsCommand Map(IMessage message);
    }
}
