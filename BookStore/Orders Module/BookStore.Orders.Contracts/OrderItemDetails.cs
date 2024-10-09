namespace BookStore.Orders.Contracts;

public record OrderItemDetails(Guid BookId,
                               int Quantity,
                               decimal UnitPrice,
                               string Description);
