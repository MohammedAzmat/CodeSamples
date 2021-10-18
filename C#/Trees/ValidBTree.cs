using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class ValidBTree
    {
        //We do inorder travelsal and we keep track of prev node

        public bool IsValidTree(Node root, Node left, Node right)
        {
            if (root == null)
                return true;

            if (left != null && root.value <= left.value)
                return false;

            if (right != null && root.value >= right.value)
                return false;

            return IsValidTree(root.left, left, root) && IsValidTree(root.right, root, right );
        }
    }
}
