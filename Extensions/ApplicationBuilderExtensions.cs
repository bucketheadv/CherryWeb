using CherryWeb.Middlewares;

namespace CherryWeb.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseXxlJobExecutor(this IApplicationBuilder @this)
    {
        return @this.UseMiddleware<XxlJobExecutorMiddleware>();
    }
}