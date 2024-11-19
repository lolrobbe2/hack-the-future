using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Involved.HTF.Common.Dto
{
    public class MazeDTO
    {
        public string[][] Maze {  get; set; }
        public short[,] MapMazeToshortArray()
        {
            // Get the number of rows and columns
            int rows = Maze.Length;
            int columns = Maze[0].Length;

            // Initialize the ushort array to hold the mapped values
            short[,] mappedMaze = new short[rows, columns];

            // Loop through each cell in the maze
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Get the current character
                    string currentChar = Maze[i][j];

                    // Map based on the character
                    if (currentChar.Equals("#"))
                    {
                        mappedMaze[i, j] = 0;
                    }
                    else if (currentChar.Equals("·"))
                    {
                        mappedMaze[i, j] = 1;
                    }
                    else if (currentChar.Equals(""))
                    {
                        mappedMaze[i, j] = 0;
                    }
                    else if (currentChar.Equals("S") || currentChar.Equals("E"))
                    {
                        mappedMaze[i, j] = 1;
                    }
                }
            }

            // Return the mapped ushort array
            return mappedMaze;
        }

        public int[] getStart()
        {
            for (int x = 0; x < Maze.Length; x++)
            {
                for(int y = 0; y < Maze[x].Length; y++) 
                {
                    if (Maze[x][y] == "S") return [x,y];
                }
            }
            Console.WriteLine("oops");
            return [0,0];
        }
        public int[] getEnd()
        {
            for (int x = 0; x < Maze.Length; x++)
            {
                for (int y = 0; y < Maze[x].Length; y++)
                {
                    if (Maze[x][y] == "E") return [x, y];
                }
            }
            Console.WriteLine("oops");
            return [0, 0];
        }
    }

}
