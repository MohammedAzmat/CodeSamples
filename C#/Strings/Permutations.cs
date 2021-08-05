using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Permutations
    {
        public List<string> Unique(string str, bool IsUnique = true)
        {
            if(IsUnique)
                return getPermutations(str);
            return getPermutations(str, new HashSet<string>());
        }

        private List<string> getPermutations(string str, HashSet<string> set = null)
        {
            int len = str.Length;
            List<string> perms = new List<string>();
            //set.Add(str);
            //throw new NotImplementedException();
            if (len == 0)
            {
                perms.Add("");
                return perms;
            } 
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string pre_c = str.Substring(0, i);
                string post_c = str.Substring(i + 1, len - pre_c.Length-1);
                List<string> remaining =null;
                if (set == null)
                    remaining = getPermutations(pre_c + post_c);
                else
                {
                    if (!set.Contains(pre_c + post_c))
                        remaining = getPermutations(pre_c + post_c);
                    

                }
                if (remaining != null)
                {
                    foreach (string ministr in remaining)
                    {
                        if (set == null)
                        {
                            perms.Add(ministr + c);
                        }
                        else
                        {
                            if (!set.Contains(ministr + c))
                            {
                                perms.Add(ministr + c);
                                set.Add(ministr + c);
                            }

                        }
                        
                    }
                }
            }
            return perms;


        }
        private int fact(int i, int[] arr)
        {
            if (i == 0 || i == 1) return i;
            if (arr[i] > 0) return arr[i];
            arr[i] = fact(i - 1,arr) * i;
            return arr[i];
        }

        public void PrintPerms(string str)
        {
            HashSet<char> set = new HashSet<char>();
            bool IsUnique = true;
            foreach (char c in str)
            {
                if (set.Contains(c))
                {
                    IsUnique = false;
                    break;
                }
                else
                    set.Add(c);
            }
            List<string> perms = Unique(str,IsUnique);
            Console.WriteLine("\n" + str + "\nPerms:");
            foreach (string s in perms)
            {
                Console.Write(" " + s);
            }
            Console.WriteLine();
        }
    }
}
