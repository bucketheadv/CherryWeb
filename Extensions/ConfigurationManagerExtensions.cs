using Newtonsoft.Json;

namespace CherryWeb.Extensions;

public static class ConfigurationManagerExtensions
{
    public static T? GetApolloValue<T>(this IConfiguration @this, string key)
    {
        var v = @this[key];
        if (typeof(T?) == typeof(string))
        {
            return (T?)Convert.ChangeType(v, typeof(T));
        }

        if (string.IsNullOrEmpty(v))
        {
            return (T?)Convert.ChangeType(null, typeof(T));
        }

        return JsonConvert.DeserializeObject<T>(v);
    }

    public static string? GetApolloValue(this IConfiguration @this, string key)
    {
        return @this.GetApolloValue<string>(key);
    }
}