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
            if (value <= root.value)
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

        public int CountNodesInRangeBST(Node root,int low, int high,int count)
        {
            if (root == null)
                return count;
            else
            {
                count = CountNodesInRangeBST(root.left,low,high,count);
                if (root.value >= low && root.value <= high)
                    count++;
                count = CountNodesInRangeBST(root.right, low, high, count);
            }
            return count;
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

            /*
            if (leftNode != null) // Right is null
                return CommonParent(root.left, n1, n2);
            else
                return CommonParent(root.right, n1, n2);
                */
            return (leftNode != null) ? leftNode : rightNode;
        }

        public void GetCommonParent(Node root, int n1, int n2)
        {
            Node CP = CommonParent(root, n1, n2);
            if (CP == null)
                Console.WriteLine("No Common Parent Found");
            else
                Console.WriteLine("Common Parent: " + CP.value);
        }

        public void GetSecondLargestElemOfBST(int[] arr)
        {
            Node root = MakeBSTFromArray(arr);
            Node SL = SecondLargestNode(root);
            if (SL == null)
                Console.WriteLine("Second Largest element not found");
            else
                Console.WriteLine("Second Largest element found as "+SL.value);

        }

        private Node SecondLargestNode(Node root)
        {
            //throw new NotImplementedException();
            if (root == null || (root.left == null && root.right == null))
                return null;
            if (root.right == null)
            {
                if (root.left.right == null)
                    return root.left;
                else
                    return ScndLargestFunc(root.left, null);
            }
            else
            {
                return ScndLargestFunc(root.right, root);
            }
        }

        private Node ScndLargestFunc(Node root, Node secLarge)
        {
            //throw new NotImplementedException();
            if (root.right == null)
            {
                if (secLarge == null)
                    return root;
                else
                    return secLarge;
            }
            if (secLarge == null)
                return ScndLargestFunc(root.right, secLarge);
            else
                return ScndLargestFunc(root.right, secLarge.right);
        }
    }


}
