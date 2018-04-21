/*
 * Folllowed solution mentioned in: http://brainatjava.blogspot.in/2017/03/total-number-of-possible-binary-search_26.html
 */


using System;
using System.Collections.Generic;

namespace IKStart
{
    class CountBstsWithNNodes
    {
        public void Run()
        {
            Test(0); // => 0
            Test(1); // => 1
            Test(2); // => 2
            Test(3); // => 5
            Test(4); // => 14
            Test(5); // => 42
            Test(20); // => 6564120420
            Test(50); // => 6564120420
        }

        void Test(int n)
        {
            Print(how_many_BSTs(n));
        }

        void Print(long n)
        {
            Console.WriteLine(n);
        }

        long how_many_BSTs(int n)
        {
            return CountBsts(n, new Dictionary<int,long>());
        }

        long CountBsts(int remaining, IDictionary<int, long> memo)
        {
            if (memo.ContainsKey(remaining))
            {
                return memo[remaining];
            }
            if (remaining < 0)
            {
                return 0;
            }
            if (remaining == 0 || remaining == 1)
            {
                return 1;
            }

            long sum = 0;

            for (var i = 1; i <= remaining; i++)
            {
                var leftTreeCount = CountBsts(i - 1, memo);
                var rightTreeCount = CountBsts(remaining - i, memo);
                sum += leftTreeCount * rightTreeCount;
            }

            memo.Add(remaining, sum);
            return sum;
        }
    }
}
