using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class DupSubArr
    {
        public void DupSubTree(Node node)
        {
            GetDups(node, new Dictionary<string, int>());
        }
        private string GetDups(Node node, Dictionary<string, int> mymap)
        {
            if (node == null) return "";
            string str = "[";
            str += GetDups(node.left, mymap);
            str += node.value;
            str += GetDups(node.right, mymap);
            str += "]";

            if (mymap.ContainsKey(str) && mymap[str] == 1)
                Console.Write(str + "\t");
            if (mymap.ContainsKey(str))
                mymap[str] += 1;
            else
                mymap.Add(str, 1);
            return str;
        }
    }
}
