using System.Diagnostics;
using Hardware.Info;
using Home_app.Models.Server;
using Home_app.Services.Interfaces;

namespace Home_app.Services;

public class ServerInfoService : IServerInfoService
{
    private readonly IHardwareInfo _hardwareInfo;

    public ServerInfoService()
    {
        _hardwareInfo = new HardwareInfo();
    }
/*
    public async Task<ServerInfo> GetServerInfoAsync()
    {
        _hardwareInfo.RefreshAll();

        var cpuLoad =  _hardwareInfo.CpuList.Count;
        var totalMemory = _hardwareInfo.MemoryStatus.TotalPhysical;
        var availableMemory = _hardwareInfo.MemoryStatus.AvailablePhysical;
        var gpuInfo = _hardwareInfo.VideoControllerList.FirstOrDefault();
        
 
        return new ServerInfo
        {
            CpuUsagePercentage = cpuLoad,
            TotalMemory = totalMemory,
            AvailableMemory = availableMemory,
            GpuMemory = gpuInfo?.AdapterRAM
        };
        
        
    }

    public async Task<string> GetRealTimeUsageAsync()
    {
        
        var cpuUsage = await GetCpuUsageAsync();
        Console.WriteLine($"CPU Usage: {cpuUsage}%");

        
        var ramUsage = await GetRamUsageAsync();
        Console.WriteLine($"RAM Usage: {ramUsage}");

        
        var gpuUsage = await GetGpuUsageAsync();
        Console.WriteLine($"GPU Usage: {gpuUsage}");

        return cpuUsage + ramUsage + gpuUsage;
    }

    private async Task<float> GetCpuUsageAsync()
    {
        string[] cpuStat1 = await File.ReadAllLinesAsync("/proc/stat");
        string[] cpuTime1 = cpuStat1[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        await Task.Delay(1000); // Delay for 1 second to measure the CPU usage over time
        string[] cpuStat2 = await File.ReadAllLinesAsync("/proc/stat");
        string[] cpuTime2 = cpuStat2[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        float idleTime1 = float.Parse(cpuTime1[4]);
        float idleTime2 = float.Parse(cpuTime2[4]);

        float totalTime1 = 0, totalTime2 = 0;
        for (int i = 1; i < cpuTime1.Length; i++)
        {
            totalTime1 += float.Parse(cpuTime1[i]);
            totalTime2 += float.Parse(cpuTime2[i]);
        }

        float totalDiff = totalTime2 - totalTime1;
        float idleDiff = idleTime2 - idleTime1;

        float cpuUsage = (totalDiff - idleDiff) / totalDiff * 100;
        return cpuUsage;
    }

    private async Task<string> GetRamUsageAsync()
    {
        var memInfo = await File.ReadAllLinesAsync("/proc/meminfo");
        string totalMemory = memInfo[0].Split(':')[1].Trim();   // MemTotal
        string freeMemory = memInfo[1].Split(':')[1].Trim();    // MemFree

        return $"Total: {totalMemory}, Free: {freeMemory}";
    }

    private async Task<string> GetGpuUsageAsync()
    {
        // Execute nvidia-smi command to get GPU usage, works if you have an NVIDIA GPU
        return await ExecuteBashCommand("nvidia-smi --query-gpu=utilization.gpu --format=csv,noheader,nounits");
    }

    private async Task<string> ExecuteBashCommand(string command)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        string result = await process.StandardOutput.ReadToEndAsync();
        process.WaitForExit();
        return result.Trim();
    }
*/
}