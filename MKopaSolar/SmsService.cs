using System.Linq;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Events;
using MKopaSolar.Contracts.Requests;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class SmsService : ISmsService
    {
        private ISmsClient _smsClient;
        private IEventRaiser<IEvent> _eventPublisher;
        private ILogger _logger;

        public SmsService(
            ISmsClient smsClient, 
            IEventRaiser<IEvent> eventPublisher,
            ILogger logger)
        {
            _smsClient = smsClient;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }
        public async Task SendAndRaise(SendSmsRequest sensSmsRequest)
        {
            var clientErrors = await _smsClient.Send(sensSmsRequest);

            if (clientErrors != null && clientErrors.Any())
            {
                _logger.LogError($"Failed To send phone number {sensSmsRequest.Body.PhoneNumber} and message {sensSmsRequest.Body.SmsText}");
            }

            var eventPublisherError = await _eventPublisher.Raise(new SmsSentEvent());

            if (eventPublisherError != null && eventPublisherError.Any())
            {
                _logger.LogError($"Failed To raise Sms Sent Event to phone number {sensSmsRequest.Body.PhoneNumber} and message {sensSmsRequest.Body.SmsText}");
            }
        }
    }
}
