using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class GCD
    {

        // Function to return gcd of a and b 
        private int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        // Function to find gcd of  
        // array of numbers 
        public int findGCD(int[] arr, int n)
        {
            int result = arr[0];
            for (int i = 1; i < n; i++)
                result = gcd(arr[i], result);

            return result;
        }

        // Driver Code 
        
    }
}
