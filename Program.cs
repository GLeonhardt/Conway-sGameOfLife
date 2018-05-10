using System;
using System.Threading;

namespace Conway_sGameOfLife
{
    class Program
    {
        static int size = 30;
        static bool[,] Universe;
        static void Main(string[] args)
        {
           Universe = new bool[size, size];
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
            for(var i =0; i < size; i++)
            {
                for(var j =0; j < size; j++)
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
            Console.Clear();
            for(var i =0; i < size; i++)
            {
                for(var j =0; j < size; j++)
                {
                    Console.BackgroundColor = Universe[i,j] == true ? ConsoleColor.Red : ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Thread.Sleep(300);
        }

        public void AnalizeCell()
        {
            for(var i =0 ;i < size; i++)
            {
                for(var j = 0; j< size; j++)
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
                    if((i==posX && j == posY) || i<0 || j < 0 || i>= size || j>= size )
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