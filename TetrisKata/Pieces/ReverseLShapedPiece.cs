using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisKata.Pieces
{
    public class ReverseLShapedPiece : PieceBase
    {
        public ReverseLShapedPiece() : base(PieceShape.ReverseLShaped)
        {
            InitPiece(2, 3);
        }
        public override List<bool> InitCollisionMap(int width, int height)
        {
            var collisionMap = new List<bool>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 1)
                    {
                        collisionMap.Add(true);
                    }
                    else if (y == 2)
                    {
                        collisionMap.Add(true);
                    }
                    else
                    {
                        collisionMap.Add(false);
                    }
                }
            }
            return collisionMap;
        }
    }
}
