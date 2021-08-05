using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class HouseActiveInActive
    {
        private int[] HouseState(int[] arr, int days)
        {
            int prevState = -1;
            while (days > 0)
            {
                days--;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        prevState = arr[i];
                        if (arr[i + 1] == 1)
                            arr[i] = 1;
                        else
                            arr[i] = 0;
                    }
                    else if (i == arr.Length - 1)
                    {

                        if (prevState == 1)
                        {
                            prevState = arr[i];
                            arr[i] = 1;
                        }
                        else
                        {
                            prevState = arr[i];
                            arr[i] = 0;
                        }
                    }
                    else if (prevState != arr[i + 1])
                    {
                        prevState = arr[i];
                        arr[i] = 1;
                    }
                    else
                    {
                        prevState = arr[i];
                        arr[i] = 0;
                    }
                }
            }
            return arr;
        }
        private void PrintState(int[] arr)
        {
            Console.Write("\nCurrent State: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write("\t" + arr[i]);
            Console.Write("\n");
        }

        public void Initiate(int[] arr, int days)
        {
            PrintState(arr);
            HouseState(arr, days);
            PrintState(arr);
        }
    }
}
