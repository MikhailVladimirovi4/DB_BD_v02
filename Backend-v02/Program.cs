using Backend_v02.DataBaseAccess;
using Backend_v02.DataBaseAccess.Repositories;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DataBaseDbContext)));
    });

builder.Services.AddScoped<ICamerasService, CamerasService>();
builder.Services.AddScoped<ICamerasRepository, CamerasRepository>();
builder.Services.AddScoped<IDoorsService, DoorsService>();
builder.Services.AddScoped<IDoorsRepository, DoorsRepository>();
builder.Services.AddScoped<IStateOrdersService, StateOrdersService>();
builder.Services.AddScoped<IStateOrdersRepository, StateOrdersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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
