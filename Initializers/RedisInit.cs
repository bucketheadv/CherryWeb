using StackExchange.Redis;

namespace CherryWeb.Initializers;

public abstract class RedisInit
{
    public static void Init(WebApplicationBuilder builder)
    {
        var redisConfig = builder.Configuration.GetSection("Redis");
        var value = redisConfig?["Value"];
        if (value == null) return;
        IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(value);
        builder.Services.AddSingleton(redis);
    }
}