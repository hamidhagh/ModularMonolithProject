using Ardalis.Result;
using MediatR;

namespace BookStore.Users.Contracts;

public record UserAddressDetailsByIdQuery(Guid AddressId) : 
  IRequest<Result<UserAddressDetails>>;
