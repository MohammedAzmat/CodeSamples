using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class DoubleLinkedList : IDisposable
    {
        int key, value;
        DoubleLinkedList prev, next;
        private bool disposed = false;

        #region GetterSetter
        public int Key
        {
            get { return key; }
        }
        public int Value
        {
            get { return value; }
        }
        public DoubleLinkedList Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public DoubleLinkedList Next
        {
            get { return next; }
            set { next = value; }
        }
        #endregion
        public DoubleLinkedList(int k, int v)
        {
            key = k;
            value = v;
            prev = null;
            next = null;
        }

        #region Dispose and Deletion
        ~DoubleLinkedList()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                

                // Note disposing has been done.
                disposed = true;

            }
        }

        #endregion
    }
    public class LRUCache
    {
        Dictionary<int, DoubleLinkedList> cacheMap;
        int capacity, curSize;
        DoubleLinkedList head, tail;
        public LRUCache(int size)
        {
            capacity = size;
            curSize = 0;
            cacheMap = new Dictionary<int, DoubleLinkedList>();
            head = new DoubleLinkedList(0, 0);
            //tail = new DoubleLinkedList(0, 0);
            head.Next = head;
            head.Prev = head;
        }
        private void remove(DoubleLinkedList oldest)
        {
            oldest.Prev.Next = oldest.Next;
            oldest.Next.Prev = oldest.Prev;
            
        }
        private void Add(DoubleLinkedList newest)
        {
            newest.Next = head;
            head.Prev.Next = newest;
            newest.Prev = head.Prev;
            head.Prev = newest;
        }
        private void Display()
        {
            DoubleLinkedList cur = head.Next;
            Console.Write("Cache State: ");
            while (cur != head)
            {
                Console.Write(cur.Value + " ");
                cur = cur.Next;
            }
            Console.Write("\n");
        }
        public void Process(int[] inputArr)
        {
            foreach (int elem in inputArr)
            {
                Console.Write("\n\nBefore Adding the Element: " + elem + "\nCurrent ");
                Display();
                if (cacheMap.ContainsKey(elem))
                {
                    remove(cacheMap[elem]);
                    Add(cacheMap[elem]);
                }
                else
                {
                    if (curSize == capacity)
                    {
                        cacheMap.Remove(head.Next.Key);
                        remove(head.Next);
                        DoubleLinkedList newest = new DoubleLinkedList(elem, elem);
                        Add(newest);
                        cacheMap.Add(elem, newest);
                    }
                    else
                    {
                        DoubleLinkedList newest = new DoubleLinkedList(elem, elem);
                        Add(newest);
                        cacheMap.Add(elem, newest);
                        curSize++;
                    }
                }
                Console.Write("After Adding ");
                Display();
                
            }
        }

    }
}
