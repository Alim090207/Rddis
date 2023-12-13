using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rddis.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBUser>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddStackExchangeRedisCache(options => {

    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    options.Configuration = connection;
    options.InstanceName = "redislab.com";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
