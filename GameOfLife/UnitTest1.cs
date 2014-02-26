using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife
{
    /*  Rules:
        Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        Any live cell with two or three live neighbours lives on to the next generation.
        Any live cell with more than three live neighbours dies, as if by overcrowding.
        Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
     */
    [TestClass]
    public class UnitTest1
    {
        private Game _game;

        [TestInitialize]
        public void BeforeTest()
        {
            _game = new Game(10);
        }

        

        [TestMethod]
        public void Construct_Game()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            
            //---------------Test Result -----------------------
            Assert.IsNotNull(_game);
        }
        
        [TestMethod]
        public void SetBoard_GivenArrayWithSize20_ShouldReturn2DArrayWithSize20()
        {
            //---------------Set up test pack-------------------
            
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _game.SetBoard(20);
            //---------------Test Result -----------------------
            Assert.AreEqual(20,_game.Size);
            Assert.AreEqual(20, _game.Width);
            Assert.AreEqual(20, _game.Height);
        }

        [TestMethod]
        public void Toggle_GivenCoordinate0And0_ShouldReturnPosition0And0As1()
        {
            //---------------Set up test pack-------------------
            _game.SetBoard(10);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            _game.Toggle(0, 0);
            int mapValue = _game.ValueOfPoint(0, 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(1,mapValue);
        }

        [TestMethod]
        public void PointHasFewerThanTwoNeghbours_Given1And1_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(1,1);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasFewerThanTwoNeighbours = _game.PointHasFewerThanTwoNeighbours(1, 1);
            //---------------Test Result -----------------------
            Assert.IsTrue(hasFewerThanTwoNeighbours);
        }

        [TestMethod]
        public void PointHasFewerThanTwoNeighbours_GivenAllAround1And1_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            _game.Toggle(2, 1);
            _game.Toggle(2, 2);
            _game.Toggle(1, 2);
            _game.Toggle(0, 2);
            _game.Toggle(0, 1);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasFewerThanTwoNeighbours = _game.PointHasFewerThanTwoNeighbours(1, 1);
            //---------------Test Result -----------------------
            Assert.IsFalse(hasFewerThanTwoNeighbours);
        }

        [TestMethod]
        public void PointHasTwoOrThreeNighbours_GivenPointsAround1And1_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasTwoOrThreeNeighbours = _game.PointHasTwoOrThreeNighbours(1, 1);
            //---------------Test Result -----------------------
            Assert.IsTrue(hasTwoOrThreeNeighbours);
        }

        [TestMethod]
        public void PointHasMoreThan3Neighbours_GivenPointsAround1And1_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasMoreThanThreeNeighbours = _game.PointHasMoreThanThreeNeighbours(1, 1);
            //---------------Test Result -----------------------
            Assert.IsFalse(hasMoreThanThreeNeighbours);
        }

        [TestMethod]
        public void PointHasMoreThan3Neighbours_GivenPointsAround1And1_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            _game.Toggle(2, 1);
            _game.Toggle(2, 2);
            _game.Toggle(1, 2);
            _game.Toggle(0, 2);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasMoreThanThreeNeighbours = _game.PointHasMoreThanThreeNeighbours(1, 1);
            //---------------Test Result -----------------------
            Assert.IsTrue(hasMoreThanThreeNeighbours);
        }

        [TestMethod]
        public void PointHasExactlyThreeNeighboursAndIsDead_Given1And1_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var hasThreeNeighboursAndIsDead = _game.PointHasThreeNeighboursAndIsDead(1, 1);
            //---------------Test Result -----------------------
            Assert.IsTrue(hasThreeNeighboursAndIsDead);
        }

        [TestMethod]
        public void PointShouldDie_Given1And1WithFewerThanTwoNeighbours_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 1);
            //---------------Assert Precondition----------------
            Assert.AreEqual(1,_game.ValueOfPoint(1,1));
            //---------------Execute Test ----------------------
            _game.Proc();
            //---------------Test Result -----------------------
            Assert.AreEqual(0,_game.ValueOfPoint(1,1));
        }
    }
}
