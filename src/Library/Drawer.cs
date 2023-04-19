using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Drawer
    {
        // Inserto snippet de imprimir tablero.
        public static GameBoard BoardDrawer(GameBoard tablero)
        {
            int width = tablero.Width();
            int height = tablero.Height();
            while (true)
            {
                Console.Clear();
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
                // Invoco método para aplicar lógica del juego.
                tablero = Logic.Play(tablero);
                Thread.Sleep(100);
            }
        }
    }
}