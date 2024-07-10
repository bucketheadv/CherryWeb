using CherryWeb.Models;
using CherryWeb.Dao.Contexts;

namespace CherryWeb.Dao.Impl;

public class UserDao(MainDbContext mainDbContext) : IUserDao
{
    public bool CreateUser(User user) {
        mainDbContext.User?.Add(user);
        return mainDbContext.SaveChanges() > 0;
    }

    public User? GetUser(long id) {
        return mainDbContext.Find<User>(id);
    }
}