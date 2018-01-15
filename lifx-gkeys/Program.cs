using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fclp;

namespace lifx_gkeys
{

    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var p = new FluentCommandLineParser<ApplicationArguments>();
            p.Setup(arg => arg.State).
                As("state").             
                Required().
                WithDescription("Must be \"on\" or \"off\".");

            p.Setup(arg => arg.Room).
                As('r', "room").
                SetDefault("all");

            var result = p.Parse(args);
            
            if(!result.HasErrors)
            {
                Run(p.Object).Wait();    
            }
        }

        static async Task Run(ApplicationArguments args)
        {
            var data = new Payload(args.State);
            client.BaseAddress = new Uri("http://localhost:3000");
            await client.PostAsJsonAsync("/lights", data);            
        }
    }
}
