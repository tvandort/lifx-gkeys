using System;
using Fclp;

namespace lifx_gkeys
{

    class Program
    {
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
                Run(p.Object);    
            } else
            {
                foreach (var err in result.Errors)
                {
                    var option = err.Option;
                    Console.WriteLine($"--{option.LongName}: {option.Description}.");
                }
            }

            Console.ReadKey();
        }

        static void Run(ApplicationArguments args)
        {
            Console.WriteLine($"State: {args.State}");
            Console.WriteLine($"Room: {args.Room}");
        }
    }
}
