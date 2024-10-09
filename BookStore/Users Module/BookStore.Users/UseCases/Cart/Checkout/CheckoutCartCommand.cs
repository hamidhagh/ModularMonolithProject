using Ardalis.Result;
using MediatR;

namespace BookStore.Users.UseCases.Cart.Checkout;
public record CheckoutCartCommand(string EmailAddress,
                                  Guid shippingAddressId,
                                  Guid billingAddressId)
                                                          : IRequest<Result<Guid>>;
