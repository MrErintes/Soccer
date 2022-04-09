using MediatR;
using Microsoft.EntityFrameworkCore;
using Soccer.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Soccer.Application.Mappers;
using Soccer.Core.Repositories.Base;
using Soccer.Infrastructure.Data.Repositories.Base;
using Soccer.Core.Repositories;
using Soccer.Infrastructure.Data.Repositories;
using Soccer.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(typeof(CreatePlayerHandler).Assembly);

builder.Services.AddDbContext<SoccerContext>(config => config.UseInMemoryDatabase("SoccerDB"));

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Soccer.API",
        Version = "v1"
    });
});

builder.Services.AddAutoMapper(typeof(SoccerMappingProfile));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
