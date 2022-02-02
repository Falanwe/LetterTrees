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

            Console.WriteLine(rootTree.ContainsString("cplusplus"));
            Console.WriteLine(rootTree.ContainsString("cplus"));
            Console.WriteLine(rootTree.ContainsString("java"));
        }
    }
}
