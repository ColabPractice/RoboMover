using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboMover
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 0;
            int xpos = 0;
            int ypos = 0;
            using (StreamReader sr = new StreamReader("RoboInfo.txt"))
            {
                try
                {
                    string[] firstline = sr.ReadLine().Split();
                    arraySize = Convert.ToInt32(firstline[0]);
                    xpos = Convert.ToInt32(firstline[1]);
                    ypos = Convert.ToInt32(firstline[2]);
                }
                catch { Console.WriteLine("File does not exsist or is an incorrect file"); }
            }

            int[,] grid = new int[arraySize, arraySize];
            
            using (StreamReader sr = new StreamReader("RoboInfo.txt"))
            {
                try
                {
                    sr.ReadLine();
                    for (int i = 0; i < arraySize; i++)
                    {
                        string[] fileline = sr.ReadLine().Split();
                        for (int j = 0; j < arraySize; j++)
                        {
                            grid[i, j] = Convert.ToInt32(fileline[j]);
                        }
                    }
                }
                catch { Console.WriteLine("Array Error"); }
            }

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
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();
                if (choice.KeyChar == 'w')
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
                if (choice.KeyChar == 's')
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
                if (choice.KeyChar == 'a')
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
                if (choice.KeyChar == 'd')
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
                if (choice.KeyChar == 'q')
                {
                    more = false;
                    Console.WriteLine("You have chosen to quit the game.");
                }
            }
        }
    }
}
