using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PII_Game_Of_Life
{
    // Creo una clase GameBoard que sepa toda la información sobre el tablero.
    public class GameBoard
    {
        private bool[,] board;
        // Método constructor que crea un tablero de dimensiones width x height.
        public GameBoard(int width, int height)
        {
            this.board = new bool[width,height];
        }
        // Método para averiguar el valor de una célula del tablero.
        public bool GetValue(int x, int y)
        {
            return this.board[x,y];
        }
        // Método para modificar el valor de una célula del tablero.
        public void SetValue(int x, int y, bool value)
        {
            this.board[x,y] = value;
        }
        // Método para obtener el ancho del tablero.
        public int Width()
        {
            return this.board.GetLength(0);
        }
        // Método para obtener el altura del tablero.
        public int Height()
        {
            return this.board.GetLength(1);
        }
        // Método para obtener un nuevo tablero clonado en base a otro.
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
