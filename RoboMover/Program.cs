using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoboMover
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("RoboInfo.txt");
            string[] firstline = sr.ReadLine().Split();
            int arraySize = Convert.ToInt32(firstline[0]);
            int xpos = Convert.ToInt32(firstline[1]);
            int ypos = Convert.ToInt32(firstline[2]);
            int[,] grid = new int[arraySize, arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                string[] fileline = sr.ReadLine().Split();
                for (int j = 0; j < arraySize; j++)
                {
                    grid[i, j] = Convert.ToInt32(fileline[j]);
                }
            }
            sr.Close();

            bool more = true;
            grid[ypos, xpos] = 0;
            while (more)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Which direction do you want to move?");
                string choice = Console.ReadLine();
                Console.Clear();
                if (choice == "w")
                {
                    if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 4)
                    {
                        more = false;
                        Console.WriteLine("YOU HAVE WON");
                    }
                    if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 1)
                    {
                        grid[ypos, xpos] = 1;
                        grid[ypos - 1, xpos] = 0;
                        ypos--;
                    }
                }
                if (choice == "s")
                {
                    if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 4)
                    {
                        more = false;
                        Console.WriteLine("YOU HAVE WON");
                    }
                    if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 1)
                    {
                        grid[ypos, xpos] = 1;
                        grid[ypos + 1, xpos] = 0;
                        ypos++;
                    }
                }
                if (choice == "a")
                {
                    if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 4)
                    {
                        more = false;
                        Console.WriteLine("YOU HAVE WON");
                    }
                    if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 1)
                    {
                        grid[ypos, xpos] = 1;
                        grid[ypos, xpos - 1] = 0;
                        xpos--;
                    }
                }
                if (choice == "d")
                {
                    if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 4)
                    {
                        more = false;
                        Console.WriteLine("YOU HAVE WON");
                    }
                    if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 1)
                    {
                        grid[ypos, xpos] = 1;
                        grid[ypos, xpos + 1] = 0;
                        xpos++;
                    }
                }
            }
        }
    }
}
