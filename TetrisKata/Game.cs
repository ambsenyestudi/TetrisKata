using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisKata
{
    public class Game
    {
        private int _interval;

        public Board Board { get; }

        public Game(int width = 10, int height = 24)
        {
            _interval = 1;
            Board = new Board(width, height);
        }

        public void Advance()
        {
            var isAdvance = Board.TryAdvance(_interval);
            if (!isAdvance)
            {
                Board.AddRandomPieceToBoard();
            }
            
        }

        public void StopGame()
        {
            Board.FreezeBoard();
        }
        public void CreateNewPiece()
        {
            Board.AddRandomPieceToBoard();
        }

    }
}
