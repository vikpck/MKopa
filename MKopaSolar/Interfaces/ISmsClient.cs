using System.Collections.Generic;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;

namespace MKopaSolar.Interfaces
{
    public interface ISmsClient
    {
        Task<Dictionary<string,string>> Send(SendSmsCommand body);
    }
}
