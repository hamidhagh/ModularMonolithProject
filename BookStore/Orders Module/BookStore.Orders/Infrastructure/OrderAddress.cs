using BookStore.Orders.Domain;

namespace BookStore.Orders.Infrastructure;

// This is the materialized view's data model
internal record OrderAddress(Guid Id, Address Address);
