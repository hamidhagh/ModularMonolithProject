﻿using BookStore.EmailSending.Contracts;
using BookStore.Users.Contracts;
using MediatR;

namespace BookStore.Orders.Domain;

internal class SendConfirmationEmailOrderCreatedEventHandler :
  INotificationHandler<OrderCreatedEvent>
{
  private readonly IMediator _mediator;

  public SendConfirmationEmailOrderCreatedEventHandler(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task Handle(OrderCreatedEvent notification, 
    CancellationToken ct)
  {
    var userByIdQuery = new UserDetailsByIdQuery(notification.Order.UserId);

    var result = await _mediator.Send(userByIdQuery);

    if(!result.IsSuccess)
    {
      // TODO: Log the error
      return;
    }
    string userEmail = result.Value.EmailAddress;

    var command = new SendEmailCommand()
    {
      To = userEmail,
      From = "noreply@test.com",
      Subject = "Your BookStore Purchase",
      Body = $"You bought {notification.Order.OrderItems.Count} items."
    };
    Guid emailId = await _mediator.Send(command);

    // TODO: Do something with emailId

  }
}

