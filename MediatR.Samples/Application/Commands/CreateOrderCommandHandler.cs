using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Samples.Domain.Events;

namespace MediatR.Samples.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new OrderStartedDomainEvent(Convert.ToInt32(request.BuyerId), "B21"),
                cancellationToken);

            return true;
        }
    }
}