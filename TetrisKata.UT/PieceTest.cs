using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisKata.Pieces;
using System.Linq;

namespace TetrisKata.UT
{
    [TestClass]
    public class PieceTest
    {
        [TestMethod]
        public void Start_Should_Create_Piece()
        {
            var line = new LinePiece();
            Assert.IsTrue(line.IsFourContiguousBlocks);
        }

        [TestMethod]
        public void Line_Should_Be_Four_Contiguous_Blocks()
        {
            var line = new LinePiece();
            Assert.IsTrue(line.IsFourContiguousBlocks);
        }
        [TestMethod]
        public void Square_Should_Be_Four_Contiguous_Blocks()
        {
            var square = new SquarePiece();
            Assert.IsTrue(square.IsFourContiguousBlocks);
        }
        [TestMethod]
        public void TShaped_Should_Be_Four_Contiguous_Blocks()
        {
            var tShaped = new TShapedPiece();
            Assert.IsTrue(tShaped.IsFourContiguousBlocks);
        }
        
        [TestMethod]
        public void LeftUpLightning_Should_Be_Four_Contiguous_Blocks()
        {
            var leftUpLightning = new LeftUpLightningPiece();
            Assert.IsTrue(leftUpLightning.IsFourContiguousBlocks);
        }

        [TestMethod]
        public void RightUpLightning_Should_Be_Four_Contiguous_Blocks()
        {
            var rightUpLightning = new RightUpLightningPiece();
            Assert.IsTrue(rightUpLightning.IsFourContiguousBlocks);
        }

        [TestMethod]
        public void LShaped_Should_Be_Four_Contiguous_Blocks()
        {
            var lShapedPiece = new LShapedPiece();
            Assert.IsTrue(lShapedPiece.IsFourContiguousBlocks);
        }

        [TestMethod]
        public void ReverseLShaped_Should_Be_Four_Contiguous_Blocks()
        {
            var ReverseLShaped = new ReverseLShapedPiece();
            Assert.IsTrue(ReverseLShaped.IsFourContiguousBlocks);
        }
        
        [TestMethod]
        public void Piece_Should_Stop()
        {
            var line = new LinePiece();
            line.Stop();
            
            Assert.IsFalse(line.IsActive);
        }
        [TestMethod]
        public void Line_Should_TurnRight()
        {
            var line = new LinePiece();
            var collisionMapList = line.DecomposeCollisionMapInLinesOfBlocks();
            line.Turn();
            var turnedCollisionMapList = line.DecomposeCollisionMapInLinesOfBlocks();
            Assert.AreEqual(collisionMapList.Count,turnedCollisionMapList.First().Count);
        }
        [TestMethod]
        public void L_Should_TurnRight()
        {
            var line = new LShapedPiece();
            var collisionMapList = line.DecomposeCollisionMapInLinesOfBlocks();
            line.Turn();
            var turnedCollisionMapList = line.DecomposeCollisionMapInLinesOfBlocks();
            var first = collisionMapList.First().Last();
            var firstTurned = turnedCollisionMapList.Last().Last();
            Assert.AreEqual(first,firstTurned);
            var second = collisionMapList[1].Last();
            var secondTurned = turnedCollisionMapList[1][1];
            Assert.AreEqual(second, secondTurned);
        }
    }
}
