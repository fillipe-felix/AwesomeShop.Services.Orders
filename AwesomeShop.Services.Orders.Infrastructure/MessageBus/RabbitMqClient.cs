using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using RabbitMQ.Client;

namespace AwesomeShop.Services.Orders.Infrastructure.MessageBus
{
    public class RabbitMqClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        
        public RabbitMqClient(ProducerConnection producerConnection)
        {
            _connection = producerConnection.Connection;
        }

        public void Publish(object message, string routingKey, string exchange)
        {
            //Cria um canal no rabbitMq
            var channel = _connection.CreateModel();

            // Configuração para na hora de serializa igonar camalCase nas propriedades
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            
            //Serializa o objeto e deixa ele em um array de bytes
            var payload = JsonConvert.SerializeObject(message, settings);
            var body = Encoding.UTF8.GetBytes(payload);
            
            //cria uma exchange
            channel.ExchangeDeclare(exchange, "topic", true);
            
            //Publica a mensagem
            channel.BasicPublish(exchange, routingKey, null, body);
        }
    }
}
