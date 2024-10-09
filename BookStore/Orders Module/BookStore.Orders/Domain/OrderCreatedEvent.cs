using BookStore.SharedKernel;

namespace BookStore.Orders.Domain;

internal class OrderCreatedEvent : DomainEventBase
{
  public OrderCreatedEvent(Order order)
  {
    Order = order;
  }

  public Order Order { get; }
}
