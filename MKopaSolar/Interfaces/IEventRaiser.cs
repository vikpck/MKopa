using System.Collections.Generic;
using System.Threading.Tasks;

namespace MKopaSolar.Interfaces
{
    public interface IEventRaiser<T> where T : IEvent
    {
        Task<Dictionary<string,string>> Raise(T body);
    }
}
