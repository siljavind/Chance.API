using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Repos;
using Chance.Repo.Interfaces;
using Chance.Repo.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowMyOrigin",
            builder => builder.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });


builder.Services.AddScoped<IImmutableRepo<Ability>, ImmutableRepo<Ability>>();
builder.Services.AddScoped<IImmutableRepo<Skill>, ImmutableRepo<Skill>>();
builder.Services.AddScoped<IGenericRepo<Background>, GenericRepo<Background>>();
builder.Services.AddScoped<IGenericRepo<Class>, GenericRepo<Class>>();
builder.Services.AddScoped<IGenericRepo<Feature>, GenericRepo<Feature>>();
builder.Services.AddScoped<IGenericRepo<Race>, GenericRepo<Race>>();
builder.Services.AddScoped<IGenericRepo<Subrace>, GenericRepo<Subrace>>();

builder.Services.AddDbContext<ChanceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
    // To create ef migration use command: dotnet ef migrations add InitialCreate --project ../Chance.Repo
    // To update db use command: dotnet ef database update --project ../Chance.Repo
    // --project is added because the dbcontext is in the Repo layer
});

// Add JsonStringEnumConverter to convert enums to strings in json
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// TODO: Add global error handling
//app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        //To serve the Swagger UI at the app's root
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowMyOrigin"); // Apply the CORS policy

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
