﻿using MediatR;

namespace BookStore.Orders.Contracts;

public class OrderCreatedIntegrationEvent : INotification
{
  public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.Now;
  public OrderDetailsDto OrderDetails { get; private set; }

  public OrderCreatedIntegrationEvent(OrderDetailsDto orderDetailsDto)
  {
    OrderDetails = orderDetailsDto;
  }
}
