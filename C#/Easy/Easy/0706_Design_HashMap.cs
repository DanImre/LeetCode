using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy
{
    public class Easy_706
    {
        public Easy_706()
        {

        }
        public class hashMapNode
        {
            public int value;
            public int key;
            public hashMapNode next;
            public hashMapNode()
            {
                key = -1;
                value = -1;
                next = null;
            }
            public hashMapNode(int value, int key)
            {
                this.value = value;
                this.key = key;
                next = null;
            }
        }
        public class MyHashMap
        {
            private hashMapNode[] array;
            public MyHashMap()
            {
                array = new hashMapNode[1000];
            }

            public void Put(int key, int value)
            {
                int actualIndex = key % array.Length;
                if (array[actualIndex] == null)
                    array[actualIndex] = new hashMapNode();

                hashMapNode curr = array[actualIndex];
                while (curr.next != null)
                    if (curr.key == key)
                    {
                        curr.value = value;
                        return;
                    }
                    else
                        curr = curr.next;

                if (curr.key == key)
                    curr.value = value;
                else
                    curr.next = new hashMapNode(value, key);
            }

            public int Get(int key)
            {
                int actualIndex = key % array.Length;
                if (array[actualIndex] == null)
                    array[actualIndex] = new hashMapNode();

                hashMapNode curr = array[actualIndex];
                while (curr != null)
                    if (curr.key == key)
                        return curr.value;
                    else
                        curr = curr.next;

                return -1;
            }

            public void Remove(int key)
            {
                int actualIndex = key % array.Length;
                if (array[actualIndex] == null)
                    array[actualIndex] = new hashMapNode();

                hashMapNode curr = array[actualIndex];
                while (curr.next != null)
                    if (curr.next.key == key)
                    {
                        curr.next = curr.next.next;
                        return;
                    }
                    else
                        curr = curr.next;
            }
        }
    }
}
