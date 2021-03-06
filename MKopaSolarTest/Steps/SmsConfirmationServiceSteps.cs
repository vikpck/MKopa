﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MKopaSolar;
using MKopaSolar.Contracts.Commands;
using MKopaSolar.Contracts.Events;
using MKopaSolar.Contracts.Requests;
using MKopaSolar.Interfaces;
using NSubstitute;
using TechTalk.SpecFlow;

namespace MKopaSolarTest.Steps
{
    [Binding]
    public class SmsServiceSteps
    {
        private ISmsService _SmsService;
        private ISmsClient _smsClient;
        private IEventRaiser<IEvent> _eventRaiser;
        private SendSmsRequest _sendSmsRequest;
        private readonly Fixture _fixture = new Fixture();
        private Dictionary<string, string> _erros;
        private string _exceptionResult;
        private ILogger _logger;

        public SmsServiceSteps()
        {
            _smsClient = Substitute.For<ISmsClient>();
            _eventRaiser = Substitute.For<IEventRaiser<IEvent>>();
            _logger = Substitute.For<ILogger>();
            _SmsService = new SmsService(_smsClient, _eventRaiser, _logger);
        }

        [Given(@"we have a command to send")]
        public void GivenWeHaveACommandToSend()
        {
            _sendSmsRequest = _fixture.Create<SendSmsRequest>();
        }

        [Given(@"client is returning an error")]
        public void GivenClientIsReturningAnError()
        {
            _erros = _fixture.Create<Dictionary<string, string>>();
            _smsClient.Send(_sendSmsRequest).Returns(Task.FromResult(_erros));
        }

        [Given(@"client is returning no errors")]
        public void GivenClientIsReturningNoErrors()
        {
            _smsClient.Send(_sendSmsRequest).Returns(Task.FromResult(new Dictionary<string, string>() { }));
        }

        [Given(@"EventPublisher is returning no errors")]
        public void GivenEventPublisherIsReturningNoErrors()
        {
            _eventRaiser.Raise(Arg.Any<SmsSentEvent>()).Returns(Task.FromResult(new Dictionary<string, string>() { }));
        }

        [Given(@"eventpublisher is returning an error")]
        public void GivenEventpublisherIsReturningAnError()
        {
            _erros = _fixture.Create<Dictionary<string, string>>();
            _eventRaiser.Raise(Arg.Any<SmsSentEvent>()).Returns(Task.FromResult(_erros));
        }

        [When(@"SmsService try to send command")]
        public async void WhenSmsServiceTryToSendCommand()
        {
            await _SmsService.SendAndRaise(_sendSmsRequest);
        }

        [When(@"SmsService try to raise event")]
        public async void WhenSmsServiceTryToRaiseEvent()
        {
            await _SmsService.SendAndRaise(_sendSmsRequest);
        }

        [Then(@"the exception '(.*)' should be logged")]
        public void ThenTheExceptionShouldBeThrown(string error)
        {
            error = string.Format(error, _sendSmsRequest.Body.PhoneNumber, _sendSmsRequest.Body.SmsText);
            _logger.Received().LogError(error);
        }

        [Then(@"no exception should be Thrown")]
        public void ThenNoExceptionShouldBeThrown()
        {
            _exceptionResult.Should().BeNull();
        }

        [Then(@"eventpublisher and client is called")]
        public void ThenEventpublisherAndClientIsCalled()
        {
            _smsClient.Received().Send(_sendSmsRequest);
            _eventRaiser.Received().Raise(Arg.Any<SmsSentEvent>());
        }

    }
}
