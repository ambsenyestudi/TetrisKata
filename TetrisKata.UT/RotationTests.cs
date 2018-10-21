using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisKata.Pieces;
using System.Linq;

namespace TetrisKata.UT
{
    [TestClass]
    public class RotationTests
    {

        private Board _sut;
        private int defaultWidth = 10;
        private int defaultHeight = 24;

        [TestMethod]
        public void LShapedShouldRotate()
        {
            _sut = new Board(4, 3);
            _sut.AddPieceToBoard(new LShapedPiece());
            var result = _sut.IsRotationPossible(_sut.Pieces.Last());
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LShapedShouldNotRotate()
        {
            _sut = new Board(3, 3);
            _sut.AddPieceToBoard(new LShapedPiece());
            var result = _sut.IsRotationPossible(_sut.Pieces.Last());
            Assert.IsTrue(result);
        }
    }
}
