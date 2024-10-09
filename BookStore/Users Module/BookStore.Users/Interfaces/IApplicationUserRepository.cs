using BookStore.Users.Domain;

namespace BookStore.Users.Interfaces;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserByIdAsync(Guid userId);
  Task<ApplicationUser> GetUserWithAddressesByEmailAsync(string email);
  Task<ApplicationUser> GetUserWithCartByEmailAsync(string email);
  Task SaveChangesAsync();
}
