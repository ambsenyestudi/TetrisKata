using System;
using System.Collections.Generic;
using System.Linq;
using TetrisKata.Pieces;

namespace TetrisKata
{
    public class Board
    {
        public IList<PieceBase> Pieces { get; set; }
        private int _width;
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
                    PieceToBoardBlocks(Pieces[Pieces.Count - 1]);
                    ClearCompletedLines();
                }
            }
            if (!isMovePossible)
            {
                AddRandomPieceToBoard();
            }
        }
        
        public bool IsMovePossible(PieceBase piece, MoveDirection direction, int interval)
        {
            if (direction == MoveDirection.Down)
            {
                //Todo check collision against lines
                var posX = piece.PositionXY[0];
                var posY = piece.PositionXY[1] + interval;
                var boundingX = piece.BoundingBox[0];
                var boundingY = piece.BoundingBox[1];

                //inside Board
                if (posY + boundingY <= _boardLines.Count)
                {
                    
                    //Todo bear in mind interva
                    int count = 0;
                    bool isCollision = false;
                    while (count < boundingY && !isCollision)
                    {
                        var currLineIndex = posY + count;
                        var currBoardCollsionLine = BoardLines[currLineIndex].Positions.GetRange(posX, boundingX);

                        //this line might have a collision block
                        if (currBoardCollsionLine.Contains(true))
                        {
                            IList<List<bool>> pieceCollisioMapLines = piece.DecomposeCollisionMapInLinesOfBlocks();
                            var currPieceCollisionLine = pieceCollisioMapLines[count];
                            for (int x = 0; x < currBoardCollsionLine.Count; x++)
                            {
                                if (currBoardCollsionLine[x] && currBoardCollsionLine[x])
                                {
                                    isCollision = true;
                                }
                            }
                        }
                        count++;
                    }
                    return !isCollision;
                }
                else
                {
                    //out of the board
                    return false;
                }
            }
            return false;
        }
        private void PieceToBoardBlocks(PieceBase piece)
        {
            IList<List<bool>> result = piece.DecomposeCollisionMapInLinesOfBlocks();
            for (int linesIndex = 0; linesIndex < result.Count; linesIndex++)
            {
                var currLine = result[linesIndex];
                for (int blockIndex = 0; blockIndex < currLine.Count; blockIndex++)
                {
                    var pieceX = piece.PositionXY[0];
                    var pieceY = piece.PositionXY[1];
                    _boardLines[pieceY + linesIndex].Positions[pieceX+blockIndex] = currLine[blockIndex];
                }
            }
            string s = "block line is: " + _boardLines.Last().Positions.First();
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
            Pieces.Add(piece);
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
