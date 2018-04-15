using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IKStart
{
    internal class MaxInSlidingWindow
    {
        public void Run()
        {
            Test1();
            var input = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var expOut = new int[] { 9, 8, 7, 6, 5, 4 , 3, 2, 1};            
            Test2(input, expOut, 1);


            input = new int[] { 9, 7, 6, 5, 8, 4, 3, 2, 1 };
            expOut = new int[] { 9, 8, 8, 8, 8, 4 };            
            Test2(input, expOut, 4);
        }
        
        public int[] max_in_sliding_window(int[] input, int w)
        {
            var result = new List<int>();
            var list = new LinkedList<int>();

            for (var i = 0; i < input.Length; i++)
            {
                var removed = i >= w ? input[i - w] : int.MinValue;
                UpdateList(list, removed, input[i]);

                // Add to result starting the first time the window size is reached
                if (i >= w - 1)
                {
                    result.Add(list.First.Value);
                }
            }

            return result.ToArray();
        }

        public void UpdateList(LinkedList<int> list, int removed, int added)
        {
            if (removed > int.MinValue && removed == list.First.Value)
            {
                list.RemoveFirst();
            }

            if (list.Count == 0 || list.First.Value < added)
            {
                list.Clear();
                list.AddFirst(added);
            }
            else if (list.Last.Value < added)
            {
                while (list.Last.Value < added)
                {
                    list.RemoveLast();
                }

                list.AddLast(added);
            }
            else
            {
                list.AddLast(added);
            }            
        }


        /*private int[] max_in_sliding_window(int[] input, int w)
        {            
            var result = new List<int>();
            var max = int.MinValue;
            var nextMax = int.MinValue;
            var i = 0;            

            // Move second pointer w items ahead
            for (i = 0; i < w; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
                else if (input[i] == max || input[i] > nextMax)
                {
                    nextMax = input[i];
                }
            }
            result.Add(max);

            while (i < input.Length)
            {
                var dropped = input[i - w];
                var added = input[i];

                if (dropped == max)
                {
                    max = nextMax;
                    nextMax = added;
                }

                if (added > max)
                {
                    max = added;
                    nextMax = int.MinValue;
                }
                else if (added > nextMax)
                {
                    nextMax = added;
                }

                result.Add(max);
                i++;
            }

            return result.ToArray();
        }*/

        private void Test1()
        {
            var input = Array.ConvertAll(File.ReadAllLines("C:\\input.txt"), int.Parse);
            var expOut = Array.ConvertAll(File.ReadAllLines("C:\\expOut.txt"), int.Parse);

            var w = input[input.Length - 1];

            input = input.Skip(1).Reverse().Skip(1).Reverse().ToArray();

            var result = max_in_sliding_window(input, w);

            for (var i = 0; i < result.Length; i++)
            {
                if (result[i] == expOut[i])
                {
                    continue;
                }

                Console.WriteLine("Mismatch at : " + i);
                Console.WriteLine(result[i] + " " + expOut[i]);
                break;
            }
        }

        private void Test2(int[] input, int[] expOut, int w)
        {
            var result = max_in_sliding_window(input, w);

            Print(input);
            Print(expOut);
            Print(result);

            for (var i = 0; i < expOut.Length; i++)
            {
                if (result[i] == expOut[i])
                {
                    continue;
                }

                Console.WriteLine("Mismatch at : " + i);
                Console.WriteLine(result[i] + " " + expOut[i]);
                break;
            }
        }

        private void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}