using System.Collections.Generic;

namespace TetrisKata.Pieces
{
    public class LShapedPiece : PieceBase
    {
        public LShapedPiece() : base(PieceShape.LShaped)
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
                    if (x == 0)
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
