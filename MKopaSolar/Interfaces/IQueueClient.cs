using System;
using System.Threading;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Messages;

namespace MKopaSolar.Interfaces
{
    public interface IQueueClient<T> where  T : IMessage
    {
        Task Connect();
        Task RegisterMessageHandler(Func<T, CancellationToken, Task> handler);
        Task AbandonAsync(T message);
        Task CompleteAsync(T message);
    }
}
