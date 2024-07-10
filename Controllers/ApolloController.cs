using CherryWeb.Extensions;
using CherryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ApolloController(IConfiguration configuration, ILogger<ApolloController> logger)
    : ControllerBase
{
    [HttpGet]
    public string? GetConfig() {
        return configuration.GetApolloValue("my.name");
    }

    public object? GetUser()
    {
        var value = configuration.GetApolloValue<User>("default.user");
        logger.LogInformation("获取到值 : {0}", value);
        return value;
    }
}