using CherryWeb.Models;
using CherryWeb.Contexts;

namespace CherryWeb.Dao.Impl {
    public class UserDao : IUserDao {
        private readonly MainDbContext _mainDbContext;

        public UserDao(MainDbContext mainDbContext) {
            _mainDbContext = mainDbContext;
        }

        public bool CreateUser(User user) {
            _mainDbContext.User.Add(user);
            return _mainDbContext.SaveChanges() > 0;
        }

        public User? GetUser(long id) {
            return _mainDbContext.Find<User>(id);
        }
    }
}
