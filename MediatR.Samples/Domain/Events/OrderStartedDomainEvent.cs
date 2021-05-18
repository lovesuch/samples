namespace MediatR.Samples.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public OrderStartedDomainEvent(int userId, string orderId)
        {
            UserId = userId;
            OrderId = orderId;
        }

        public int UserId { get; }

        public string OrderId { get; }
    }
}