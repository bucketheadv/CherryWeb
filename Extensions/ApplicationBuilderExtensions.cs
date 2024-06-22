using CherryWeb.Dao;
using CherryWeb.Dao.Contexts;
using CherryWeb.Dao.Impl;
using CherryWeb.Jobs;
using CherryWeb.Middlewares;
using DotXxlJob.Core;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace CherryWeb.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseXxlJobExecutor(this IApplicationBuilder @this)
    {
        return @this.UseMiddleware<XxlJobExecutorMiddleware>();
    }

    public static void UseExposureHost(this WebApplicationBuilder @this)
    {
        var conf = @this.Configuration.GetSection("xxlJob");
        var port = conf["port"];
        var url = $"http://0.0.0.0:{port}";
        // 必须监听0.0.0.0，否则xxl-job通过ip调用调不通
        @this.WebHost.UseUrls(url);
    }

    public static void InitXxlJobConfiguration(this WebApplicationBuilder @this)
    {
        var services = @this.Services;
        var configuration = @this.Configuration;
        services.AddXxlJobExecutor(configuration);
        services.AddSingleton<IJobHandler, XxlJobDemo>();
        services.AddAutoRegistry();
    }

    public static void InitDbConfiguration(this WebApplicationBuilder @this)
    {
        var mainConnectionStr = @this.Configuration.GetConnectionString("main");
        @this.Services.AddDbContext<MainDbContext>(options => options.UseMySql(mainConnectionStr, MySqlServerVersion.LatestSupportedServerVersion));
        @this.Services.AddScoped<IUserDao, UserDao>();
    }

    public static void InitRedisConfiguration(this WebApplicationBuilder @this)
    {
        var redisConfig = @this.Configuration.GetSection("Redis");
        var value = redisConfig?["Value"];
        if (value == null) return;
        IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(value);
        @this.Services.AddSingleton(redis);
    }
}