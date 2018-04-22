using System;
using System.Collections.Generic;

namespace IKStart
{
    internal class NQueens
    {
        public void Run()
        {
            Test(6);
        }

        private string[][] find_all_arrangements(int n)
        {
            var res = new List<string[]>();

            for (var i = 0; i < n; i++)
            {
                var grid = CreateEmptyGrid(n);

                grid[0][i] = "q";

                if (Find(grid, new List<int>() {i}, 1, n))
                {                    
                    res.Add(GetOutput(grid, n));
                }
                               
            }
            Console.WriteLine(res.Count + " different arrangements possible.");
            Print(res.ToArray(), n);
            return res.ToArray();
        }

        private bool Find(string[][] grid, List<int> cols, int row, int n)
        {
            if (cols.Count >= n)
            {
                return true;
            }
            
            for (var i = 0; i < n; i++)
            {
                if (IsValidPosition(cols, i))
                {
                    grid[row][i] = "q";
                    cols.Add(i);                    
                    return Find(grid, cols, row + 1, n);                    
                }
                else
                {
                    grid[row][i] = "-";
                }
            }
            return false;
        }

        private bool IsValidPosition(List<int> cols, int col)
        {
            var prevCol = cols[cols.Count - 1];
            return !cols.Contains(col) && col != prevCol +1 && col != prevCol -1;
        }

        private string[][] CreateEmptyGrid(int n)
        {
            var grid = new string[n][];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    grid[j] = new string[n];
                }
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    grid[i][j] = "-";
                }
            }

            return grid;
        }

        private string[] GetOutput(string[][] grid, int n)
        {
            var res = new string[n];

            for (var i = 0; i < n; i++)
            {                
                res[i] = string.Join("", grid[i]);
            }
            return res;
        }

        private void Test(int n)
        {
            find_all_arrangements(n);
        }

        private void Print(string[][] grid, int n)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.WriteLine(grid[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}