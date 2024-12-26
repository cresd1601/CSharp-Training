using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Shopee.API.Extensions;
using Shopee.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilogConfig();

builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddAuthenticationConfig(builder.Configuration);
builder.Services.AddControllerConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddAutoMapperConfig();
builder.Services.AddServiceConfig();
builder.Services.AddRepositoryConfig();
builder.Services.AddApiVersionConfig();

var app = builder.Build();

var versionDescriptionProvider =
    app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach(var description in versionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseMiddleware<PerformanceMiddleware>();
app.UseMiddleware<TransactionMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

