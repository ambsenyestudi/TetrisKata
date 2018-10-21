using System;
using System.Linq.Expressions;
using TetrisKata.Pieces.Base;
using TetrisKata.Pieces.Enums;

namespace TetrisKata.Specification
{
    public class VerticalOrientationSpecification : SpecificationBase<PieceOrientation>
    {
        public override Expression<Func<PieceOrientation, bool>> ToExpression()
        {
            return orientation => orientation == PieceOrientation.North ||orientation == PieceOrientation.South;
        }
    }
}
