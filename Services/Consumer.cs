using Home_app.Models.Calendar.Dto;
using MassTransit;
using Event = Home_app.Migrations.Event;

namespace Home_app.Services;

public class Consumer : IConsumer<EventCreateDto>
{
    public async Task Consume(ConsumeContext<EventCreateDto> context)
    {
        var eventNotification = context.Message;
        Console.WriteLine("event notification");
        await Task.CompletedTask;
    }
}