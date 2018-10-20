using System.Collections.Generic;
using System.Linq;

namespace TetrisKata.Pieces
{
    public enum MoveDirection { None, Left, Right, Up, Down }
    public enum PieceOrientation { None, North, West, South, East }
    public enum PieceShape { None, Line, Square, TShaped, LeftUpLightning, RightUpLightning, LShaped, ReverseLShaped }
    public abstract class PieceBase
    {
        protected int _width, _height;
        public bool IsActive { get; private set; }

        protected IList<bool> _collisionMap;

        public IList<bool> CollisionMap
        {
            get { return _collisionMap; }
        }

        protected PieceShape _shape;

        public PieceShape Shape
        {
            get { return _shape; }
        }

        public PieceOrientation _orientation;
        public PieceOrientation Orientation { get => _orientation; }

        public PieceBase(PieceShape shape)
        {
            IsActive = true;
            PositionXY = new int[] { 0, 0 };
            _orientation = PieceOrientation.North;
            _shape = shape;
        }
        public int[] PositionXY { get; set; }
        public int[] BoundingBox {
            get
            {
                return new[] { _width, _height };
            }
        }
        public bool IsFourContiguousBlocks
        {
            get
            {
                //this is a specification
                return CollisionMap != null && CollisionMap.Any() && FigureCollisonMapHasFourContiguousBlocks();
            }
        }

        private bool FigureCollisonMapHasFourContiguousBlocks()
        {
            //for now this is no 4 contigous, it's just 4
            return CollisionMap.Where(p => p == true).Count() == 4;
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
                _orientation = (PieceOrientation)Orientation;
            }
        }
        public void Stop()
        {
            IsActive = false;
        }
        public IList<IList<bool>> DecomposeCollisionMapInLinesOfBlocks()
        {
            var listOfLines = new List<IList<bool>>();
            for (int i = 0; i < _height; i++)
            {
                var currLine = CollisionMap.ToList().GetRange(_width * i, _width);
                listOfLines.Add(currLine);
            }
            return listOfLines;
        }
    }
}
