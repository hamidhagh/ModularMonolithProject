﻿using System.Security.Claims;
using Ardalis.Result;
using BookStore.Users.UseCases.Cart.ListItems;
using FastEndpoints;
using MediatR;

namespace BookStore.Users.CartEndpoints;

internal class ListCartItems : EndpointWithoutRequest<CartResponse>
{
  private readonly IMediator _mediator;

  public ListCartItems(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/cart");
    Claims("EmailAddress");
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var emailAddress = User.FindFirstValue("EmailAddress");

    var query = new ListCartItemsQuery(emailAddress!);

    var result = await _mediator.Send(query);

    if (result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else
    {
      var response = new CartResponse()
      {
        CartItems = result.Value
      };
      await SendAsync(response);
    }
  }
}
