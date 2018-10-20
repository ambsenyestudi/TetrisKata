using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TetrisKata.Pieces;

namespace TetrisKata.Specification
{
    public class PieceVerticalOrientationSpecification : SpecificationBase<PieceBase>
    {
        public override Expression<Func<PieceBase, bool>> ToExpression()
        {
            return piece => piece.Orientation == PieceOrientation.North || piece.Orientation == PieceOrientation.South;
        }
    }
}
