using LetterTrees.Models;
using System;

namespace LetterTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootTree = new NewLetterTree();

            rootTree.AddIfNeeded("csharp");
            rootTree.AddIfNeeded("cplusplus");
            rootTree.AddIfNeeded("javascript");

            rootTree.Feed("un chasseur sachant chasser doit savoir chasser sans son chien");

            Console.WriteLine(rootTree.ContainsString("csharp"));
            Console.WriteLine(rootTree.ContainsString("cplusplus"));            
            Console.WriteLine(rootTree.ContainsString("java"));
            Console.WriteLine(rootTree.ContainsString("javascript"));

            Console.WriteLine(rootTree.Count());            

            foreach(var s in rootTree.ListStrings())
            {
                Console.WriteLine(s);
            }

                        
        }
    }
}
