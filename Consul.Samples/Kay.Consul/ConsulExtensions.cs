using System;
using Consul;
using Microsoft.Extensions.Configuration;

namespace Kay.Consul
{
    public static class ConsulExtensions
    {
        public static void UseConsul(this IConfiguration configuration, ConsulSettings consulSettings)
        {
            var client = new ConsulClient(x => { x.Address = new Uri(consulSettings.Address); });
            var service = new AgentServiceRegistration
            {
                ID = Guid.NewGuid().ToString(),
                Name = consulSettings.ServiceName,
                Address = consulSettings.ServiceIp,
                Port = consulSettings.ServicePort,
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    Interval = TimeSpan.FromSeconds(10),
                    HTTP = consulSettings.ServiceHealth,
                    Timeout = TimeSpan.FromSeconds(5)
                }
            };

            client.Agent.ServiceRegister(service).Wait();
        }
    }
}