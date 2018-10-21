using System;
using System.Collections.Generic;
using System.Linq;
using TetrisKata.CrossCutting.Enums;
using TetrisKata.Pieces;
using TetrisKata.Pieces.Base;
using TetrisKata.Specification;

namespace TetrisKata
{
    public class Board
    {
        public IList<PieceBase> Pieces { get; set; }
        private int _width;
        private PieceInsideBoardSpecification _pieceInsideBoardSpecification;
        private ContainsCollidingBlockSpecification _containsCollidingBlocksSpecification;
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
        public int IncompleteLinesCount
        {
            get
            {
                return BoardLines.Where(bl => bl.HasAny).Count();
            }
        }
        public int FreeLinesCount
        {
            get
            {
                return BoardLines.Where(bl => !bl.Positions.Contains(true)).Count();
            }
        }
        public Board(int width, int height)
        {
            _width = width;
            Pieces = new List<PieceBase>();
            InitBoardLines(width, height);
            _pieceInsideBoardSpecification = new PieceInsideBoardSpecification(width, height);
            _containsCollidingBlocksSpecification = new ContainsCollidingBlockSpecification();
        }
        private void InitBoardLines(int width, int height)
        {
            _boardLines = new List<BoardLine>();
            for (int i = 0; i < height; i++)
            {
                _boardLines.Add(new BoardLine(width));
            }
        }
        
        public bool TryAdvance(int interval)
        {
            bool isMovePossible = IsMovePossible(Pieces.Last(), MoveDirection.Down, interval);
            if (isMovePossible)
            {
                Pieces[Pieces.Count - 1].Move(MoveDirection.Down, interval);
            }
            else
            {
                Pieces[Pieces.Count - 1].Stop();
                PieceToBoardBlocks(Pieces[Pieces.Count - 1]);
                ClearCompletedLines();
            }

            return isMovePossible;
        }

        public bool IsRotationPossible(PieceBase piece)
        {
            piece.Turn();
            if (_pieceInsideBoardSpecification.IsSatisfiedBy(piece))
            {
                //Todo bear in mind interva
                bool isCollision = FigureCollision(piece);
                return !isCollision;
            }
            else
            {
                //out of the board
                return false;
            }
        }
        public bool IsMovePossible(PieceBase piece, MoveDirection direction, int interval)
        {
            piece.Move(direction, interval);
            if (_pieceInsideBoardSpecification.IsSatisfiedBy(piece))
            {
                //Todo bear in mind interva
                bool isCollision = FigureCollision(piece);
                return !isCollision;
            }
            return false;
        }

        private bool FigureCollision(PieceBase piece)
        {
            bool isCollision = false;
            var currBoardPieceCollision = SnipPieceAreaFromBoardLines(piece);
            if (_containsCollidingBlocksSpecification.IsSatisfiedBy(currBoardPieceCollision))
            {
                isCollision = FigurePieceBlockCollsion(piece, currBoardPieceCollision);
            }
            return isCollision;
        }

        private static bool FigurePieceBlockCollsion(PieceBase piece, IList<List<bool>> currBoardPieceCollision)
        {
            var pieceBlockLines = piece.DecomposeCollisionMapInLinesOfBlocks();
            bool isCollision = false;
            int countY = 0;
            while (countY < pieceBlockLines.Count && !isCollision)
            {
                int max = pieceBlockLines[countY].Count;
                int countX = 0;
                while (countX < max && !isCollision)
                {
                    var pieceResult = pieceBlockLines[countY][countX];
                    var boarLineResult = currBoardPieceCollision[countY][countX];
                    isCollision = (pieceResult && boarLineResult);
                    countX++;
                }
                countY++;
            }

            return isCollision;
        }

        private IList<List<bool>> SnipPieceAreaFromBoardLines(PieceBase piece)
        {
            var bounding = piece.BoundingArea;
            var result = new List<List<bool>>();
            for (int y = 0; y < bounding.Height; y++)
            {
                var currBoardLine = BoardLines[bounding.Y + y];
                result.Add(currBoardLine.Positions.GetRange(bounding.X, bounding.Width));
            }
            return result;
        }

        private void PieceToBoardBlocks(PieceBase piece)
        {
            var bounding = piece.BoundingArea;
            IList<List<bool>> result = piece.DecomposeCollisionMapInLinesOfBlocks();
            for (int y = 0; y < bounding.Height; y++)
            {
                for (int x = 0; x < bounding.Width; x++)
                {
                    if (bounding.Y + y > 0 && bounding.Y + y < _boardLines.Count)
                    {
                        _boardLines[bounding.Y + y].Positions[bounding.X + x] = result[y][x];
                    }
                }
            }
        }
        private void ClearCompletedLines()
        {
            int count = 0;
            //max contiguous blocks in a piece
            int maxBlockIterations = 4;
            int blockCount = 0;

            while (count < BoardLines.Count)
            {
                //specification
                if (BoardLines[count].IsFull)
                {
                    _boardLines.RemoveAt(count);
                    _boardLines.Add(new BoardLine(_width));
                    if(blockCount<maxBlockIterations)
                    {
                        blockCount++;
                    }
                    else
                    {
                        count++;
                    }
                }
                else
                {
                    count++;
                }
            }
            string s = "clreared " + _boardLines.Count;
        }

        public void FreezeBoard()
        {
            if (Pieces.Count > 0)
            {
                Pieces[Pieces.Count - 1].Stop();
            }
        }
        public void AddPieceToBoard(PieceBase piece)
        {
            
            Pieces.Add(PlacePieceAtTopCenterOfBoard(piece));
            
        }

        private PieceBase PlacePieceAtTopCenterOfBoard(PieceBase piece)
        {
            piece.PosX = this._width / 2;
            //default rotation offset
            piece.PosY = 1;
            return piece;
        }

        public void AddRandomPieceToBoard()
        {
            /* 
             * At the beginning of the game a new piece will be created at the top center of the board. 
             * The shape of the piece will be random.
             */
            //Todo at the top center
            AddPieceToBoard(GenerateRandomPiece());
        }

        private PieceBase GenerateRandomPiece()
        {
            //Todo randomize
            return new LinePiece();
        }
    }
}
