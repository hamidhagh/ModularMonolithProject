using Ardalis.Result;
using MediatR;

namespace BookStore.Books.Contracts;

public record BookDetailsQuery(Guid BookId) : IRequest<Result<BookDetailsResponse>>;
