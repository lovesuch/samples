using System.Reflection;
using Autofac;
using MediatR.Samples.Application.Commands;
using MediatR.Samples.Application.DomainEventHandlers.OrderStartedEvent;
using Module = Autofac.Module;

namespace MediatR.Samples.Infrastructure.AutofacModules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateOrderCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
            builder.RegisterAssemblyTypes(typeof(OrderStartedEventHandler)
                    .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));
        }
    }
}