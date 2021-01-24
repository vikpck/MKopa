using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class MessageHandler : IMessageHandler
    {
        private ISerializer _serializer;
        private ISmsService _confirmationService;
        public Task Handle(string body)
        {
            throw new NotImplementedException();
        }
    }
}
