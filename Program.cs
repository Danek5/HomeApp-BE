using Home_app.DBContext;
using Home_app.Infrastructure;
using Home_app.Repositories;
using Home_app.Repositories.Interfaces;
using Home_app.Services;
using Home_app.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<EventArchiveService>();
builder.Services.AddScoped<ITagServices, TagService>();
builder.Services.AddScoped<IHealthServices, HealthServices>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {Level:u4}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<HomeAppContext>(optionsBuilder =>
{
    var host = Environment.GetEnvironmentVariable("PGHOST");
    var port = Environment.GetEnvironmentVariable("PGPORT");
    var database = Environment.GetEnvironmentVariable("PGDATABASE");
    var user = Environment.GetEnvironmentVariable("PGUSER");
    var password = Environment.GetEnvironmentVariable("PGPASSWORD");

    if (!string.IsNullOrEmpty(host))
    {
        var connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};Ssl Mode=Require;Trust Server Certificate=true;";
        optionsBuilder.UseNpgsql(connectionString);
    }
    else
    {
        optionsBuilder.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<HomeAppContext>();
await dbContext.Database.MigrateAsync();

if (!app.Environment.IsDevelopment())
{

    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();

app.UseCors();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
