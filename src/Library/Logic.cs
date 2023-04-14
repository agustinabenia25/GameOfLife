using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Logic
    {
        public static GameBoard Play(GameBoard tablero)
        {
            //bool[,] gameBoard = tablero.board;
            int boardWidth = tablero.Width();
            int boardHeight = tablero.Height();

            GameBoard cloneboard = tablero.Clone(); //new bool[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if(i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && tablero.GetValue(i,j))
                            {
                                aliveNeighbors = aliveNeighbors + 1;
                            }
                        }
                    }
                    if(tablero.GetValue(x,y))
                    {
                        aliveNeighbors = aliveNeighbors - 1;
                    }
                    if (tablero.GetValue(x,y) && aliveNeighbors < 2)
                    {
                        // Celula muere por baja poblacion
                        //Console.WriteLine($"Celula muere por baja población en {x},{y}. Vecinos {aliveNeighbors}");
                        cloneboard.SetValue(x,y,false);
                    }
                    if (tablero.GetValue(x,y) && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        //Console.WriteLine($"Celula muere por sobrepoblacion en {x},{y}. Vecinos {aliveNeighbors}");
                        cloneboard.SetValue(x,y,false);
                    }
                    if (!tablero.GetValue(x,y) && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        //Console.WriteLine($"Celula nace por reproduccion en {x},{y}. Vecinos {aliveNeighbors}");
                        cloneboard.SetValue(x,y,true);
                    }
                    /*
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard.SetValue(x,y,cloneboard.GetValue(x,y));
                    }
                    */
                }
            }
            tablero = cloneboard;
            return tablero;
        }
    }
}