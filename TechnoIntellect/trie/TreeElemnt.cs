using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoIntellect.trie
{
    public class TreeElemnt
    {

        public SortedDictionary<char, TreeElemnt> Childrens = new SortedDictionary<char, TreeElemnt>();

        public List<int> LineNumber = new List<int>();

    }
}
