using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisKata
{
    public class BoardLine
    {
        public bool IsFull
        {
            get
            {
                return !Positions.Contains(false);
            }
        }
        public bool HasAny
        {
            get
            {
                return Positions.Contains(true) && Positions.Contains(false);
            }
        }
        
        private List<bool> _postions;

        public List<bool> Positions
        {
            get { return _postions; }
        }
        public BoardLine(int positions)
        {
            InitLine(positions);
        }

        private void InitLine(int positions)
        {
            _postions = new List<bool>();
            for (int i = 0; i < positions; i++)
            {
                _postions.Add(false);
            }
        }
    }
}
