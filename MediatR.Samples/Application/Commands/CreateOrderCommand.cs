namespace MediatR.Samples.Application.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public CreateOrderCommand(string buyerId)
        {
            BuyerId = buyerId;
        }

        public string BuyerId { get; }
    }
}