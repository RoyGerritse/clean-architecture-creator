using System;
using System.Reflection;

namespace CAC.Tool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var versionString = Assembly.GetEntryAssembly()
                                          .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                          .InformationalVersion
                                          .ToString();
            Console.WriteLine($"Clean Architecture Creator .NET Command-line Tools");
            if (args.Length == 0)
            {
                DefaultHelp();
                return;
            }

            switch (args[0])
            {
                case "init":
                    if (!string.IsNullOrEmpty(args[1]))
                    {
                        Console.WriteLine($"Creating setup for namespace {args[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Usage: dotnet cac init [namespace]");
                    }
                    break;
                case "--help":
                case "-h":
                    DefaultHelp();
                    break;
                case "--version":
                    Console.WriteLine("Version: " + versionString);
                    break;
            }
        }

        private static void DefaultHelp()
        {
            Console.WriteLine($"Options:");
            Console.WriteLine($"\t --version \t Show version information");
            Console.WriteLine($"\t -h|--help \t Show help information");
            Console.WriteLine();
            Console.WriteLine($"Commands:");
            Console.WriteLine($"\t init \t Initialize new Clean Architecture project.");
            Console.WriteLine();
            Console.WriteLine($"Use \"dotnet cac [command] --help\" for more information about a command.");
        }
    }
}
