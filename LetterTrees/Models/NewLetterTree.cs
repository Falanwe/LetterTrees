using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (s == "")
            {
                return IsFinal;
            }

            return _children.TryGetValue(s[0], out var child) && child.ContainsString(s.Substring(1));
        }

        /// <summary>
        /// Changes the content of the tree to make sure the string s is present afterwards.
        /// </summary>
        /// <param name="s">The string to add to the tree if not already there</param>
        public void AddIfNeeded(string s)
        {
            if (s == "")
            {
                IsFinal = true;
                return;
            }

            if (_children.TryGetValue(s[0], out var child))
            {
                child.AddIfNeeded(s.Substring(1));
            }
            else
            {
                TryAddChild(s[0], Encode(s.Substring(1)));
            }
        }

        public void Feed(IEnumerable<char> source)
        {
            var current = this;
            foreach(var c in source)
            {
                if(char.IsLetter(c))
                {
                    var lowerC = char.ToLower(c);
                    if(!current._children.TryGetValue(lowerC, out var child))
                    {
                        child = new NewLetterTree();
                        current._children.Add(lowerC, child);
                    }
                    current = child;
                }
                else
                {
                    current.IsFinal = true;
                    current = this;
                }
            }
            current.IsFinal = true;
        }

        /// <summary>
        /// Lists all strings encoded in the tree
        /// </summary>
        /// <returns>The sequence of all strings encoded in the tree</returns>
        public IEnumerable<string> ListStrings()
        {
            if(IsFinal)
            {
                yield return "";
            }

            foreach(var kvp in _children)
            {
                foreach(var s in kvp.Value.ListStrings())
                {
                    yield return kvp.Key + s;
                }
            }
        }

        /// <summary>
        /// Counts the number of strings encoded by the tree
        /// </summary>
        /// <returns>The number of strings encoded by the tree</returns>
        public int Count() => (IsFinal ? 1 : 0) + Children.Values.Sum(child => child.Count());

        public IEnumerable<string> Search(string prefix)
        {
            if(prefix == "")
            {
                foreach(var s in ListStrings())
                {
                    yield return s;
                }
            }
            else if(_children.TryGetValue(prefix[0], out var child))
            {
                foreach(var s in child.Search(prefix.Substring(1)))
                {
                    yield return prefix[0] + s;
                }
            }
            else
            {
                yield break;
            }
        }

        public static NewLetterTree Encode(string s)
        {
            var root = new NewLetterTree();
            if (s.Length > 0)
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
