using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto_ESFase2.Controllers;
using Projeto_ESFase2.Data;

using Projeto_ESFase2.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ES2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ES2Context") ?? throw new InvalidOperationException("Connection string 'ES2Context' not found.")));

// Add services to the container.
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<CompetitionFuntions>();
builder.Services.AddScoped<Iterator>();




builder.Services.AddControllersWithViews();


var app = builder.Build();

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
