using DotXxlJob.Core;

namespace CherryWeb.Middlewares;

public class XxlJobExecutorMiddleware
{

    private readonly IServiceProvider _serviceProvider;

    private readonly RequestDelegate _next;

    private readonly XxlRestfulServiceHandler _rpcService;

    public XxlJobExecutorMiddleware(IServiceProvider provider, RequestDelegate next)
    {
        this._serviceProvider = provider;
        this._next = next;
        this._rpcService = _serviceProvider.GetRequiredService<XxlRestfulServiceHandler>();
    }

    public async Task Invoke(HttpContext context)
    {
        string contentType = context.Request.ContentType;
        if ("POST".Equals(context.Request.Method, StringComparison.OrdinalIgnoreCase)
            && !string.IsNullOrEmpty(contentType) && contentType.ToLower().StartsWith("application/json"))
        {
            await _rpcService.HandlerAsync(context.Request, context.Response);
            return;
        }

        await _next.Invoke(context);
    }
}