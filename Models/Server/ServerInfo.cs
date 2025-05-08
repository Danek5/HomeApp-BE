using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Server;

public class ServerInfo
{
    [Key]
    public Guid Id { get; init; }
    public DateTime DateTime { get; init; } = DateTime.UtcNow;
    public double CpuUsagePercentage { get; init; }
    public ulong TotalMemory { get; init; }
    public ulong AvailableMemory { get; init; }
    public ulong? GpuMemory { get; init; }
}
