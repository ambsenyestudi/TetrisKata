using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TetrisKata.CrossCutting.Enums;
using TetrisKata.Pieces;

namespace TetrisKata.UT
{
    [TestClass]
    public class BoardTest
    {
        private Board _sut;
        private int defaultWidth = 10;
        private int defaultHeight = 24;
        private const int defaultInterval = 1;
        [TestInitialize]
        public void InitSut()
        {
            _sut = new Board(defaultWidth, defaultHeight);
        }

        //redo this
        [TestMethod]
        public void BoardShouldBeInactiveAtStart()
        {
            _sut.AddRandomPieceToBoard();
            Assert.IsTrue(_sut.IsActive);
        }

        [TestMethod]
        public void CompleteLinesShouldBeCleared()
        {
            _sut.AddRandomPieceToBoard();
            //todo create many pieces
            Assert.IsTrue(_sut.IsActive);
        }

        [TestMethod]
        public void PieceShouldBottomCollide()
        {
            _sut = new Board(2, 3);
            var piece = new TShapedPiece();
            var result = _sut.IsMovePossible(piece, MoveDirection.Down, defaultInterval);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TShapeShouldCollideAgainstLine()
        {
            _sut = new Board(2, 4);
            _sut.AddPieceToBoard(new LinePiece());
            _sut.Advance(defaultInterval);

            var tPiece = new TShapedPiece();
            var result = _sut.IsMovePossible(tPiece, MoveDirection.Down, defaultInterval);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TShapeShouldCollideAgainstSquare()
        {
            _sut = new Board(3, 4);
            _sut.AddPieceToBoard(new SquarePiece());
            _sut.Advance(defaultInterval);
            _sut.Advance(defaultInterval);

            var tPiece = new TShapedPiece();
            var result = _sut.IsMovePossible(tPiece, MoveDirection.Down, defaultInterval);
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void GivenCompleteLineShouldClear()
        {
            _sut = new Board(2, 3);
            _sut.AddPieceToBoard(new SquarePiece());
            var piece = _sut.Pieces.Last();
            _sut.TryAdvance(defaultInterval);
            _sut.TryAdvance(defaultInterval);
            _sut.TryAdvance(defaultInterval);
            var result = _sut.IncompleteLinesCount;
            var expected = 0;
            Assert.AreEqual(expected, result);
        }

    }
}
