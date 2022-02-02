using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterTrees.Models
{
    public class NewLetterTree
    {
        private readonly Dictionary<char, NewLetterTree> _children = new Dictionary<char, NewLetterTree>();

        public IReadOnlyDictionary<char, NewLetterTree> Children => _children;

        public bool TryAddChild(char letter, NewLetterTree child) => _children.TryAdd(letter, child);

        public static NewLetterTree Encode(string s)
        {
            var root = new NewLetterTree();
            if(s.Length>0)
            {
                root.TryAddChild(s[0], Encode(s.Substring(1)));
            }
            return root;
        }

        public override string ToString() => $"{string.Join(',', _children)}";
    }
}
