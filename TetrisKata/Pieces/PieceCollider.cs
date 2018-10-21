﻿using System;
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

        public IList<bool> CollisionMap { get; set; }
        public int[] BoundingBox
        {
            get => new[] { Width, Height };
        }
    }
}
