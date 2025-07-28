using System.Net;
using MyArticles.Infrastructure;
using MyArticles.Models;

namespace MyArticles.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Result<User> GetUserById(int id)
    {
        var user = userRepository.FindById(id);
        if (user == null)
            return Result<User>.Fail("User not found.", HttpStatusCode.NotFound);

        return new(user);
    }

    public Result UpdateUser(User user)
    {
        var status = userRepository.UpdateUser(user);
        if (status)
        {
            return new();
        }

        return Result.Fail("User Not Found", HttpStatusCode.NotFound);
    }
}

public interface IUserService
{
    Result<User> GetUserById(int id);
    Result UpdateUser(User user);
}
