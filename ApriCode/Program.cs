using ApriCode.Bll.Config;
using ApriCode.Config;
using ApriCode.Dal;
using ApriCode.Extencions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string? _connString = "CON_STRING";

var connString = builder.Configuration.GetValue<string>(_connString);

builder.Services.AddDbContext<Context>(op =>
            op.UseSqlServer(connString));

builder.Services.RegisterProjectRepositories();
builder.Services.RegisterProjectServices();

builder.Services.AddAutoMapper(typeof(BllMapper).Assembly, typeof(ApiMapper).Assembly);

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
