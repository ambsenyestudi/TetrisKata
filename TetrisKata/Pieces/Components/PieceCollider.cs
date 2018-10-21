using System.Collections.Generic;

namespace TetrisKata.Pieces.Components
{
    public class PieceCollider
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IList<bool> CollisionMap { get; set; }
        public int[] BoundingBox
        {
            get => new[] { Width, Height };
        }
    }
}
