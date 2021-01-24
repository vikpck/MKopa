using System.Collections.Generic;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Requests;

namespace MKopaSolar.Interfaces
{
    public interface ISmsClient
    {
        Task<Dictionary<string,string>> Send(SendSmsRequest request);
    }
}
