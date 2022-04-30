using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorApp1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


/*
builder.Services.AddDbContext<RazorApp1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorApp1Context") ?? throw new InvalidOperationException("Connection string 'RazorApp1Context' not found.")));
*/

builder.Services.AddDbContext<RazorApp1Context>(options => options.UseInMemoryDatabase("RazorApp1"));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RazorApp1Context>();
    dbContext.Database.EnsureCreated();
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
