using Microsoft.AspNetCore.Mvc;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class ApolloController : ControllerBase {
    private readonly IConfiguration _configuration;

    private readonly ILogger<ApolloController> _logger;

    public ApolloController(IConfiguration configuration, ILogger<ApolloController> logger) {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet]
    public object? Get() {
        return _configuration["my.name"];
    }
}