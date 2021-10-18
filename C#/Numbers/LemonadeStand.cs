using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    /// <summary>
    /// Lemonade Costs 5 bucks, can be paid in 5,10,20.
    /// We need to give exact change back to the customer. 
    /// Return True if we can give it to all. False if even one customer is unserved. 
    /// We start with 0 money
    /// </summary>
    public class LemonadeStand
    {

        public bool CanServiceCustomers(int[] queue)
        {
            int fives=0, tens=0, twenties = 0;
            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i] == 5)
                {
                    fives++;
                }
                else if (queue[i] == 10)
                {
                    if (fives > 0)
                        fives--;
                    else
                        return false;
                }
                else 
                {
                    twenties++;
                    if (tens > 0 && fives > 0)
                    {
                        tens--;
                        fives--;
                    }
                    else if (fives > 2)
                    {
                        fives -= 3;
                    }
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
