using ESFase2.Models;
using ESFase2.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<ESDatabaseSettings>(
    builder.Configuration.GetSection("CategoriesDB"));

builder.Services.AddSingleton<UsersService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
