using Microsoft.AspNetCore.Mvc;

namespace CherryWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class ApolloController : ControllerBase {
    public IConfiguration _configuration;

    public ApolloController(IConfiguration configuration) {
        _configuration = configuration;
    }

    [HttpGet]
    public object? Get() {
        return _configuration["my.name"];
    }
}