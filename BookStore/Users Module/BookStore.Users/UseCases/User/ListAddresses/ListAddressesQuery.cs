using Ardalis.Result;
using BookStore.Users.UserEndpoints;
using MediatR;

namespace BookStore.Users.UseCases.User.ListAddresses;
internal record ListAddressesQuery(string EmailAddress) :
  IRequest<Result<List<UserAddressDto>>>;
