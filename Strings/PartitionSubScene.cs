using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class SubScene
    {
        public int Start, End;
        public char lable;

        public SubScene(char cut,int index)
        {
            this.Start = index;
            this.End = index;
            this.lable = cut;
        }
        public SubScene( int index)
        {
            this.Start = index;
            this.End = index;
        }
    }
    public class PartitionSubScene
    {
        public List<int> GroupCutsTogether(char[] arr)
        {
            List<char> cuts = new List<char>();
            List<int> sceneLength = new List<int>();
            Dictionary<char, SubScene> hash = new Dictionary<char, SubScene>();
            HashSet<char> set = new HashSet<char>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (hash.ContainsKey(arr[i]))
                {
                    //Update End Value of SubScene
                    hash[arr[i]].End = i;
                }
                else
                {
                    //Create a new Subscene
                    hash.Add(arr[i], new SubScene(i));
                    cuts.Add(arr[i]);
                }
            }
            int cutStart = -1, cutEnd =-1,oldEnd = -1;
            foreach (char elem in cuts)
            {
                if (cutStart == -1)
                {
                    cutStart = hash[elem].Start;
                    cutEnd = hash[elem].End;
                }
                else
                {
                    if (hash[elem].Start <= cutEnd)
                    {
                        //a sub is in the middle update Cut End if needed
                        if (hash[elem].End > cutEnd)
                            cutEnd = hash[elem].End;
                    }
                    else
                    {
                        //New Scene
                        sceneLength.Add(cutEnd - cutStart + 1);
                        oldEnd = cutEnd;
                        cutStart = hash[elem].Start;
                        cutEnd = hash[elem].End;
                    }
                }
            }
            if (oldEnd != cutEnd)
                sceneLength.Add(cutEnd - cutStart + 1);
            return sceneLength;
        }

        public void PrintSubScenes(char[] v)
        {
            Console.WriteLine("\nGiven Ary: ");
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + ", ");
            }
            List<int> list = GroupCutsTogether(v);
            Console.Write("\nPartition: ");
            foreach (int i in list)
            {
                Console.Write(i + ", ");

            }
        }
    }
}
