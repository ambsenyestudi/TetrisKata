using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TetrisKata.Pieces;

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
