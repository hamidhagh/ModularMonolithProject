using Ardalis.Result;
using MediatR;

namespace BookStore.Users.Contracts;

public record UserDetailsByIdQuery(Guid UserId) :
  IRequest<Result<UserDetails>>;
