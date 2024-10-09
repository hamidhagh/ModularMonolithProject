using Ardalis.Result;
using MediatR;

namespace BookStore.Users.UseCases.User.Create;
internal record CreateUserCommand(string Email, string Password) : IRequest<Result>;
