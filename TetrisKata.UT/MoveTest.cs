using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisKata.Pieces;
using System.Linq;
using TetrisKata.CrossCutting.Enums;

namespace TetrisKata.UT
{
    [TestClass]
    public class MoveTest
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
        public void SquareShouldNotMoveRight()
        {
            _sut = new Board(2, 3);
            _sut.AddPieceToBoard(new SquarePiece());
            var piece = _sut.Pieces.Last();
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Right, defaultInterval);

            var expected = false;
            Assert.AreEqual(expected, IsMove);
        }
        [TestMethod]
        public void SquareShouldNotMoveLeft()
        {
            _sut = new Board(2, 3);
            _sut.AddPieceToBoard(new SquarePiece());
            var piece = _sut.Pieces.Last();
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Left, defaultInterval);

            var expected = false;
            Assert.AreEqual(expected, IsMove);
        }
        [TestMethod]
        public void LineShouldMoveLeft()
        {
            _sut = new Board(2, 4);
            _sut.AddPieceToBoard(new LinePiece());
            var piece = _sut.Pieces.Last();
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Left, defaultInterval);

            var expected = false;
            Assert.AreEqual(expected, IsMove);
        }
        [TestMethod]
        public void LineShouldNotMoveRight()
        {
            _sut = new Board(2, 5);
            _sut.AddPieceToBoard(new LinePiece());
            var piece = _sut.Pieces.Last();
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Right, defaultInterval);

            var expected = true;
            Assert.AreEqual(expected, IsMove);
        }
        [TestMethod]
        public void LShapeShouldRotateMoveLeft()
        {
            _sut = new Board(4, 5);
            _sut.AddPieceToBoard(new LShapedPiece());
            _sut.TryTurnActivePiece();
            var piece = _sut.Pieces.Last();
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Left, defaultInterval);
            var expected = true;
            Assert.AreEqual(expected, IsMove);
        }
        [TestMethod]
        public void LShapeShouldRotateMoveRight()
        {
            _sut = new Board(4, 5);
            _sut.AddPieceToBoard(new LShapedPiece());
            var piece = _sut.Pieces.Last();
            _sut.TryTurnActivePiece();
            
            var IsMove = _sut.TryMoveActivePiece(MoveDirection.Right, defaultInterval);
            var expected = false;
            Assert.AreEqual(expected, IsMove);
        }
    }
}
