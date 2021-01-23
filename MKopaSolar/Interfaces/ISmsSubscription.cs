using System.Threading.Tasks;

namespace MKopaSolar.Interfaces
{
    public interface ISmsSubscription<T>
    {
        void Run();
        Task HandleMessage(T message);
        Task AbandonMessage(T message);
        Task CompleteMessage(T message);
    }
}
