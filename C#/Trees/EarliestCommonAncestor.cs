using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    
    public class EarliestCommonAncestor
    {
        private class nAryTree
        {
            //Assuming value is an int
            private int val;
            private nAryTree[] parents;
            private nAryTree[] decendents;
            private Dictionary<int, int[]> myDict;
            private Dictionary<int, bool> visited;



            public int Value
            {
                set { val = value; }
                get { return val; }
            }

            public nAryTree()
            {
                if (1 == 1)
                {
                    myDict = new Dictionary<int, int[]>();
                    #region Values
                    myDict.Add(0, new int[] { 1, 2 });
                    myDict.Add(1, new int[] { 3, 4, 7 });
                    myDict.Add(2, new int[] { 5, 6 });
                    myDict.Add(3, new int[] { 8 });
                    myDict.Add(4, new int[] { 9, 10 });

                    myDict.Add(5, new int[] { 13 });
                    myDict.Add(6, new int[] { 14, 15, 16 });
                    myDict.Add(7, new int[] { 11, 12 });
                    myDict.Add(8, null);
                    myDict.Add(9, null);

                    myDict.Add(10, null);
                    myDict.Add(11, new int[] { 17, 18 });
                    myDict.Add(12, new int[] { 19 });
                    myDict.Add(13, new int[] { 20, 21 });
                    myDict.Add(14, new int[] { 22 });

                    myDict.Add(15, null);
                    myDict.Add(16, new int[] { 23, 24 });
                    myDict.Add(17, null);
                    myDict.Add(18, null);
                    myDict.Add(19, new int[] { 25 });

                    //myDict.Add(20, new int[] { 25 });
                    myDict.Add(20, null);
                    myDict.Add(21, null);
                    myDict.Add(22, new int[] { 26 });
                    myDict.Add(23, null);
                    myDict.Add(24, null);

                    myDict.Add(25, new int[] { 27 });
                    //myDict.Add(26, new int[] { 27 });
                    myDict.Add(26, null);
                    myDict.Add(27, null);
                    #endregion

                    visited = new Dictionary<int, bool>();
                    foreach (KeyValuePair<int, int[]> node in myDict)
                    {
                        visited.Add(node.Key, false);
                    }
                    //nAryTree myTree = makeSampleTree(myDict, 0);

                }
            }

            public nAryTree(int v)
            {
                this.Value = v;
            }


            public nAryTree makeSampleTree(int key)
            {
                nAryTree myTree;
                if (!visited[key])
                {
                    visited[key] = true;
                    myTree = new nAryTree(key);
                    if (myDict.ContainsKey(myTree.Value))
                    {
                        if (myDict[myTree.Value] == null)
                        {
                            myTree.decendents = null;
                        }
                        else
                        {
                            myTree.decendents = new nAryTree[myDict[myTree.Value].Length];
                            for (int i = 0; i < myDict[myTree.Value].Length; i++)
                            {
                                myTree.decendents[i] = makeSampleTree(myDict[myTree.Value][i]);
                                if (1 == 0 && myTree.decendents[i].parents.Length < 2)
                                {
                                    if (myTree.decendents[i].parents[0] == null)
                                    {
                                        myTree.decendents[i].parents[0] = myTree;
                                    }
                                    else
                                    {
                                        myTree.decendents[i].parents[1] = myTree;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //DFS to search
                    myTree = FetchNodeFromTree(key);
                }
                return myTree;
            }

            private nAryTree FetchNodeFromTree(int key)
            {
                throw new NotImplementedException();
            }

            public void displayTreePreOrder()
            {
                if (this.decendents == null)
                {
                    Console.Write(this.Value + " ");
                    return;
                }
                else
                {
                    Console.Write(this.Value + " ");
                    int n = this.decendents.Length;
                    for (int i = 0; i < n; i++)
                    {
                        this.decendents[i].displayTreePreOrder();
                    }
                }
            }
        }
        public void Test()
        {
            nAryTree sample = new nAryTree();
            sample = sample.makeSampleTree(0);
            sample.displayTreePreOrder();
        }

    }
}
