using System;
using System.IO;
using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.UE4.Versions;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using PakFileManagerLibrary; // Explicitly qualify the namespace
namespace PakFileManagerTool
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: PakFileManager <aesKey> <gameVersion> <inputDirectory> <outputDirectory>");
                return;
            }

            string aesKey = args[0];
            EGame gameVersion = (EGame)Enum.Parse(typeof(EGame), args[1]);
            string inputDirectory = args[2];
            string outputDirectory = args[3];

            Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Literate).CreateLogger();

            var pakFileManager = new PakFileManager(aesKey, gameVersion);
            pakFileManager.UnpackPakFiles(inputDirectory, outputDirectory);
        }
    }
}
