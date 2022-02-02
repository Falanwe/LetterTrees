using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterTrees.Models
{
    public class LetterTree
    {
        public char Letter { get; }

        public List<LetterTree> Children { get; } = new List<LetterTree>();

        public LetterTree(char letter)
        {
            Letter = letter;
        }

        public LetterTree(string s)
        {
            if (s.Length == 0)
            {
                throw new ArgumentException("cannot encode empty string");
            }

            Letter = s[0];
            if (s.Length > 1)
            {
                Children.Add(Encode(s.Substring(1)));
            }            
        }

        public static LetterTree Encode(string s)
        {
            if(s.Length == 0)
            {
                throw new ArgumentException("cannot encode empty string");
            }

            var result = new LetterTree(s[0]);
            if (s.Length > 1)
            {
                result.Children.Add(Encode(s.Substring(1)));
            }
            return result;
        }

        public static explicit operator LetterTree(string s) => Encode(s);

        public override string ToString() => $"'{Letter}'({String.Join(',', Children)})";        
    }
}
