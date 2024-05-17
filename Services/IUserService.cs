namespace blazor.Services;

public interface IUserService
{
  Task<bool> CreateUser(User user);
  Task<List<User>> GetUsers();
  Task<User> UpdateUser(User user);
  Task<bool> DeleteUser(int key);
}