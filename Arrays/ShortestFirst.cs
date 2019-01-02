using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class MyPrioriQ
    {
        List<Elem> data;
        int deliveries = 0;

        public MyPrioriQ(int deliv)
        {
            data = new List<Elem>();
            deliveries = deliv;
        }
        public void Enqueue(Elem elem)
        {
            data.Add(elem);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = ci / 2;
                if (data[pi].SqrtValue < data[ci].SqrtValue) break;
                elem = data[ci];
                data[ci] = data[pi];
                data[pi] = elem;
                ci = pi;
            }
            if (data.Count > deliveries)
            {
                data.RemoveAt(data.Count - 1);
            }
            //Display();
        }

        private void Display()
        {
            Console.WriteLine();
            for (int i = 0; i < data.Count; i++)
                Console.Write("<" + data[i].Row + "," + data[i].Col + "> Value: "+data[i].SqrtValue+"\t");
        }

        public Elem Dequeue()
        {
            Elem elem = data[0];
            int li = data.Count - 1;
            data[0] = data[li];
            data.RemoveAt(li);
            li -= 1;
            int pi = 0;
            while (true)
            {
                int ci = 2 * pi + 1;
                if (ci > li) break;
                int rc = ci + 1;
                if (rc <= li && data[rc].SqrtValue < data[ci].SqrtValue)
                    ci = rc;
                if (data[pi].SqrtValue <= data[ci].SqrtValue) break;
                Elem item = data[ci];
                data[ci] = data[pi];
                data[pi] = item;
                pi = ci;
            }

            return elem;
        }

        public int Count { get { return data.Count; } }
    }

    public class Elem
    {
        private int x, y, squarredSum =0;

        public Elem(int[] arr)
        {
            this.x = arr[0];
            this.y = arr[1];
            this.squarredSum = x * x + y * y;
        }

        public double SqrtValue{get{return Math.Sqrt(this.squarredSum); } }
        public int Row { get{ return x; } }
        public int Col { get { return y; } }
    }
    public class ShortestFirst
    {
        private List<List<int>> ClosestDest(int dest, int[,] allLoc, int deliv)
        {
            if (allLoc == null || dest <= 0 || deliv <= 0) return null;
            List<List<int>> allDeliv = new List<List<int>>();
            MyPrioriQ Q = new MyPrioriQ(deliv);
            int[] minis = new int[deliv];
            for (int i = 0; i < dest; i++)
            {
                Q.Enqueue(new Elem(new int[] { allLoc[i, 0], allLoc[i, 1] }));
            }
            List<List<int>> output = new List<List<int>>();

            while (Q.Count > 0)
            {
                List<int> point = new List<int>();
                Elem elem = Q.Dequeue();
                point.Add(elem.Row);
                point.Add(elem.Col);
                output.Add(point);
                point = null;
            }
            return output;
        }

        public void GetDeliveryPoints(int dest, int[,] allLocations, int deliv)
        {
            List<List<int>> output = ClosestDest(dest, allLocations, deliv);
            string str = "\nPoints for " + deliv + " deliveries are: ";
            for (int i = 0; i < output.Count; i++)
                str += "<" + output[i][0] + "," + output[i][1] + ">, ";
            Console.WriteLine(str.Substring(0, str.Length - 2));
            
        }
    }
}
