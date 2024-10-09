using Ardalis.Result;
using MediatR;

namespace BookStore.Users.UseCases.User.GetById;
internal record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDTO>>;

