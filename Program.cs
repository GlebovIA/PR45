using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PR45
{
    public class Program
    {
        public static string ConnectionToMsSqlServer = "server=HOME-PC\\MYSERVER;" +
            "database=Libraries;" +
            "Integrated Security=true;";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
