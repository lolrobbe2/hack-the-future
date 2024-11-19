using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_3_LABYRINTH
{
    public class ShortestPathFinder
    {
        // Checks if the cell is safe to move to
        private bool IsSafe(int[][] mat, bool[][] visited, int x, int y)
        {
            return (x >= 0 && x < mat.Length && y >= 0 && y < mat[0].Length) &&
                   mat[x][y] == 1 && !visited[x][y];
        }

        // Recursive DFS function to find the shortest path
        private void FindShortestPath(int[][] mat, bool[][] visited, int i, int j, int x, int y, ref int minDist, int dist)
        {
            // If destination is reached, update minimum distance
            if (i == x && j == y)
            {
                minDist = Math.Min(dist, minDist);
                return;
            }

            // Mark the current cell as visited
            visited[i][j] = true;

            // Move in all four directions: down, right, up, left
            if (IsSafe(mat, visited, i + 1, j))
            {
                FindShortestPath(mat, visited, i + 1, j, x, y, ref minDist, dist + 1);
            }
            if (IsSafe(mat, visited, i, j + 1))
            {
                FindShortestPath(mat, visited, i, j + 1, x, y, ref minDist, dist + 1);
            }
            if (IsSafe(mat, visited, i - 1, j))
            {
                FindShortestPath(mat, visited, i - 1, j, x, y, ref minDist, dist + 1);
            }
            if (IsSafe(mat, visited, i, j - 1))
            {
                FindShortestPath(mat, visited, i, j - 1, x, y, ref minDist, dist + 1);
            }

            // Backtrack: Unmark the current cell as visited
            visited[i][j] = false;
        }

        // Wrapper function to call the DFS function
        public int FindShortestPathLength(int[][] mat, Tuple<int, int> src, Tuple<int, int> dest)
        {
            // If matrix is empty or source/destination is blocked, return -1
            if (mat.Length == 0 || mat[src.Item1][src.Item2] == 0 || mat[dest.Item1][dest.Item2] == 0)
                return -1;

            int row = mat.Length;
            int col = mat[0].Length;

            // Initialize visited matrix
            bool[][] visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }

            int dist = int.MaxValue;

            // Start DFS from source
            FindShortestPath(mat, visited, src.Item1, src.Item2, dest.Item1, dest.Item2, ref dist, 0);

            // If a valid path is found, return the distance, otherwise return -1
            return dist != int.MaxValue ? dist : -1;
        }
    }
}
