using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class SubStrings
    {
        class CustomObject
        {
            public bool valid;
            public int start, end;
            public CustomObject()
            {
                valid = false;
                start = end = -1;
            }

        }

        public void Execute(string str)
        {
            List<string> mylist = GetAllSubstings(str);
            foreach (string s in mylist)
            {
                Console.Write(s + "\t");
            }


        }

        public void Execute(string str, char[] toBeIncluded)
        {
            List<string> mylist = GetAllSubstings(str,toBeIncluded);
            foreach (string s in mylist)
            {
                Console.Write(s + "\t");
            }
            Console.WriteLine(Contains(str, toBeIncluded).ToString());
        }

        private List<string> GetAllSubstings(string str)
        {
            List<string> mylist = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j =1; j <= str.Length-i; j++)
                {
                    mylist.Add(str.Substring(i, j));
                }
            }
            return mylist;
        }

        private List<string> GetAllSubstings(string str, int minSize)
        {
            List<string> mylist = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = minSize; j <= str.Length - i; j++)
                {
                    mylist.Add(str.Substring(i, j));
                }
            }
            return mylist;
        }

        private List<string> GetAllSubstings(string str, char[] toBeIncluded)
        {
            CustomObject cObj = IsValid(str, toBeIncluded);
            List<string> mylist = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = toBeIncluded.Length; j <= str.Length - i; j++)
                {
                    string mystr = str.Substring(i, j);
                    if (Contains(mystr, toBeIncluded))
                        mylist.Add(mystr);
                }
            }
            return mylist;
        }

        private bool Contains(string str, char[] toBeIncluded)
        {
            HashSet<char> map = new HashSet<char>();
            foreach (char c in toBeIncluded)
            {
                map.Add(c);
            }
            foreach (char c in str)
            {
                if (map.Contains(c))
                    map.Remove(c);
                if (map.Count == 0)
                    return true;
            }
            return false;
        }
        private CustomObject IsValid(string str, char[] toBeIncluded)
        {
            HashSet<char> map = new HashSet<char>();
            CustomObject ret = new CustomObject();
            foreach (char c in toBeIncluded)
            {
                map.Add(c);
            }
            for(int i=0;i<str.Length;i++)
            {
                if (map.Contains(str[i]))
                {
                    if (ret.start == -1)
                        ret.start = i;
                    map.Remove(str[i]);

                }
                if (map.Count == 0)
                {
                    ret.end = i;
                    ret.valid = true;
                    return ret;
                }
            }
            ret.valid = false;
            return ret;
        }
    }
}
