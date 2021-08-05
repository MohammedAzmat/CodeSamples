using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructures
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> data;
        int qSize;
        public PriorityQueue(int size = int.MaxValue)
        {
            data = new List<T>();
            qSize = size;
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = ci / 2;
                if (data[pi].CompareTo(data[ci]) <= 0) break;
                T elem = data[pi];
                data[pi] = data[ci];
                data[ci] = elem;
                ci = pi;
            }
            if (data.Count > qSize)
                data.RemoveAt(qSize);
        }

        public T Dequeue()
        {
            T elem = data[0];
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
                if (rc <= li && data[ci].CompareTo(data[rc]) > 0)
                    rc = ci;
                if (data[ci].CompareTo(data[pi]) > 0) break;
                T item = data[ci];
                data[ci] = data[pi];
                data[pi] = item;
                pi = ci;
            }

            return elem;
        }

        public int Count { get{ return data.Count; } }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < data.Count; i++)
                str += data[i].ToString() + " ";
            return str;
        }
    }
}
