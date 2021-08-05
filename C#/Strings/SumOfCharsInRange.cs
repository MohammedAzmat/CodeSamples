using System;
using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class SumOfCharsInRange
    {
        //Get the sum of characters from a string in a given range.
        //We apply sliding window algo

        public void slidingWindowForCount(string str, int wSize)
        {
            //Size of Hashmap is size of Window never more than that.
            Dictionary<char, int> windowelem = new Dictionary<char, int>();
            int winnum = 0;
            //First Window
            for (int i = 0; i < wSize; i++)
            {
                if (windowelem.ContainsKey(str[i]))
                    windowelem[str[i]] += 1;
                else
                    windowelem.Add(str[i], 1);
            }
            //Display Window
            displayWindow(winnum++, windowelem);
            

            //For remaining window we update the hashmaps everytime

            for (int i = wSize; i < str.Length; i++)
            {
                //Remove Exiting element from the HashTable
                if (windowelem[str[i - wSize]] > 1)
                    windowelem[str[i - wSize]] -= 1;
                else
                    windowelem.Remove(str[i - wSize]);

                //Add/ Update incoming character
                if (windowelem.ContainsKey(str[i]))
                    windowelem[str[i]] += 1;
                else
                    windowelem.Add(str[i], 1);
                displayWindow(winnum++, windowelem);
            }
        }

        private void displayWindow(int winnum, Dictionary<char, int> windowelem)
        {
            Console.WriteLine("\n\nWindow #" + winnum);
            foreach (KeyValuePair<char, int> elem in windowelem)
                Console.WriteLine("Key: " + elem.Key + " : " + elem.Value);
        }
    }
}
