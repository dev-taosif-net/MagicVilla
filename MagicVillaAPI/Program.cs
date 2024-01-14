using MagicVillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

////////Log
////////Log.Logger = new LoggerConfiguration().MinimumLevel.Error()
////////                .WriteTo.File("Log/Log.txt",rollingInterval: RollingInterval.Day)
////////                .Enrich.WithProperty("CustomName",DateTime.Now)
////////                .CreateLogger();

////////builder.Host.UseSerilog();

//====================Conncetion String ==============
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});


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

app.UseAuthorization();

app.MapControllers();

app.Run();
