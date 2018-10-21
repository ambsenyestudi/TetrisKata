using System.Collections.Generic;

namespace TetrisKata.Pieces
{
    public class TShapedPiece: PieceBase
    {
        public TShapedPiece():base(PieceShape.TShaped)
        {
            InitPiece(2, 3);
        }
        public override void InitCollisionMap(int width, int height)
        {
            var collisionMap = new List<bool>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //grounds for specification is even or is odd
                    if (x % 2 == 0)
                    {
                        collisionMap.Add(true);
                    }
                    else
                    {
                        if (y % 2 == 0)
                        {
                            collisionMap.Add(false);
                        }
                        else
                        {
                            collisionMap.Add(true);
                        }
                    }
                    
                }
            }
            CollisionMap = collisionMap;
        }
    }
}
