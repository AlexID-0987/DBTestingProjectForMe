using DBTestingProject.Models;
using DBTestingProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FurnitureDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddScoped<IFurnitureOperations, FurnitureWithOperation>();
builder.Services.AddSingleton<IDateTime, MyTime>();

var app = builder.Build();

using(var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<FurnitureDBContext>();
        FurnitureData.Init(context);
        context.Database.EnsureCreated();
    }
    catch(Exception ex)
    {

    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
