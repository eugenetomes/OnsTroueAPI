using Microsoft.OpenApi.Models;
using OnsTrou.App.Services;
using OnsTrou.Application;
using OnsTrou.Application.Abstractions;
using OnsTrou.Persistence;
using OnsTrou.Persistence.Abstractions;

namespace OnsTrou.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();
        services.AddPersistence(Configuration);


        services.AddHttpContextAccessor();
        services.AddScoped<ITenantProvider, TenantProvider>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
        });
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        var loggerOptions = new LambdaLoggerOptions(Configuration);
        loggerFactory.AddLambdaLogger(loggerOptions);


        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCCallWebAPI");
        });
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}