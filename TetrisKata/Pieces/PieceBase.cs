using System.Collections.Generic;
using System.Linq;
using TetrisKata.Specification;

namespace TetrisKata.Pieces
{
    public enum MoveDirection { None, Left, Right, Up, Down }
    public enum PieceOrientation { None, North, East, South, West }
    public enum PieceShape { None, Line, Square, TShaped, LeftUpLightning, RightUpLightning, LShaped, ReverseLShaped }
    public abstract class PieceBase
    {
        protected int _width, _height;
        public bool IsActive { get; private set; }

        protected IList<bool> _collisionMap;
        
        protected PieceShape _shape;

        public PieceShape Shape
        {
            get { return _shape; }
        }

        public PieceOrientation _orientation;
        public PieceOrientation Orientation { get => _orientation; }

        private PieceVerticalOrientationSpecification _verticalOrientationSpecification;
        public PieceBase(PieceShape shape)
        {
            IsActive = true;
            PositionXY = new int[] { 0, 0 };
            _orientation = PieceOrientation.North;
            _verticalOrientationSpecification = new PieceVerticalOrientationSpecification();
            _shape = shape;
        }
        public int[] PositionXY { get; set; }
        public int[] BoundingBox {
            get
            {
                if (_verticalOrientationSpecification.IsSatisfiedBy(this))
                {
                    return new[] { _width, _height };
                }
                else
                {
                    return new[] { _height, _width };
                }
            }
        }
        public bool IsFourContiguousBlocks
        {
            get
            {
                //this is a specification
                return _collisionMap != null && _collisionMap.Any() && FigureCollisonMapHasFourContiguousBlocks();
            }
        }

        private bool FigureCollisonMapHasFourContiguousBlocks()
        {
            //for now this is no 4 contigous, it's just 4
            return _collisionMap.Where(p => p == true).Count() == 4;
        }
        protected void InitPiece(int width, int height)
        {
            _width = width;
            _height = height;
            _collisionMap = InitCollisionMap(width, height);
            //I've decide that position is top left insted of center of my piece
            PositionXY = new int[2] { 0, 0 };
        }
        public virtual List<bool> InitCollisionMap(int width, int height)
        {
            var collisionMap = new List<bool>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    collisionMap.Add(true);
                }
            }
            return collisionMap;
        }

        public void Move(MoveDirection direction, int interval)
        {
            switch (direction)
            {
                case MoveDirection.None:
                    break;
                case MoveDirection.Left:
                    break;
                case MoveDirection.Right:
                    break;
                case MoveDirection.Up:
                    break;
                case MoveDirection.Down:
                    PositionXY[1] += interval;
                    break;
                default:
                    break;
            }
        }
        public void Turn()
        {
            //completed loop
            if(Orientation == PieceOrientation.East)
            {
                _orientation = PieceOrientation.North;
            }
            else
            {
                int newOrientation = (int)Orientation + 1;
                _orientation = (PieceOrientation)newOrientation;
            }
        }
        public void Stop()
        {
            IsActive = false;
        }
        public IList<List<bool>> DecomposeCollisionMapInLinesOfBlocks()
        {
            var listOfLines = new List<List<bool>>();
            for (int i = 0; i < _height; i++)
            {
                var currLine = _collisionMap.ToList().GetRange(_width * i, _width);
                listOfLines.Add(currLine);
            }
            if (Orientation == PieceOrientation.South)
            {
                listOfLines.Reverse();
            }
            if(!_verticalOrientationSpecification.IsSatisfiedBy(this))
            {
                var newListOflines = new List<List<bool>>();
                for (int y = 0; y < _width; y++)
                {
                    var currList = new List<bool>();
                    for (int x = 0; x < _height; x++)
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
                if(Orientation == PieceOrientation.East)
                {
                    for (int i = 0; i < newListOflines.Count; i++)
                    {
                        newListOflines[i].Reverse();
                    }
                }
                listOfLines = newListOflines;
            }
            return listOfLines;
        }
    }
}
