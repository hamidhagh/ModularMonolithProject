using BookStore.Users.Domain;

namespace BookStore.Users.Interfaces;

public interface IReadOnlyUserStreetAddressRepository
{
  Task<UserStreetAddress?> GetById(Guid userStreetAddressId);
}

