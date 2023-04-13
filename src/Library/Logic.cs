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
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if(i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && cloneboard.GetValue(i,j))
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(cloneboard.GetValue(x,y))
                    {
                        aliveNeighbors--;
                    }
                    if (cloneboard.GetValue(x,y) && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard.SetValue(x,y,false);
                    }
                    else if (cloneboard.GetValue(x,y) && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard.SetValue(x,y,false);
                    }
                    else if (!cloneboard.GetValue(x,y) && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard.SetValue(x,y,true);
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard.SetValue(x,y,cloneboard.GetValue(x,y));
                    }
                }
            }
            return cloneboard;
        }
    }
}