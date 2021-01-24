using System;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class MessageHandler : IMessageHandler
    {
        private ISerializer _serializer;
        private ISmsService _smsService;
        private ILogger _logger;

        public MessageHandler(ISerializer serializer,
            ISmsService smsService, ILogger logger)
        {
            _serializer = serializer;
            _smsService = smsService;
            _logger = logger;
        }

        public async Task Handle(byte[] body)
        {
            try
            {
                await _smsService.SendAndRaise(_serializer.Deserialize<SendSmsCommand>(body));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Handling Message Failed {@body}", body);
                throw;
            }
        }
    }
}
