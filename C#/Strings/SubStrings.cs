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
        private CustomObject IsValidToo(string str, char[] target)
        {
            
            CustomObject obj = new CustomObject();
            if (str == null || target == null || target.Length <= 0 || str.Length <= 0 ) return obj;
            Dictionary<char, int> dict = FillDict(target);
            Dictionary<char, int> window = new Dictionary<char, int>();
            int uniqueLen = dict.Count;
            int strLen = 0, winStart = 0;
            for (int i = 0; i < str.Length; i++)
            {
                //Expand Window
                if (window.ContainsKey(str[i]))
                    window[str[i]] += 1;
                else
                    window.Add(str[i], 1);

                //Check
                if (dict.ContainsKey(str[i]) && (dict[str[i]] == window[str[i]]))
                    strLen++;

                while (winStart <= i && strLen == uniqueLen)
                {
                    //update Custom obj based on length or first found
                    if (obj.valid == false || ((i-winStart) < (obj.end - obj.start)))
                    {
                        obj.valid = true;
                        obj.start = winStart;
                        obj.end = i;
                    }
                    if (window.ContainsKey(str[winStart]))
                    {
                        if (window[str[winStart]] > 1)
                            window[str[winStart]] -= 1;
                        else
                            window.Remove(str[winStart]);
                    }
                    if (dict.ContainsKey(str[winStart]) && window.ContainsKey(str[winStart]) && window[str[winStart]] < dict[str[winStart]])
                        strLen--;
                    else
                    {
                        if (dict.ContainsKey(str[winStart]) && !window.ContainsKey(str[winStart]))
                            strLen--;
                    }
                    winStart++;
                }

            }
            return obj;

        }
        private Dictionary<char, int> FillDict(char[] target)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < target.Length; i++)
            {
                if (dict.ContainsKey(target[i]))
                    dict[target[i]] += 1;
                else
                    dict.Add(target[i], 1);
            }
            return dict;
        }

        public void GetStrings(string str, char[] target)
        {
            //Getif sting contains all the target chars
            CustomObject obj = IsValidToo(str, target);
            if (obj.valid)
            {
                //proceed
                Console.WriteLine("\n\t**** All Target Chars Found ****\nString: " + str + "\t Chars: " + String.Join(" ", target)+"\n");
                List<string> subs = GetAllSubstings(str, obj);
                foreach (string s in subs)
                {
                    Console.Write(s + "\t");
                }
            }
            else
            {
                Console.WriteLine("\n----------\tAll target characters were not found in the given string\t-----------\n");
                Console.Write("String: " + str + "\t Chars: " + String.Join(" ", target) + "\n");
            }
        }

        private List<string> GetAllSubstings(string str, CustomObject obj)
        {
            List<string> subs = new List<string>();
            if (obj.valid)
            {
                int i = obj.start, j = obj.end;
                while (i >= 0 && j < str.Length)
                {
                    while(j++<str.Length)
                        subs.Add(str.Substring(i, j - i));
                    j = obj.end;
                    i--;
                }
            }
            return subs;
        }
    }
}
