using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node
    {
        public Node left, right;
        public int value;

        public Node(int val)
        {
            this.value = val;
            this.left = null;
            this.right = null;
        }

    }
    public class PathBetween2Nodes
    {
        public Node MakeBSTFromArray(int[] arr)
        {
            Node root = null;
            if (arr == null || arr.Length == 0)
                return root;
            for (int i = 0; i < arr.Length; i++)
                root = AddArrElemToTree2(root, arr[i]);
            return root;
        }

        private Node AddArrElemToTree(Node root, int value)
        {
            //Node temp = root;
            if (root == null)
            {
                return new Node(value);
            }
            else
            {
                if (value < root.value)
                {
                    if (root.left != null)
                        AddArrElemToTree(root.left, value);
                    else
                        root.left = new Node(value);
                }
                else
                {
                    if (root.right != null)
                        AddArrElemToTree(root.right, value);
                    else
                        root.right = new Node(value);
                }
            }

            return root;
        }

        private Node AddArrElemToTree2(Node root, int value)
        {
            //Node temp = root;
            if (root == null)
                return new Node(value);
            if (value < root.value)
                root.left = AddArrElemToTree2(root.left, value);
            else
                root.right = AddArrElemToTree2(root.right, value);
            return root;
        }

        public void InOrderTraversal(Node root)
        {
            if (root == null)
                return;
            else
            {
                InOrderTraversal(root.left);
                Console.Write(root.value + " ");
                InOrderTraversal(root.right);
            }
        }

        private Node CommonParentBST(Node root, int big, int small)
        {
            if (root == null)
                return root;
            if (root.value == big || root.value == small)
                return root;
            if (root.value > big) //Both Values are small
                return CommonParentBST(root.left, big, small);
            if (root.value < small)
                return CommonParentBST(root.right, big, small);

            //If Common Falls in between check if both nodes are present
            if (root.value <= big && root.value > small)
                if (Exists(root.left, small) && Exists(root.right, big))
                    return root;

            return null;
        }

        private bool Exists(Node root, int val)
        {
            //throw new NotImplementedException();
            if (root == null)
                return false;
            if (root.value == val)
                return true;
            if (root.value > val)
                return Exists(root.left, val);
            else
                return Exists(root.right, val);

        }

        public void TestPathDistanceBetweenNodesBST(Node root, int n1, int n2)
        {
            int big, small;
            if (n1 < n2)
            {
                small = n1; big = n2;
            }
            else
            {
                big = n1; small = n2;
            }
            Node CP_BST = CommonParentBST(root, big, small);
            if (CP_BST != null)
            {
                int dist = PathDistanceFromNodeBST(CP_BST, big, 0) + PathDistanceFromNodeBST(CP_BST, small, 0);
                Console.WriteLine("\nNodes: " + small + ", " + big + " Common Parent: " + CP_BST.value + "\tTotal Distance: " + dist);
            }
            else
            {
                int dist = PathDistanceFromNodeBST(CP_BST, big, 0) + PathDistanceFromNodeBST(CP_BST, small, 0);
                Console.WriteLine("\nNodes: " + small + ", " + big + " Common Parent: None\tTotal Distance: " + dist);
            }

            CP_BST = CommonParent(root, big, small);
            if (CP_BST != null)
            {
                int dist = PathDistanceFromNodeBST(CP_BST, big, 0) + PathDistanceFromNodeBST(CP_BST, small, 0);
                Console.WriteLine("\nNodes: " + small + ", " + big + " Common Parent: " + CP_BST.value + "\tTotal Distance: " + dist);
            }
            else
            {
                int dist = PathDistanceFromNodeBST(CP_BST, big, 0) + PathDistanceFromNodeBST(CP_BST, small, 0);
                Console.WriteLine("\nNodes: " + small + ", " + big + " Common Parent: None\tTotal Distance: " + dist);
            }

        }

        private int PathDistanceFromNodeBST(Node root, int val, int distance)
        {
            if (root == null)
                return -1;
            if (root.value == val)
                return distance;
            if (root.value > val)
                return PathDistanceFromNodeBST(root.left, val, distance + 1);
            else
                return PathDistanceFromNodeBST(root.right, val, distance + 1);
        }

        private Node CommonParent(Node root, int n1, int n2)
        {
            if (root == null)
                return root;
            if (root.value == n1 || root.value == n2)
                return root;
            Node leftNode = CommonParent(root.left, n1, n2);
            Node rightNode = CommonParent(root.right, n1, n2);

            if (leftNode != null && rightNode != null)
                return root;

            if (leftNode != null) // Right is null
                return CommonParent(root.left, n1, n2);
            else
                return CommonParent(root.right, n1, n2);
        }
    }


}
