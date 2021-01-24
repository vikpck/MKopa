using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class EventRaiser<T> : IEventRaiser<T> where T : IEvent
    {
        public async Task<Dictionary<string, string>> Raise(T body)
        {
            throw new NotImplementedException();
        }
    }
}
