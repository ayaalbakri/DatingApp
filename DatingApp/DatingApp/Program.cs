using DatingApp.Repository;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DatingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //entry point
            //var cccc = new UserTest();
            //var n = cccc.Te();
            UserTest xxx = new UserTest("x", "y");
            xxx.Te();
            //var g = cccc.Te();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
