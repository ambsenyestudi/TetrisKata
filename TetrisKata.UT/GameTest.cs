using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisKata.UT
{
    [TestClass]
    public class GameTest
    {
        private Game _sut;

        [TestInitialize]
        public void InitSut()
        {
            _sut = new Game();
        }
        [TestMethod]
        public void Piece_Should_Not_Go_Through_The_Ground()
        {
            //Todo thest
            /*
             * var line = new LinePiece();
            Assert.IsTrue(line.Move(MoveDirection.Down)); 
             */
        }
    }
}
