using Ardalis.Result;
using BookStore.Users.CartEndpoints;
using MediatR;

namespace BookStore.Users.UseCases.Cart.ListItems;

public record ListCartItemsQuery(string EmailAddress) : IRequest<Result<List<CartItemDto>>>;
