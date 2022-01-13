using System;
using System.Threading;
using System.Threading.Tasks;

using AwesomeShop.Services.Orders.Core.Repositories;
using AwesomeShop.Services.Orders.Infrastructure;
using AwesomeShop.Services.Orders.Infrastructure.MessageBus;

using MediatR;

namespace AwesomeShop.Services.Orders.Application.Commands.Handlers
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusClient _messageBus;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IMessageBusClient messageBus)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            await _orderRepository.AddAsync(order);

            foreach (var @event in order.Events)
            {
                //OrderCreated = order-created
                var rountingKey = @event.GetType().Name.ToDashCase();
                _messageBus.Publish(@event, rountingKey, "order-service");
            }

            return order.Id;
        }
    }
}
