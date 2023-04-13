using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = Import.ImportBoard(@"..\..\assets\board.txt");
            GameBoard tablero = Drawer.BoardDrawer(board);
        }
    }
}
