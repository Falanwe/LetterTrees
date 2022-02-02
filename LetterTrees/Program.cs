using LetterTrees.Models;
using System;

namespace LetterTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootTree = NewLetterTree.Encode("csharp");


            Console.WriteLine(rootTree);
        }
    }
}
