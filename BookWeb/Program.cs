using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.IO;
using System.Net;

namespace BookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(ConfigHttps)
                //必须指定端口，否则在Win10命令行运行端口是5000，在CentOS docker运行端口是80
                //.UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();

        private static void ConfigHttps(KestrelServerOptions options)
        {
            options.Listen(IPAddress.Any, 5000, listenOptions =>
            {
                //填入pfx文件路径和指定的密码
                string pfxFile = Path.Combine(Directory.GetCurrentDirectory(), "demoweb.pfx");
                listenOptions.UseHttps(pfxFile, "demo1234");
            });

            //http服务端口
            options.Listen(IPAddress.Any, 5001);

        }
    }
}
