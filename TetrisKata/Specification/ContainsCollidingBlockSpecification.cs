using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TetrisKata.Specification
{
    public class ContainsCollidingBlockSpecification : SpecificationBase<IList<List<bool>>>
    {
        public override Expression<Func<IList<List<bool>>, bool>> ToExpression()
        {
            return list => list.Where(cl => !cl.Contains(true)).Count() < list.Count;
        }
    }
}
