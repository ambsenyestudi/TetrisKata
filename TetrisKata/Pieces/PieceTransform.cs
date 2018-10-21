using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisKata.Specification;

namespace TetrisKata.Pieces
{
    public class PieceTransform
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        protected PieceOrientation _orientation;
        public PieceOrientation Orientation { get => _orientation; }

        private VerticalOrientationSpecification _verticalOrientationSpecification;

        public PieceTransform()
        {
            PosX = 0;
            PosY = 0;
            _orientation = PieceOrientation.North;
            _verticalOrientationSpecification = new VerticalOrientationSpecification();
        }
        public void Turn()
        {
            //completed loop
            if (Orientation == PieceOrientation.West)
            {
                _orientation = PieceOrientation.North;
            }
            else
            {
                int newOrientation = (int)Orientation + 1;
                _orientation = (PieceOrientation)newOrientation;
            }
        }
        public IList<List<bool>> DecomposeCollisionMapInLinesOfBlocks(PieceCollider collider)
        {
            var listOfLines = new List<List<bool>>();
            for (int i = 0; i < collider.Height; i++)
            {
                var currLine = collider.CollisionMap.ToList().GetRange(collider.Width * i, collider.Width);
                listOfLines.Add(currLine);
            }
            if (Orientation == PieceOrientation.South)
            {
                listOfLines.Reverse();
                for (int i = 0; i < listOfLines.Count; i++)
                {
                    listOfLines[i].Reverse();
                }
            }
            if (!_verticalOrientationSpecification.IsSatisfiedBy(Orientation))
            {
                var newListOflines = new List<List<bool>>();
                for (int y = 0; y < collider.Width; y++)
                {
                    var currList = new List<bool>();
                    for (int x = 0; x < collider.Height; x++)
                    {
                        currList.Add(false);
                    }
                    newListOflines.Add(currList);
                }
                //trasnspose
                for (int y = 0; y < listOfLines.Count; y++)
                {
                    var currList = listOfLines[y];
                    for (int x = 0; x < currList.Count; x++)
                    {
                        newListOflines[x][y] = listOfLines[y][x];
                    }
                }
                if (Orientation == PieceOrientation.East)
                {
                    for (int i = 0; i < newListOflines.Count; i++)
                    {
                        newListOflines[i].Reverse();
                    }
                }
                else
                {
                    newListOflines.Reverse();
                }
                listOfLines = newListOflines;
            }
            return listOfLines;
        }
    }
}
