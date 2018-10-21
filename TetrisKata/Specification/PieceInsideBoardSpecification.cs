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
            return piece => piece.BoundingArea.X >=0 
            && piece.BoundingArea.X + piece.BoundingArea.Width <= _boardWidth 
            && piece.BoundingArea.Y + piece.BoundingArea.Height < _boardHeight;
        }
    }
}
