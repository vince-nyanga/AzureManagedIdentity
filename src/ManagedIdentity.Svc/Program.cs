using ManagedIdentity.Svc.Extenstions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

BuildServices(builder.Services, builder.Configuration);

ConfigureApplication(builder.Build());

static void BuildServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.EnableAnnotations();
    });
    services.AddTableStorage(configuration);
    services.AddMediatR(typeof(Program));

}

static void ConfigureApplication(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


// Configure the HTTP request pipeline.

