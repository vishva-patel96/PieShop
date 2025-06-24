using PieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddDbContext<PieShopDbContext>(options => {
    options.UseSqlServer
    (builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
    });

var app = builder.Build();

app.UseStaticFiles();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
