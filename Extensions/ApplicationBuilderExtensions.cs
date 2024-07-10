using System.Net;
using CherryWeb.Dao;
using CherryWeb.Dao.Contexts;
using CherryWeb.Dao.Impl;
using CherryWeb.Jobs;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Logging;
using DotXxlJob.Core;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using LogLevel = Com.Ctrip.Framework.Apollo.Logging.LogLevel;

namespace CherryWeb.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseExposureHost(this WebApplicationBuilder @this)
    {
        var port = @this.Configuration.GetSection("Server")["Port"];
        @this.WebHost.UseKestrel(options =>
        {
            // 必须监听0.0.0.0，否则xxl-job通过ip调用调不通
            options.Listen(IPAddress.Any, Convert.ToInt32(port));
        });
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
        var redis = ConnectionMultiplexer.Connect(value);
        @this.Services.AddSingleton(redis);
        var db = redis.GetDatabase(0);
        @this.Services.AddSingleton(db);
    }

    public static void InitApolloConfiguration(this WebApplicationBuilder @this)
    {
        LogManager.UseConsoleLogging(LogLevel.Info);
        var configuration = @this.Configuration.GetSection("Apollo");
        @this.Configuration.AddApollo(configuration).AddDefault();
    }
}