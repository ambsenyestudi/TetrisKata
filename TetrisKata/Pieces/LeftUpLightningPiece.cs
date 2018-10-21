using System.Collections.Generic;
using TetrisKata.Pieces.Base;
using TetrisKata.Pieces.Enums;

namespace TetrisKata.Pieces
{
    public class LeftUpLightningPiece :PieceBase
    {
        public LeftUpLightningPiece():base(PieceShape.LeftUpLightning)
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
                    if (y % 2 == 0)
                    {
                        if(x==0 && y<1)
                        {
                            collisionMap.Add(true);
                        }
                        else if (x == 1 && y > 1)
                        {
                            collisionMap.Add(true);
                        }
                        else
                        {
                            collisionMap.Add(false);
                        }
                    }
                    else
                    {
                        collisionMap.Add(true);
                    }
                }
            }
            _collider.CollisionMap = collisionMap;
        }
    }
}
