using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Drawer
    {
        public static GameBoard BoardDrawer(GameBoard tablero)
        {
            int width = tablero.Width();
            int height = tablero.Height();
            int count = 0;
            while (count < 2)
            {
                Console.WriteLine($"Nueva jugada, height {height} width {width}");
                //Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<height;y++)
                {
                    for (int x = 0; x<width; x++)
                    {
                        if(tablero.GetValue(x,y))
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                tablero = Logic.Play(tablero);
                Thread.Sleep(600);
                count++;
            }
            return tablero;
        }
    }
}