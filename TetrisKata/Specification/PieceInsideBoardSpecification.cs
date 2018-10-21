using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TetrisKata.Pieces;

namespace TetrisKata.Specification
{
    public class PieceInsideBoardSpecification : SpecificationBase<PieceBase>
    {
        private int _boardWidth;
        private int _boardHeight;
        public PieceInsideBoardSpecification(int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
        }
        public override Expression<Func<PieceBase, bool>> ToExpression()
        {
            return piece => piece.Orientation == PieceOrientation.North || piece.Orientation == PieceOrientation.South;
        }
    }
}
