using Microsoft.AspNetCore.Mvc;
using CherryWeb.Models;
using CherryWeb.Dao;
using StackExchange.Redis;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase {
    private readonly IUserDao _userDao;

    private readonly IConnectionMultiplexer _redis;

    private readonly ILogger<UserController> _logger;

    public UserController(IUserDao userDao, IConnectionMultiplexer redis, ILogger<UserController> logger)
    {
        _userDao = userDao;
        _redis = redis;
        _logger = logger;
    }

    [HttpGet]
    public User? GetUser(long id)
    {
        string? abc = _redis.GetDatabase(0).StringGet("abc");
        _logger.LogInformation("获取abc: {}", abc);
        return _userDao.GetUser(id);
    }
}