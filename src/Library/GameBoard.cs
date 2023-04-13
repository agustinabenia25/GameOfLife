using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class GameBoard
    {
        private bool[,] board;

        public GameBoard(int width, int height)
        {
            this.board = new bool[width,height];
        }
        public bool GetValue(int x, int y)
        {
            return this.board[x,y];
        }
        public void SetValue(int x, int y, bool value)
        {
            this.board[x,y] = value;
        }
        public int Width()
        {
            return this.board.GetLength(0);
        }
        public int Height()
        {
            return this.board.GetLength(1);
        }
        public GameBoard Clone()
        {
            GameBoard resultado = new GameBoard(this.Width(), this.Height());
            for (int x = 0; x < resultado.Width(); x++)
            {
                for (int y = 0; y < resultado.Height(); y++)
                {
                    resultado.SetValue(x, y, this.GetValue(x, y));
                }
            }
            return resultado;
        }
    }
}
