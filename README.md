Assumptions:
1) No validation is required for the body
2) for the simplicity of the wrapper I don't see the point of command/handler if required and we think things might go out of hand for this tiny microservice then a mediator package can be used to help add an abstraction layer.
3) I assumed that the errors coming from any system is a list of key value pair.
4) As the client used to get messages from queue is not yet decided I am leaving the serialization and mapping out of the implementation and this should be implemented when the technology is known and the correct library is picked. this can be done in SmsConfirmationService or we can leave it to the subscription handler. using automapper and .net core JsonSerializer which will be mapped to SendSmsCommand in my implementation.
5) I am also assuming that the queue client will able to handle retry policy if that is not the case then we need to implement a retry policy this is to return message back to the queues to be proccessed again until it is a dead letter
6) All configuration will be injected using the IConfiguration extension.
7) the retry policy for the httpclient will include retriable errors >= 500 and smaller than 600 and 409 reference https://www.envoyproxy.io/docs/envoy/latest/configuration/http/http_filters/router_filter#x-envoy-retry-on
8) From testing perspective, I see this exercise as a pure container/integration test which is out of the scope of this exercise due to the time limit, yet I think a couple of component tests to check that the flow of the SmsConfirmationService is behaving correctly should be in place. 

what is missing:
1) the concrete implementation of ISmsClient IEventRaiser
2) container/integration test
3) containerization 


Resilince Requirements:
1) we will implement a retry policy on the SmsClient using Polly also if it fails we will return message to the queue to be picked up again with a policy of 5 retries and then item can go to dead letter queue. if lots of items end up in the dead letter queue than we have an issue with the provider and we need to discuss what is causing that issue and what is there SLA and why it is failing.
2) we can have a local cache or a centralized cache with a reasonable TTL when the sms is sent. also, we can agree if possible with the third party client that the requests should be idempotent and a unique would be passed per message



