using FluentValidation;
using FMS.Application;
using FMS.Infrastructure;
using FMS.Persistence;
using FMS.WebApi.Helper;
using FMS.WebApi.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddValidatorsFromAssemblyContaining<AddAccountValidator>();
// Add services to the container.
builder.Services.AddSingleton<ExceptionMiddleware>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }

        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }

        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "FMS API",
        Description = "this is dummy description"
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; 
});
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
