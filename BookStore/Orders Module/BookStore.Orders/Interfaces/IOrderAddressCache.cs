using Ardalis.Result;
using BookStore.Orders.Infrastructure;

namespace BookStore.Orders.Interfaces;

internal interface IOrderAddressCache
{
  Task<Result<OrderAddress>> GetByIdAsync(Guid addressId);
  Task<Result> StoreAsync(OrderAddress orderAddress);
}
