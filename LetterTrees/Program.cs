using LetterTrees.Models;
using System;
using System.Diagnostics;
using System.IO;

namespace LetterTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();

            var rootTree = new NewLetterTree();
            using (var textReader = File.OpenText("comte_tome_1.txt"))
            {
                for (var line = textReader.ReadLine(); line != null; line = textReader.ReadLine())
                {
                    rootTree.Feed(line);
                }
            }
            watch.Stop();
            Console.WriteLine($"feeding took {watch.ElapsedMilliseconds} ms");

            Console.WriteLine(rootTree.Count());
            
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a prefix");
                var search = Console.ReadLine();
                Console.WriteLine("I found:");
                foreach(var s in rootTree.Search(search))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
