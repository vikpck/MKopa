using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MKopaSolar.IoC;

namespace MKopaSolar
{
    public static class Program
    {
        public static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddClients()
                .BuildServiceProvider();

            //Message need to be known so this can be injected here and then below two lines can be uncommented
            //var smsSubscriber = serviceProvider.GetService<ISmsSubscription<Message>>();
            //smsSubscriber.Run();
        }
    }
}
