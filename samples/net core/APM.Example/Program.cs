using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Reporting.InfluxDB;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace APM.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureMetricsWithDefaults(
                    builder =>
                    {
                        builder.Report.ToInfluxDb("http://<influx server IP>:8086", "_internal");
                    })
                .UseMetrics()
                .UseStartup<Startup>()
                .Build();
    }
}
