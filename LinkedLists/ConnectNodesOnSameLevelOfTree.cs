using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public  class MyNodes
    {
        int data;
        public MyNodes left, right, nextRight;

        public MyNodes(int v)
        {
            data = v;
            left = null;
            right = null;
            nextRight = null;
        }
    }
    public class ConnectNodesOnSameLevelOfTree
    {
        public MyNodes GenerateRandomTreeForProblem(int nodeCount)
        {
            return new MyNodes(0);
        }

        public MyNodes ConnectNodes(MyNodes root)
        {
            if (root != null)
            {
                Queue<MyNodes>[] myQs = new Queue<MyNodes>[2];
                myQs[0] = new Queue<MyNodes>();
                myQs[1] = new Queue<MyNodes>();
                myQs[0].Enqueue(root);
                int i = 0,j;
                while (myQs[i].Count > 0)
                {
                    bool first = true;
                    j = (i + 1) % 2;
                    MyNodes temp = null;
                    if (first)
                    {
                        first = false;
                        temp = myQs[i].Dequeue();
                        if (temp.left != null)
                            myQs[j].Enqueue(temp.left);
                        if (temp.right != null)
                            myQs[j].Enqueue(temp.right);
                    }
                    while (myQs[i].Count > 0)
                    {
                        temp.nextRight = myQs[i].Dequeue();
                        temp = temp.nextRight;
                        if (temp != null)
                        {
                            if (temp.left != null)
                                myQs[j].Enqueue(temp.left);
                            if (temp.right != null)
                                myQs[j].Enqueue(temp.right);
                        }
                    }
                    i = j;
                }
            }
            
            return root;
        }
    }
}
