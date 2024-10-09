﻿using Ardalis.Result;
using BookStore.Users.Contracts;
using BookStore.Users.UseCases.User.GetById;
using MediatR;

namespace BookStore.Users.Integrations;

internal class UserDetailsByIdHandler :
  IRequestHandler<UserDetailsByIdQuery, Result<UserDetails>>
{
  private readonly IMediator _mediator;

  public UserDetailsByIdHandler(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task<Result<UserDetails>> Handle(UserDetailsByIdQuery request, CancellationToken cancellationToken)
  {
    var query = new GetUserByIdQuery(request.UserId);

    var result = await _mediator.Send(query);

    return result.Map(u => new UserDetails(u.UserId, u.EmailAddress));
  }
}
