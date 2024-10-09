using BookStore.Orders.Domain;

namespace BookStore.Orders.Interfaces;

internal interface IOrderRepository
{
  Task<List<Order>> ListAsync();
  Task AddAsync(Order order);
  Task SaveChangesAsync();
}
