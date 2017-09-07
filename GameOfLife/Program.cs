using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static int tamX = 30;
        static int tamY = 60;
        static bool[,] Universe;
        static void Main(string[] args)
        {
           Universe = new bool[tamX, tamY];
           CreateUniverse();
           ShowUniverse();
           Program p = new Program();
           while(true)
           {
                p.AnalizeCell();                   
           }
                      
        }
        public static void CreateUniverse()
        {
            System.Random rd = new System.Random();
            for(var i =0; i < tamX; i++)
            {
                for(var j =0; j < tamY; j++)
                {
                    if(rd.Next(0,9) == 0)
                    {
                        Universe[i,j] = true;    
                    }else{
                        Universe[i,j] = false;
                    }
                    
                }
            }
        }

        public static void ShowUniverse()
        {
            Console.ResetColor();
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine();
            for(var a = 0;a<= tamY+1; a++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            for(var i =0; i < tamX; i++)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                for(var j =0; j <= tamY; j++)
                {
                    if(j != tamY)
                    {
                        if(Universe[i,j] == false)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                        }else{
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(" ");
                        }
                    }else{
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                }
                
            }
            Console.WriteLine();
            for (var k = 0; k<= tamY+1; k++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            Thread.Sleep(300);
        }

        public void AnalizeCell()
        {
            for(var i =0 ;i < tamX; i++)
            {
                for(var j = 0; j< tamY; j++)
                {
                    if(Universe[i, j] == true)
                    {
                        var alive = CountAlive(i,j);
                        if(alive <2 || alive >3)
                        {
                            Universe[i,j] = false;
                        }else{
                            Universe[i,j] = true;
                        }
                    }else{
                        var alive = CountAlive(i,j);
                        if(alive == 3){
                            Universe[i,j] = true;
                        }
                    }
                }
            }
            ShowUniverse();
        }

        public int CountAlive(int posX, int posY)
        {
            var alive = 0;
            for(var i= posX-1;i <= posX+1;i++)
            {
                for(var j=posY-1;j<=posY+1;j++)
                {
                    if((i==posX && j == posY) || i<0 || j < 0 || i>= tamX || j>= tamY )
                        continue;
                    if(Universe[i,j]== true){
                        alive++;
                    }
                }
            }
            return alive;
        }
    }
}