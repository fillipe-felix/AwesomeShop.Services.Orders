using System.Threading;
using System.Threading.Tasks;

using AwesomeShop.Services.Orders.Application.Dtos.ViewModels;
using AwesomeShop.Services.Orders.Core.Repositories;

using MediatR;

namespace AwesomeShop.Services.Orders.Application.Queries.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var orderViewModel = OrderViewModel.FromEntity(order);
            
            return orderViewModel;
        }
    }
}
