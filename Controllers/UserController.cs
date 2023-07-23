using Microsoft.AspNetCore.Mvc;
using CherryWeb.Models;
using CherryWeb.Dao;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase {
    private readonly IUserDao _userDao;

    public UserController(IUserDao userDao)
    {
        _userDao = userDao;
    }

    [HttpGet]
    public User? GetUser(long id) {
        return _userDao.GetUser(id);
    }
}