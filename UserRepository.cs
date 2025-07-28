using System.Net;

public class UserService(IUserRepository userRepository)
{
    public Result<User> GetUserById(int id)
    {
        var user = userRepository.FindById(id);
        if (user == null)
            return Result<User>.Fail("User not found.", HttpStatusCode.NotFound);

        return new(value : user);
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

public interface IUserRepository
{
    User FindById(int id);
    bool UpdateUser(User user);
}

public class User
{
    public int ID { get; set; }
}