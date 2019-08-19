using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Hashor.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string ar = args.Length >= 1
                ? args[0]
                : throw new ArgumentException("No arguments supplied. Use the -h option to see usage.");

            Parser parser = new Parser(config => config.HelpWriter = Console.Out);

            parser.ParseArguments<HashOptions.SriOptions, HashOptions>(args)
                .WithParsed<HashOptions>(options => { })
                .WithParsed<HashOptions.SriOptions>(options =>
                {
                    FileIngestService fileIngestService;
                    HashGenSri hashGen;

                    AlgorithmUtility algoUtil = new AlgorithmUtility();

                    if (options.Path != null)
                    {
                        fileIngestService = new FileIngestService(options.Path);
                        hashGen = DoSriHash(
                            options.Path,
                            algoUtil.GetAlgorithmType(options.AlgorithmName),
                            fileIngestService.GetFileAsText()
                        );
                        
                    }
                })
                .WithParsed<HashOptions.ListOptions>(options =>
                {
                    // TODO: plan features for hash gen w/o SRI
                })
                .WithNotParsed(errors =>
                {
                    // TODO: investigate docs for how to handle errors 
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                });
        }

        private static HashGenSri DoSriHash(string path, HashAlgorithmType algorithmName, string inputText)
        {
            return new HashGenSri(algorithmName, Encoding.UTF8, inputText);
        }
    }
}