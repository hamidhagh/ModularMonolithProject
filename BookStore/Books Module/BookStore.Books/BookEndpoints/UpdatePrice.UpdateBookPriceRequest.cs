namespace BookStore.Books.Endpoints;

public record UpdateBookPriceRequest(Guid Id, decimal NewPrice);
