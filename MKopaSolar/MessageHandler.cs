using System.Threading.Tasks;
using AutoMapper;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Requests;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class MessageHandler : IMessageHandler
    {
        private ISmsService _smsService;
        private ILogger _logger;
        private IMapper _mapper;

        public MessageHandler(ISerializer serializer,
            ISmsService smsService, ILogger logger, IMapper mapper)
        {
            _smsService = smsService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Handle(SendSmsCommand body)
        {
            await _smsService.SendAndRaise(_mapper.Map<SendSmsRequest>(body));
        }
    }
}
