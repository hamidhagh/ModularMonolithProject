namespace BookStore.Orders.Endpoints;

public class ListOrdersForUserResponse
{
  public List<OrderSummary> Orders { get; set; } = new();
}
