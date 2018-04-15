using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IKStart
{
    class LRUCacheSolution
    {
        public void Run()
        {
            Test1();
        }

        void Test1()
        {
            var input = Array.ConvertAll(File.ReadAllLines("C:\\input.txt"), int.Parse);

            var capacity = input[0];
            var count = input[1];

            var query_type = new int[count];
            var key = new int[count];
            var value = new int[count];
            
            var i = 2;
            var index = 0;

            while (index < count)
            {
                query_type[index] = input[i];
                i++;
                index++;                
            }

            index = 0;
            i++;

            while (index < count)
            {
                key[index] = input[i];
                i++;
                index++;
            }

            index = 0;
            i++;

            while (index < count)
            {
                value[index] = input[i];
                i++;
                index++;
            }

            var sw = new Stopwatch();
            sw.Start();
            var result = implement_LRU_cache(capacity, query_type, key, value);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            var expOut = Array.ConvertAll(File.ReadAllLines("C:\\expOut.txt"), int.Parse);

            for (var j = 0; j < expOut.Length; j++)
            {
                if (result[j] != expOut[j])
                {
                    Console.WriteLine("MisMatch at: " + j + " Result: " + result[j] + " Expected: " + expOut[j]);
                }
            }
        }

        int[] implement_LRU_cache(int capacity, int[] query_type, int[] key, int[] value)
        {
            var cache = new LRUCache(capacity);
            var result = new List<int>();

            var max = long.MinValue;
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < query_type.Length; i++)
            {
                if (query_type[i] == 0)
                {                    
                    result.Add(cache.Get(key[i]));                    
                }
                else
                {                 
                    cache.Add(key[i], value[i]);                 
                }
                
                max = Math.Max(sw.ElapsedMilliseconds, max);
            }
            sw.Stop();
            Console.WriteLine(max);
            
            return result.ToArray();
        }
        public class LRUCache
        {
            class Node
            {
                public int Key;
                public int Value;
            }

            IDictionary<int, LinkedListNode<Node>> dict;
            int capacity;
            int size;
            LinkedList<Node> list;

            private void MoveToFront(LinkedListNode<Node> node)
            {                
                list.Remove(node);                
                list.AddFirst(node);
            }

            private void AddToFront(LinkedListNode<Node> node)
            {
                list.AddFirst(node);
            }

            private void DeleteFromCache()
            {
                var node = list.Last;
                list.RemoveLast();
                dict.Remove(node.Value.Key);
                size--;
            }

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                dict = new Dictionary<int, LinkedListNode<Node>>();
                list = new LinkedList<Node>();
            }

            public void Add(int key, int value)
            {                
                if (dict.ContainsKey(key))
                {
                    dict[key].Value.Value = value;
                    MoveToFront(dict[key]);
                }
                else
                {
                    if (size == capacity)
                    {
                        DeleteFromCache();
                    }
                    var node = new LinkedListNode<Node>(new Node
                    {
                        Key = key,
                        Value = value
                    });
                                        
                    dict.Add(key, node);                    
                    AddToFront(node);
                    size++;
                }
            }

            public int Get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    MoveToFront(dict[key]);
                    return dict[key].Value.Value;
                }

                return -1;
            }
        }
    }
}
