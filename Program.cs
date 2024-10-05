using Home_app.DBContext;
using Home_app.Repositories;
using Home_app.Repositories.Interfaces;
using Home_app.Services;
using Home_app.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<HomeAppContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITagServices, TagService>();
builder.Services.AddScoped<IHealthServices, HealthServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();
Console.WriteLine(app.Environment.EnvironmentName);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HomeAppContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while migrating the database.");
        throw;
    }
}

if (!app.Environment.IsDevelopment())
{
    //app.UseHttpsRedirection();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

