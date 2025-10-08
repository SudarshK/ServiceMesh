using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ServiceMesh.Services.EmailAPI.Model.DTO;
using ServiceMesh.Services.EmailAPI.Services;
using System.Text;

namespace ServiceMesh.Services.EmailAPI.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private readonly string _serviceBusConnectionString;
        private readonly string _emailCartQueue;
        //private readonly string _subscriptionName;
        private ServiceBusProcessor _emailCartProcessor;
        public AzureServiceBusConsumer(IConfiguration configuration, EmailService emailService)
        {
            _emailService = emailService;
            _configuration = configuration;
            _serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            _emailCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EmailShoppingCartQueue");
            // _subscriptionName = _configuration.GetValue<string>("AzureServiceBus:SubscriptionName");
            var client = new ServiceBusClient(_serviceBusConnectionString);
            _emailCartProcessor = client.CreateProcessor(_emailCartQueue);
        }

        public async Task Start()
        {
            _emailCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
            _emailCartProcessor.ProcessErrorAsync += ErrorHandler;
            await _emailCartProcessor.StartProcessingAsync();
        }

        private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            CartDto objMessage = JsonConvert.DeserializeObject<CartDto>(body);
            try
            {
                await _emailService.EmailCartAndLog(objMessage);
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
               throw new Exception($"Error processing message: {ex.Message}", ex);
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }


        public async Task Stop()
        {
            await _emailCartProcessor.StopProcessingAsync();
            await _emailCartProcessor.DisposeAsync();
        }
    }
}
