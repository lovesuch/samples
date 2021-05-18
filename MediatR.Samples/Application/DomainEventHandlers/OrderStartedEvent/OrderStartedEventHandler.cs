using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Samples.Domain.Events;

namespace MediatR.Samples.Application.DomainEventHandlers.OrderStartedEvent
{
    public class OrderStartedEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification);
            return Task.CompletedTask;
        }
    }
}