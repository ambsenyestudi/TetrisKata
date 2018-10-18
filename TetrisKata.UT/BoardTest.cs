using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisKata.UT
{
    [TestClass]
    public class BoardTest
    {
        private Board _sut;
        private int defaultWidth = 10;
        private int defaultHeight = 24;
        [TestInitialize]
        public void InitSut()
        {
            _sut = new Board(defaultWidth, defaultHeight);
        }

        [TestMethod]
        public void BoardShouldBeInactiveAtStart()
        {
            _sut.AddPieceToBoard();
            Assert.IsTrue(_sut.IsActive);
        }

        [TestMethod]
        public void CompleteLinesShouldBeCleared()
        {
            _sut.AddPieceToBoard();
            //todo create many pieces
            Assert.IsTrue(_sut.IsActive);
        }
    }
}
