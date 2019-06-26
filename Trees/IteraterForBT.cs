using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public interface BTIterater
    {
        bool HasNext();
        Node Next();
    }
    public class IteraterForBT : BTIterater
    {
        Node cur;
        Stack<Node> parents;

        public IteraterForBT(Node root)
        {
            InitializeCur(root);
        }

        public IteraterForBT()
        {
            int[] arr = { 13, 7, 2, 1, 6, 5, 4, 3, 8, 9, 10, 11, 12, 14 };
            PathBetween2Nodes obj = new PathBetween2Nodes();
            Node root = obj.MakeBSTFromArray(arr);
            obj.InOrderTraversal(root);
            parents = new Stack<Node>();
            InitializeCur(root);
        }

        private void InitializeCur(Node root)
        {
            //Initilize Current to get first element of In order
            cur = root;
            while (cur.left != null)
            {
                parents.Push(cur);
                cur = cur.left;
            }
        }
        public bool HasNext()
        {
            /*
            //if root and we have to go right
            if (cur.right != null) return true;
            //check if it is a left child then we check parent as next
            if (parents.Count > 0 && cur == parents.Peek().left) return true;
            //check if it is right child then we 
            if (parents.Count > 0 && cur == parents.Peek().left.right) return true;
            return false;
            */
            return (cur.right != null || (parents.Count > 0)) ? true : false;
        }

        public Node Next()
        {
            if (cur.right != null)
            {
                cur = cur.right;
                while (cur.left != null)
                {
                    parents.Push(cur);
                    cur = cur.left;
                }
            }
            else if (parents.Count > 0)
                cur = parents.Pop();
            /*
            else if (parents.Count > 0 && cur == parents.Peek().left)
                cur = parents.Pop();
            else if (parents.Count > 0 && cur == parents.Peek().left.right)
                cur = parents.Pop();
                */
            return cur;
        }

        public void Test()
        {
            //Create a BST
            
        }
    }
}
