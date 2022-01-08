using System;
using System.Threading;
using System.Threading.Tasks;

using AwesomeShop.Services.Orders.Core.Repositories;

using MediatR;

namespace AwesomeShop.Services.Orders.Application.Commands.Handlers
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>

    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}
