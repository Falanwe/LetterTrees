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

        public bool IsFinal { get; private set; }

        public bool ContainsString(string s)
        {
            if(s == "")
            {
                return IsFinal;
            }

            return _children.TryGetValue(s[0], out var child) && child.ContainsString(s.Substring(1));
        }

        public static NewLetterTree Encode(string s)
        {
            var root = new NewLetterTree();
            if(s.Length>0)
            {
                root.TryAddChild(s[0], Encode(s.Substring(1)));
            }
            else
            {
                root.IsFinal = true;
            }
            return root;
        }

        public override string ToString() => $"{string.Join(',', _children)}";
    }
}
