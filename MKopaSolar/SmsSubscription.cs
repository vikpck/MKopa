﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Messages;
using MKopaSolar.Interfaces;

namespace MKopaSolar
{
    public class SmsSubscription : ISmsSubscription
    {
        private IQueueClient<IMessage> _queueCient;
        private ILogger _logger;
        private ISmsConfirmationService _smsConfirmationService;
        private ISerializer _serialiser;

        public SmsSubscription(IQueueClient<IMessage> queueCient,
            ILogger logger,
            ISmsConfirmationService smsConfirmationService,
            ISerializer serialiser)
        {
            _queueCient = queueCient;
            _logger = logger;
            _smsConfirmationService = smsConfirmationService;
            _serialiser = serialiser;
            _queueCient.Connect();
        }

        public void Run()
        {
            try
            {
                 _queueCient.RegisterMessageHandler(HandleMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start connection with queue");
                throw;
            }
        }


        private async Task HandleMessage(IMessage message, CancellationToken ct)
        {
            try
            {
                await _smsConfirmationService.SendAndRaise(_serialiser.Deserialize<SendSmsCommand>(message.Body));
                await CompleteMessage(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send and raise message command {@message}", message);
                await AbandonMessage(message);
                throw;
            }
        }

        private async Task AbandonMessage(IMessage message)
        {
            try
            {
                await _queueCient.AbandonAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot abandon message {@MessageID}", message);
                throw;
            }
        }

        private async Task CompleteMessage(IMessage message)
        {
            try
            {
                await _queueCient.CompleteAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Cannot completeMessage message {@MessageID}", message);
                throw;
            }
        }

    }
}