using Microsoft.EntityFrameworkCore;
//using Chance.Repo.Data;
using Chance.Repo.Data;
using Chance.Repo.Repos;
using Chance.Repo.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Database
// builder.Services.AddDbContext<ChanceDbContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
// });

//builder.Services.AddScoped<IAbilitiesRepo, AbilitiesRepo>();

builder.Services.AddDbContext<ChanceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
    // To create ef migration use command: dotnet ef migrations add InitialCreate --project ../Chance.Repo
    // To update db use command: dotnet ef database update --project ../Chance.Repo
    // --project is added because the dbcontext is in the Repo layer

});

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
