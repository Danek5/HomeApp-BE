using Home_app.Services.Interfaces;

namespace Home_app.Services;

public class EventArchiveService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public EventArchiveService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextMidnight = now.Date.AddDays(1);
            var timeUntilMidnight = nextMidnight - now;

            await Task.Delay(timeUntilMidnight, stoppingToken);
            
            using (var scope = _serviceProvider.CreateScope())
            {
                var eventService = scope.ServiceProvider.GetRequiredService<IEventServices>();
                await eventService.ArchiveExpiredEvents();
            }

            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}