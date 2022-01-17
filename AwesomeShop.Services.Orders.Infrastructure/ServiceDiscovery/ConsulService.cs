using System;
using System.Linq;
using System.Threading.Tasks;

using Consul;

namespace AwesomeShop.Services.Orders.Infrastructure.ServiceDiscovery
{
    public class ConsulService : IServiceDiscoveryService
    {
        private readonly IConsulClient _consulClient;

        public ConsulService(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task<Uri> GetServiceUri(string serviceName, string requestUrl)
        {
            var allRegisteredService = await _consulClient.Agent.Services();

            var registeredServices = allRegisteredService
                .Response?.Where(s => s.Value.Service.Equals(serviceName))
                .Select(s => s.Value)
                .ToList();

            var service = registeredServices.First();
            
            Console.WriteLine(service.Address);

            // localhost, Port: 5002, requestUrl api/customers/12321312
            var uri = $"http://{service.Address}:{service.Port}/{requestUrl}";

            return new Uri(uri);
        }
    }
}
