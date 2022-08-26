using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using ManagedIdentity.Svc.Exceptions;
using ManagedIdentity.Svc.Extenstions;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

BuildServices(builder.Services, builder.Configuration);

ConfigureApplication(builder.Build());

static void BuildServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Vouchers API",
            Description = "An API for managing vouchers",
        });
        c.EnableAnnotations();
    });
    services.AddTableStorage(configuration);

    var assembly = typeof(Program).Assembly;
    services.AddMediatR(assembly);
    services.AddFluentValidation(new[] { assembly });

    services.AddProblemDetails(c =>
    {
        c.Map<ValidationException>(ex => new ProblemDetails
        {
            Status = (int)HttpStatusCode.BadRequest,
            Title = "Validation failed",
            Detail = string.Join(", ", ex.Errors.Select(x => x.ErrorMessage))
        });
        c.MapToStatusCode<VoucherNotFoundException>((int)HttpStatusCode.NotFound);
        c.MapToStatusCode<VoucherAlreadyRedeemedException>((int)HttpStatusCode.Conflict);
    });
}

static void ConfigureApplication(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseProblemDetails();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
