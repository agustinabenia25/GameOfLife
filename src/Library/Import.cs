using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Import
    {
        public static GameBoard ImportBoard(string ruta)
        {
            string url = ruta;
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            GameBoard board = new GameBoard(contentLines.Length, contentLines[0].Length);

            for (int  y=0; y<contentLines.Length;y++)
            {
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        board.SetValue(x,y,true);
                    }
                }
            }
            return board;
        }
    }
}