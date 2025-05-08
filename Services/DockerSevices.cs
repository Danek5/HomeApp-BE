using Home_app.Services.Interfaces;
using Docker.DotNet;
using Docker.DotNet.Models;


namespace Home_app.Services;

public class DockerService
{
 /*   private readonly DockerClient _dockerClient;

    public DockerService()
    {
       // _dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
    }


    public async Task<IList<ContainerListResponse>> GetRunningContainers()
    {
        var containers = await _dockerClient.Containers.ListContainersAsync(new ContainersListParameters
        {
            Limit = 10,
            All = true
        });

        return containers;
    }
        
    public async Task<ContainerInspectResponse> GetContainerDetails(string containerId)
    {
        return await _dockerClient.Containers.InspectContainerAsync(containerId);
    }
    
    public async Task<string> GetContainerLogs(string containerId)
    {
        var parameters = new ContainerLogsParameters
        {
            ShowStdout = true,
            ShowStderr = true,
            Follow = false
        };

        var logs = await _dockerClient.Containers.GetContainerLogsAsync(containerId, parameters);
        return logs.ToString();
    }
    

    */
}
