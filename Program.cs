using CherryWeb.Extensions;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Logging;
using CherryWeb.Initializers;
using CherryWeb.Jobs;
using DotXxlJob.Core;
using DotXxlJob.Core.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 必须监听0.0.0.0，否则xxl-job通过ip调用调不通
builder.WebHost.UseUrls("http://0.0.0.0:5148");

void InitXxlJob(WebApplicationBuilder appBuilder)
{
    var services = appBuilder.Services;
    var configuration = appBuilder.Configuration;
    services.AddXxlJobExecutor(configuration);
    services.AddSingleton<IJobHandler, XxlJobDemo>();
    services.AddAutoRegistry();
}

InitXxlJob(builder);

LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
builder.Configuration.AddApollo(builder.Configuration.GetSection("Apollo"))
    .AddDefault();

DbInit.Init(builder);
RedisInit.Init(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseXxlJobExecutor();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
