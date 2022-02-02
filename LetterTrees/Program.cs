using LetterTrees.Models;
using System;

namespace LetterTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootTree = NewLetterTree.Encode("csharp");
            rootTree.Children['c'].TryAddChild('p', NewLetterTree.Encode("lusplus"));
            rootTree.TryAddChild('j', NewLetterTree.Encode("avascript"));

            Console.WriteLine(rootTree.ContainsString("csharp"));
            Console.WriteLine(rootTree.ContainsString("cplusplus"));            
            Console.WriteLine(rootTree.ContainsString("java"));
            Console.WriteLine(rootTree.ContainsString("javascript"));            
        }
    }
}
