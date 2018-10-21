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
        public bool IsActive { get; private set; }

        protected PieceCollider _collider;
        protected PieceTransform _transform;
        public BoundingArea BoundingArea { get => _transform.FigureBoundingArea(_collider); }
        public IList<bool> CollisionMap {
            get
            {
                //todo
                return null;
            }
            protected set => _collider.CollisionMap = value;
        }

        protected PieceShape _shape;

        public PieceShape Shape
        {
            get { return _shape; }
        }
        
        public PieceOrientation Orientation { get => _transform.Orientation; }
        
        public PieceBase(PieceShape shape)
        {
            _collider = new PieceCollider();
            _transform = new PieceTransform();
            IsActive = true;
            _shape = shape;
        }
        
        public bool IsFourContiguousBlocks
        {
            get
            {
                //this is a specification
                return _collider.CollisionMap != null && _collider.CollisionMap.Any() && FigureCollisonMapHasFourContiguousBlocks();
            }
        }

        private bool FigureCollisonMapHasFourContiguousBlocks()
        {
            //for now this is no 4 contigous, it's just 4
            return _collider.CollisionMap.Where(p => p == true).Count() == 4;
        }
        protected void InitPiece(int width, int height)
        {
            _collider.Width = width;
            _collider.Height= height;
        }
        public virtual void InitCollisionMap(int width, int height)
        {
            var collisionMap = new List<bool>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    collisionMap.Add(true);
                }
            }
            CollisionMap = collisionMap;
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
                    _transform.PosY += interval;
                    break;
                default:
                    break;
            }
        }
        public void Turn()
        {
            _transform.Turn();
        }
        public void Stop()
        {
            IsActive = false;
        }
        public IList<List<bool>> DecomposeCollisionMapInLinesOfBlocks()
        {
            return _transform.DecomposeCollisionMapInLinesOfBlocks(_collider);
        }
    }
}
