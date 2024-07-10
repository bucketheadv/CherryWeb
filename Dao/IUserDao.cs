using CherryWeb.Models;

namespace CherryWeb.Dao;

public interface IUserDao {
    bool CreateUser(User user);

    User? GetUser(long id);
}