using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void PieceShouldCollide()
        {
            _sut = new Board(2, 4);
            _sut.AddPieceToBoard(new LinePiece());
            _sut.Advance(defaultInterval);

            var tPiece = new TShapedPiece();
            var result = _sut.IsMovePossible(tPiece, MoveDirection.Down, defaultInterval);
            Assert.IsFalse(result);
        }
    }
}
