using Microsoft.AspNetCore.Mvc;
using CherryWeb.Models;
using CherryWeb.Dao;
using StackExchange.Redis;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IUserDao userDao, IDatabase redis, ILogger<UserController> logger)
    : ControllerBase
{
    [HttpGet]
    public User? GetUser(long id)
    {
        string? abc = redis.StringGet("abc");
        logger.LogInformation("获取abc: {}", abc);
        return userDao.GetUser(id);
    }
}