using Microsoft.EntityFrameworkCore;

using ASPDotNetCore.Models;
using ASPDotNetCore.Middlewares;
using ASPDotNetCore.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCookiePolicy();

app.UseCors();

app.UseStatusCodePages();

app.UseAuthorization();

app.UseResponseCaching();

app.MapControllers();

app.UseDatabaseConfigMiddleware();

app.Run();
