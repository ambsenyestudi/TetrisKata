using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisKata.Pieces
{
    public class PieceCollider
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IList<bool> CollisionMap { get; private set; }
        public int[] BoundingBox
        {
            get => new[] { Width, Height };
        }
        public void InitCollisionMap()
        {
            var collisionMap = new List<bool>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    collisionMap.Add(true);
                }
            }
            CollisionMap = collisionMap;
        }
    }
}
