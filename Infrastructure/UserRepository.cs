using MyArticles.Services;

namespace MyArticles.Infrastructure;

class UserRepository : IUserRepository
{
    public User FindById(int id)
    {
        return new();
    }

    public bool UpdateUser(User user)
    {
        return true;
    }
}

public interface IUserRepository
{
    User FindById(int id);
    bool UpdateUser(User user);
}