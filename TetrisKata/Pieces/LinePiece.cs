using TetrisKata.Pieces.Base;
using TetrisKata.Pieces.Enums;

namespace TetrisKata.Pieces
{
    public class LinePiece : PieceBase
    {
        public LinePiece() : base(PieceShape.Line)
        {
            InitPiece(1, 4);
        }
    }
}
