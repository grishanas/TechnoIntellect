using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoIntellect.trie
{
    public class TreeObserver
    {

        private TreeElemnt root = new TreeElemnt();
        public List<TreeElemnt> Find(TreeElemnt elemnt)
        {
            throw new NotImplementedException();
        }

        public void AddElement(string value,int LineNumber)
        {
            var currentNode = root;
            foreach(var c in value)
            {
                if(!currentNode.Childrens.ContainsKey(c))
                {
                    currentNode.Childrens[c]= new TreeElemnt();
                }
                currentNode = currentNode.Childrens[c];
            }
            currentNode.LineNumber.Add(LineNumber);
        }

        private List<int> TreeSearch(TreeElemnt elemnt)
        {
            var result = new List<int>();
            result.AddRange(elemnt.LineNumber);
            if (elemnt.Childrens.Count != 0)
            {
                foreach (var item in elemnt.Childrens)
                {
                    result.AddRange(TreeSearch(item.Value));
                }
            }
            return result;
            //throw new NotImplementedException();
        }


        public List<int> GetMatching(string value)
        { 
            var currentNode= root;
            foreach (var c in value)
            {
                if(!currentNode.Childrens.ContainsKey(c))
                {
                    return new List<int>();
                }
                currentNode = currentNode.Childrens[c];   
            }

            var results= new List<int>();
            //results.AddRange(currentNode.LineNumber);
            results.AddRange(this.TreeSearch(currentNode));
            return results; 
        }
    }
}
