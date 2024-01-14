using dotnet_pokemon_review.Data;
using dotnet_pokemon_review.Interfaces;
using dotnet_pokemon_review.Middleware;
using dotnet_pokemon_review.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(ModelStateValidatorFilter));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // AutoMapper
builder.Services.AddDbContext<DataContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!);
});

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRespository>();

var app = builder.Build();
app.UseMiddleware<ResponseTimeMiddleware>();

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
