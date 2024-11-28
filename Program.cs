using System;
using System.IO;
using PakFileManagerLibrary; // Explicitly qualify the namespace

namespace PakFileManagerTool
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string keyFilePath = null;
            string inputDirectory = null;
            string outputDirectory = null;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-a":
                        if (i + 1 < args.Length)
                        {
                            keyFilePath = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing value for -a (AES key file path).");
                            PrintUsage();
                            return;
                        }
                        break;
                    case "-i":
                        if (i + 1 < args.Length)
                        {
                            inputDirectory = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing value for -i (input directory).");
                            PrintUsage();
                            return;
                        }
                        break;
                    case "-o":
                        if (i + 1 < args.Length)
                        {
                            outputDirectory = args[++i];
                        }
                        else
                        {
                            Console.WriteLine("Error: Missing value for -o (output directory).");
                            PrintUsage();
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine($"Error: Unknown argument {args[i]}");
                        PrintUsage();
                        return;
                }
            }

            if (string.IsNullOrEmpty(keyFilePath) || string.IsNullOrEmpty(inputDirectory) || string.IsNullOrEmpty(outputDirectory))
            {
                PrintUsage();
                return;
            }

            string aesKey = ExtractAesKeyFromFile(keyFilePath);
            if (string.IsNullOrEmpty(aesKey))
            {
                Console.WriteLine("Failed to extract AES key from the file.");
                return;
            }

            var pakFileManager = new PakFileManager(aesKey);
            pakFileManager.UnpackPakFiles(inputDirectory, outputDirectory);
        }

        private static string ExtractAesKeyFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Key file does not exist.");
                return null;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line.StartsWith("Key:"))
                {
                    string key = line.Split(new[] { "Key:" }, StringSplitOptions.None)[1].Trim();
                    // Ensure the key is exactly 64 hexadecimal characters long
                    if (key.Length >= 66 && key.StartsWith("0x"))
                    {
                        // Extract only the key part
                        key = key.Substring(0, 66);
                        // Remove the "0x" prefix
                        return key.Substring(2);
                    }
                    else
                    {
                        Console.WriteLine("AES key is not in the correct format.");
                        return null;
                    }
                }
            }

            Console.WriteLine("AES key not found in the file.");
            return null;
        }


        private static void PrintUsage()
        {
            Console.WriteLine("Usage: PakFileManager -a <keyFilePath> -i <inputDirectory> -o <outputDirectory>");
        }
    }
}
