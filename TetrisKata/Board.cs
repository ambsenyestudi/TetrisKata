using System;
using System.Collections.Generic;
using System.Linq;
using TetrisKata.Pieces;

namespace TetrisKata
{
    public class Board
    {
        public IList<PieceBase> Pieces { get; set; }
        public bool IsActive
        {
            get
            {
                return Pieces.Count > 0 && Pieces.Last().IsActive;
            }
        }
        private IList<BoardLine> _boardLines;

        public IList<BoardLine> BoardLines
        {
            get { return _boardLines; }
        }
        public Board(int width, int height)
        {

            Pieces = new List<PieceBase>();
            InitBoardLines(width, height);
        }
        private void InitBoardLines(int width, int height)
        {
            _boardLines = new List<BoardLine>();
            for (int i = 0; i < height; i++)
            {
                _boardLines.Add(new BoardLine(width));
            }
        }

        public void Advance(int interval)
        {
            bool isMovePossible = false;

            //grounds for specification
            if (IsActive)
            {
                //move down
                isMovePossible = IsMovePossible(Pieces.Last(), MoveDirection.Down, interval);
                if (isMovePossible)
                {
                    Pieces[Pieces.Count - 1].Move(MoveDirection.Down, interval);
                }
                else
                {
                    Pieces[Pieces.Count - 1].Stop();
                }
            }
            if (!isMovePossible)
            {
                AddPieceToBoard();
            }
            
        }
        public bool IsMovePossible(PieceBase piece, MoveDirection direction, int interval)
        {
            if (direction == MoveDirection.Down)
            {
                //Todo check collision against lines
                var PosX = piece.PositionXY[0];
                var PosY = piece.PositionXY[1];
                var BoundingX = piece.BoundingBox[0];
                var BoundingY = piece.BoundingBox[1];

                //ground collision
                if (PosY + BoundingY >= _boardLines.Count)
                {
                    //Todo bear in mind intervar
                    return false;
                }
                else
                {
                    //if blocks in collition map 
                    return true;
                }
                
            }
            return false;
        }

        
        public void FreezeBoard()
        {
            if (Pieces.Count > 0)
            {
                Pieces[Pieces.Count - 1].Stop();
            }
        }
        public void AddPieceToBoard()
        {
            /* 
             * At the beginning of the game a new piece will be created at the top center of the board. 
             * The shape of the piece will be random.
             */
            //Todo at the top center
            Pieces.Add(GenerateRandomPiece());
        }

        private PieceBase GenerateRandomPiece()
        {
            //Todo randomize
            return new LinePiece();
        }
    }
}
