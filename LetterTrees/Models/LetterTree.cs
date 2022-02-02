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
    }
}
