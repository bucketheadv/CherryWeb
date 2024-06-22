using DotXxlJob.Core;

namespace CherryWeb.Middlewares;

public class XxlJobExecutorMiddleware(IServiceProvider provider, RequestDelegate next)
{
    private readonly XxlRestfulServiceHandler _rpcService = provider.GetRequiredService<XxlRestfulServiceHandler>();

    private readonly List<string> _xxlJobUris = [..new[] { "/beat", "/idlebeat", "/run", "/kill", "/log" }];

    public async Task Invoke(HttpContext context)
    {
        string path = context.Request.Path;
        if (_xxlJobUris.Contains(path))
        {
            await _rpcService.HandlerAsync(context.Request, context.Response);
            return;
        }

        await next.Invoke(context);
    }
}