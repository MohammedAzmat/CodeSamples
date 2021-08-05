using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BTtoBST
    {
        struct RootIndex
        {
            public Node root;
            public int Index;
        }
        private Node GenerateRandomBinaryTree()
        {
            Node[] nodes = new Node[11];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new Node(i);
            #region HARD CODED TRee
            nodes[0].left = nodes[1];
            nodes[0].right = nodes[2];

            nodes[1].left = nodes[3];
            nodes[1].right = nodes[4];

            nodes[2].left = nodes[5];
            nodes[2].right = nodes[6];

            nodes[4].left = nodes[7];
            nodes[4].right = nodes[8];

            nodes[5].right = nodes[9];

            nodes[6].left = nodes[10];

            #endregion

            return nodes[0];
        }

        private void Inorder(Node root)
        {
            if (root == null) return;
            Inorder(root.left);
            Console.Write(root.value + " ");
            Inorder(root.right);
        }

        private List<int> Inorder(Node root, List<int> arr)
        {
            if (root == null) return arr;
            arr = Inorder(root.left,arr);
            arr.Add(root.value);
            return Inorder(root.right,arr);
            //return arr;
        }

        private int Inorder(Node root, List<int> arr, int index)
        {
            if (root == null) return index;
            index = Inorder(root.left, arr,index);
            root.value = arr[index++];
            return Inorder(root.right, arr,index);
        }
        public BTtoBST()
        {
            Node root = GenerateRandomBinaryTree();
            Console.Write("\nInorder: ");
            Inorder(root);
            Console.WriteLine();
            List<int> arr = Inorder(root, new List<int>());
            arr.Sort();
            Inorder(root, arr, 0);
            Console.Write("\nInorder: ");
            Inorder(root);
            Console.WriteLine();
        }
    }
}
