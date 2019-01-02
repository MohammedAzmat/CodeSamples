using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class PrioriQ
    {
        private List<Item> data;

        public PrioriQ()
        {
            data = new List<Item>();
        }

        public void Enqueue(Item item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = ci / 2;
                if (data[ci].Length >= data[pi].Length)
                    break;
                else
                {
                    item = data[ci];
                    data[ci] = data[pi];
                    data[pi] = item;
                    ci = pi;
                }
            }

        }

        public Item Dequeue()
        {
            Item item = data[0];
            int li = data.Count - 1;
            data[0] = data[li];
            data.RemoveAt(li);
            li -= 1;
            int pi = 0;
            while (true)
            {
                int ci = 2 * pi + 1; //lc : left child
                if (ci > li) break;//no children
                int rc = ci + 1;
                if (rc <= li && data[ci].Length > data[rc].Length) //Right Child exists and is smaller than left, then use right.
                    ci = rc;
                if (data[ci].Length >= data[pi].Length)
                    break;
                else
                {
                    Item item2 = data[ci];
                    data[ci] = data[pi];
                    data[pi] = item2;
                    pi = ci;
                }
            }

            return item;
        }

        public int Count { get { return data.Count; } }
    }

    public class Item
    {
        private int row = -1,col=-1,dist=0;
        
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        public int Length
        {
            get { return dist; }
            set { dist = value; }
        }

        public Item(int r, int c, int d)
        {
            this.col = c;
            this.row = r;
            this.dist = d;
        }
    }
    public class RobotTrenchObst
    {
        public int removeObs(int r, int c, int[,] lot)
        {
            if (r <= 0 || c <= 0 || lot == null) return -1;

            PrioriQ Q = new PrioriQ();
            HashSet<int[]> visited = new HashSet<int[]>();
            
            //0,0 is always flat
            Q.Enqueue(new Item(0, 0, 0));
            while (Q.Count > 0)
            {
                Item item = Q.Dequeue();
                //if(visited.Contains()
                int[] pair = new int[2];
                pair[0] = item.Row;
                pair[1] = item.Col;
                if (visited.Contains(pair))
                    continue;
                if (lot[pair[0],pair[1]] == 9)
                    return item.Length;
                visited.Add(pair);
                if (item.Row > 0 )
                    QueueUp(Q, lot, visited, new int[] { pair[0]-1,pair[1]}, item.Length + 1);
                if (item.Row < r-1)
                    QueueUp(Q, lot, visited, new int[] { pair[0]+1, pair[1] }, item.Length + 1);
                if (item.Col > 0)
                    QueueUp(Q, lot, visited, new int[] { pair[0], pair[1] -1}, item.Length + 1);
                if (item.Col < c -1)
                    QueueUp(Q, lot, visited, new int[] { pair[0], pair[1] +1}, item.Length + 1);
            }

            return -1;

        }

        private void QueueUp(PrioriQ Q, int[,] lot, HashSet<int[]> visited, int[] pair, int cost)
        {
            if (lot[pair[0],pair[1]] != 0 && !visited.Contains(pair))
            {
                Q.Enqueue(new Item(pair[0], pair[1], cost));
            }
        }
    }
}
