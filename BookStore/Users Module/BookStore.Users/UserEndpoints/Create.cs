﻿using Ardalis.Result.AspNetCore;
using BookStore.Users.UseCases.User.Create;
using FastEndpoints;
using MediatR;

namespace BookStore.Users.UserEndpoints;

internal class Create : Endpoint<CreateUserRequest>
{
  private readonly IMediator _mediator;

  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateUserRequest request,
    CancellationToken cancellationToken)
  {
    var command = new CreateUserCommand(request.Email, request.Password);

    var result = await _mediator.Send(command);

    if (!result.IsSuccess)
    {
      await SendResultAsync(result.ToMinimalApiResult());
      return;
    }
    await SendOkAsync();
  }
}
