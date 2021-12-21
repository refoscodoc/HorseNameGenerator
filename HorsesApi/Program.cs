using HorsesApi.Interfaces;
using HorsesApi.MySqlDataAccess;
using HorsesApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var sqlConnectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
var sqlConnectionString = "server=localhost;userid=alberto;password=vinazza;database=english_dictionary;";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

builder.Services.AddDbContext<DomainModelMySqlContext>(options =>
    options.UseMySql(
        sqlConnectionString, serverVersion,
        b => b.MigrationsAssembly("AspNetCoreMultipleProject")
    )
);

builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();
builder.Services.AddScoped<BusinessProvider>();

// builder.Services.AddTransient(typeof(IDataAccessProvider), typeof(DataAccessProvider));
// builder.Services.AddTransient(typeof(BusinessProvider));

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