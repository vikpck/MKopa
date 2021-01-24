using System;
using System.Linq;
using System.Threading.Tasks;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Events;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class SmsService : ISmsService
    {
        private ISmsClient _smsClient;
        private IEventRaiser<IEvent> _eventPublisher;
        private ILogger _logger;

        public SmsService(ISmsClient smsClient, IEventRaiser<IEvent> eventPublisher, ILogger logger)
        {
            _smsClient = smsClient;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }
        public async Task SendAndRaise(SendSmsCommand body)
        {

            var clientErrors = await _smsClient.Send(body);

            if (clientErrors != null && clientErrors.Any())
            {
                _logger.LogError($"Failed To send phone number {body.PhoneNumber} and message {body.SmsText}");
            }

            var eventPublisherError = await _eventPublisher.Raise(new SmsSentEvent());

            if (eventPublisherError != null && eventPublisherError.Any())
            {
                _logger.LogError($"Failed To raise Sms Sent Event to phone number {body.PhoneNumber} and message {body.SmsText}");
            }
        }
    }
}
