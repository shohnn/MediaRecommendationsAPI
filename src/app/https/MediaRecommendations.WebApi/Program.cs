using MediaRecommendations.Application.UseCases;
using MediaRecommendations.Domain.Contracts;
using MediaRecommendations.Infrastructure.Repositories;
using MediaRecommendations.Infrastructure.TmdbService;

var builder = WebApplication.CreateBuilder(args);


//DI Repositories
builder.Services.AddScoped<IMediaInformationService, TmdbService>();
builder.Services.AddScoped<IMoviesDAO, MoviesDAO>();

//DI Use Cases
builder.Services.AddScoped<GetIntelligentBillboard>();

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

