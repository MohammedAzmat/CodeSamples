using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class KSubstringWithK_1Unique
    {
        private List<string> GetSubStrings(string str, int subLen)
        {
            Dictionary<char, int> alphaValues = new Dictionary<char, int>();
            List<string> output = new List<string>();
            for (int i = 0; i < subLen; i++)
            {
                if (alphaValues.ContainsKey(str[i]))
                    alphaValues[str[i]] += 1;
                else
                    alphaValues.Add(str[i], 1);
            }
            if (alphaValues.Keys.Count == subLen - 1)
                output.Add(str.Substring(0, subLen));
            for (int i = subLen; i < str.Length; i++)
            {
                //Remove Exiting elem
                if (alphaValues[str[i - subLen]] > 1)
                    alphaValues[str[i - subLen]] -= 1;
                else
                    alphaValues.Remove(str[i - subLen]);

                //Add incoming
                if (alphaValues.ContainsKey(str[i]))
                    alphaValues[str[i]] += 1;
                else
                    alphaValues.Add(str[i], 1);

                if (alphaValues.Keys.Count == subLen - 1)
                    output.Add(str.Substring(i-subLen+1, subLen));
            }

            return output;

        }

        public void Printlist(string str, int sublen)
        {
            Console.WriteLine("\nInput String: " + str + " SubLen: " + sublen + "\nSubStrings: ");
            List<string> list = GetSubStrings(str, sublen);
            foreach (string substr in list)
            {
                Console.Write(substr + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
