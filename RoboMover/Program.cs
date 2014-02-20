using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboMover
{
    public class RoboMover
    {

        private int arraySize = 0;
        private int xpos = 0;
        private int ypos = 0;
        private int[,] grid = new int[0, 0];

        public RoboMover()
        {
            //Read grid info from file
            try
            {
                using (StreamReader sr = new StreamReader("RoboInfo.txt"))
                {
                    string[] firstline = sr.ReadLine().Split();
                    arraySize = Convert.ToInt32(firstline[0]);
                    xpos = Convert.ToInt32(firstline[1]);
                    ypos = Convert.ToInt32(firstline[2]);

                    grid = new int[arraySize, arraySize];

                    for (int i = 0; i < arraySize; i++)
                    {
                        string[] fileline = sr.ReadLine().Split();
                        for (int j = 0; j < arraySize; j++)
                        {
                            grid[i, j] = Convert.ToInt32(fileline[j]);
                        }
                    }
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File does not exsist or is an incorrect file");
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                Environment.Exit(1);
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array Error");
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                Environment.Exit(1);
            }

            catch (Exception e)
            {
                Console.WriteLine("Unknown Error LOL");
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
                Environment.Exit(1);
            }

        }

        public void play()
        {
            bool more = true;
            grid[ypos, xpos] = 0;

            while (more)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        if (grid[i, j] == 1)
                            Console.Write(" ");
                        else if (grid[i, j] == 2)
                            Console.Write("█");
                        else if (grid[i, j] == 0)
                            Console.Write("☻");
                        else if (grid[i, j] == 4)
                            Console.Write("*");
                        //Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Which direction do you want to move?");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();

                if (choice.Key == ConsoleKey.W || choice.Key == ConsoleKey.UpArrow)
                {
                    more = move(ypos - 1, xpos, true);
                    //if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 1)
                    //{
                    //    grid[ypos, xpos] = 1;
                    //    grid[ypos - 1, xpos] = 0;
                    //    ypos--;
                    //}
                    //else if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 4)
                    //{
                    //    more = false;
                    //    Console.WriteLine("YOU HAVE WON");
                    //    Console.ReadKey();
                    //}
                }
                else if (choice.Key == ConsoleKey.S || choice.Key == ConsoleKey.DownArrow)
                {
                    more = move(ypos + 1, xpos, true);
                    //if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 1)
                    //{
                    //    grid[ypos, xpos] = 1;
                    //    grid[ypos + 1, xpos] = 0;
                    //    ypos++;
                    //}
                    //else if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 4)
                    //{
                    //    more = false;
                    //    Console.WriteLine("YOU HAVE WON");
                    //    Console.ReadKey();
                    //}
                }
                else if (choice.Key == ConsoleKey.A || choice.Key == ConsoleKey.LeftArrow)
                {
                    more = move(ypos, xpos -1, false);
                    //if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 1)
                    //{
                    //    grid[ypos, xpos] = 1;
                    //    grid[ypos, xpos - 1] = 0;
                    //    xpos--;
                    //}
                    //else if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 4)
                    //{
                    //    more = false;
                    //    Console.WriteLine("YOU HAVE WON");
                    //    Console.ReadKey();
                    //}
                }
                else if (choice.Key == ConsoleKey.D || choice.Key == ConsoleKey.RightArrow)
                {
                    more = move(ypos, xpos + 1, false);
                    //if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 1)
                    //{
                    //    grid[ypos, xpos] = 1;
                    //    grid[ypos, xpos + 1] = 0;
                    //    xpos++;
                    //}
                    //else if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 4)
                    //{
                    //    more = false;
                    //    Console.WriteLine("YOU HAVE WON");
                    //    Console.ReadKey();
                    //}
                }
                else if (choice.Key == ConsoleKey.Q)
                {
                    more = false;
                    Console.WriteLine("You have chosen to quit the game.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("YOU HAVE WON");
            Console.ReadKey();
        }

        //Attepmt to move to location, 
        //determine if possible and if winning move
        public bool move(int y, int x, bool vertical)
        {
            bool more = true;
            if (vertical
                && y >= 0
                && y < arraySize 
                && grid[y, x] == 1)
            {
                grid[ypos, x] = 1;
                grid[y, x] = 0;
                ypos = y;
            }
            else if (!vertical
                && x >= 0
                && x < arraySize 
                && grid[y, x] == 1)
            {
                grid[y, xpos] = 1;
                grid[y, x] = 0;
                xpos = x;
            }
            else if (vertical
                && y >= 0
                && y < arraySize 
                && grid[y, x] == 4)
            {
                more = false;
                //Console.WriteLine("YOU HAVE WON");
                //Console.ReadKey();
            }
            else if (!vertical
                && x >= 0 
                && x < arraySize 
                && grid[y, x] == 4)
            {
                more = false;
                //Console.WriteLine("YOU HAVE WON");
                //Console.ReadKey();
            }
            return more;
        }

        static void Main(string[] args)
        {
            new RoboMover().play();

            //int arraySize = 0;
            //int xpos = 0;
            //int ypos = 0;
            //int[,] grid = new int[0,0];
            

            ////Read grid info from file
            //try
            //{
            //    using (StreamReader sr = new StreamReader("RoboInfo.txt"))
            //    {
            //        string[] firstline = sr.ReadLine().Split();
            //        arraySize = Convert.ToInt32(firstline[0]);
            //        xpos = Convert.ToInt32(firstline[1]);
            //        ypos = Convert.ToInt32(firstline[2]);

            //        grid = new int[arraySize, arraySize];

            //        for (int i = 0; i < arraySize; i++)
            //        {
            //            string[] fileline = sr.ReadLine().Split();
            //            for (int j = 0; j < arraySize; j++)
            //            {
            //                grid[i, j] = Convert.ToInt32(fileline[j]);
            //            }
            //        }
            //    }
                
            //}
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine("File does not exsist or is an incorrect file");
            //    Console.WriteLine(e.StackTrace);
            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}

            //catch (IndexOutOfRangeException e)
            //{ 
            //    Console.WriteLine("Array Error");
            //    Console.WriteLine(e.StackTrace);
            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}

            //catch (Exception e)
            //{ 
            //    Console.WriteLine("Unknown Error LOL");
            //    Console.WriteLine(e.StackTrace);
            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}
            

            //old stuff
            //int[,] grid = new int[arraySize, arraySize];
            
            //using (StreamReader sr = new StreamReader("RoboInfo.txt"))
            //{
            //    try
            //    {
            //        sr.ReadLine();
            //        for (int i = 0; i < arraySize; i++)
            //        {
            //            string[] fileline = sr.ReadLine().Split();
            //            for (int j = 0; j < arraySize; j++)
            //            {
            //                grid[i, j] = Convert.ToInt32(fileline[j]);
            //            }
            //        }
            //    }
            //    catch { Console.WriteLine("Array Error"); }
            //}

            //bool more = true;
            //grid[ypos, xpos] = 0;

            //while (more)
            //{
            //    for (int i = 0; i < arraySize; i++)
            //    {
            //        for (int j = 0; j < arraySize; j++)
            //        {
            //            Console.Write(grid[i, j] + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine("Which direction do you want to move?");
            //    ConsoleKeyInfo choice = Console.ReadKey();
            //    Console.Clear();

            //    if (choice.Key == ConsoleKey.W || choice.Key == ConsoleKey.UpArrow)
            //    {
            //        if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 1)
            //        {
            //            grid[ypos, xpos] = 1;
            //            grid[ypos - 1, xpos] = 0;
            //            ypos--;
            //        }
            //        else if (ypos - 1 >= 0 && grid[ypos - 1, xpos] == 4)
            //        {
            //            more = false;
            //            Console.WriteLine("YOU HAVE WON");
            //            Console.ReadKey();
            //        }
            //    }
            //    if (choice.Key == ConsoleKey.S || choice.Key == ConsoleKey.DownArrow)
            //    {
                    
            //        if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 1)
            //        {
            //            grid[ypos, xpos] = 1;
            //            grid[ypos + 1, xpos] = 0;
            //            ypos++;
            //        }
            //        else if (ypos + 1 < arraySize && grid[ypos + 1, xpos] == 4)
            //        {
            //            more = false;
            //            Console.WriteLine("YOU HAVE WON");
            //            Console.ReadKey();
            //        }
            //    }
            //    if (choice.Key == ConsoleKey.A || choice.Key == ConsoleKey.LeftArrow)
            //    {
                    
            //        if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 1)
            //        {
            //            grid[ypos, xpos] = 1;
            //            grid[ypos, xpos - 1] = 0;
            //            xpos--;
            //        }
            //        else if (xpos - 1 >= 0 && grid[ypos, xpos - 1] == 4)
            //        {
            //            more = false;
            //            Console.WriteLine("YOU HAVE WON");
            //            Console.ReadKey();
            //        }
            //    }
            //    if (choice.Key == ConsoleKey.D || choice.Key == ConsoleKey.RightArrow)
            //    {
                    
            //        if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 1)
            //        {
            //            grid[ypos, xpos] = 1;
            //            grid[ypos, xpos + 1] = 0;
            //            xpos++;
            //        }
            //        else if (xpos + 1 < arraySize && grid[ypos, xpos + 1] == 4)
            //        {
            //            more = false;
            //            Console.WriteLine("YOU HAVE WON");
            //            Console.ReadKey();
            //        }
            //    }
            //    if (choice.Key == ConsoleKey.Q)
            //    {
            //        more = false;
            //        Console.WriteLine("You have chosen to quit the game.");
            //        Console.ReadKey();
            //    }
            //}
        }

        
    }
}
