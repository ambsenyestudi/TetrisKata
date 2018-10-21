using TetrisKata.Pieces.Base;
using TetrisKata.Pieces.Enums;

namespace TetrisKata.Pieces
{
    public class SquarePiece : PieceBase
    {
        public SquarePiece():base(PieceShape.Square)
        {
            InitPiece(2, 2);
        }
        
    }
}
