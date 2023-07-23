using CherryWeb.Contexts;
using CherryWeb.Dao;
using CherryWeb.Dao.Impl;
using Microsoft.EntityFrameworkCore;

namespace CherryWeb.Initializers
{
    public abstract class DbInit
    {
        public static void Init(WebApplicationBuilder builder)
        {
            var mainConnectionStr = builder.Configuration.GetConnectionString("main");

            builder.Services.AddDbContext<MainDbContext>(options => options.UseMySql(mainConnectionStr, MySqlServerVersion.LatestSupportedServerVersion));
            builder.Services.AddScoped<IUserDao, UserDao>();
        }
    }
}