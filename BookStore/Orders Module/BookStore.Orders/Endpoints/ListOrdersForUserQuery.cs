using Ardalis.Result;
using MediatR;

namespace BookStore.Orders.Endpoints;

internal record ListOrdersForUserQuery(string EmailAddress) : 
  IRequest<Result<List<OrderSummary>>>;


