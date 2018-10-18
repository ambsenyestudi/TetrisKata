using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisKata
{
    public class BoardLine
    {
        public bool IsCleared
        {
            get
            {
                return FigureAllPositionsAreFilled();
            }
        }

        private bool FigureAllPositionsAreFilled()
        {
            int filledCount = _postions.Where(p => p == true).Count();
            return _postions.Count == filledCount;
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
