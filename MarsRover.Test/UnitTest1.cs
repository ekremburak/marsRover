using NUnit.Framework;
using MarsRover.Models;

namespace MarsRover.Test
{
    [TestFixture]
    public class Tests
    {
        Mars mars;
        [SetUp]
        public void Setup()
        {
            mars = new Mars();

            mars._plateau = new Plateau { X = 5, Y = 5 };

        }


        [TestCase("5 5", true)]
        [TestCase("55", false)]
        [TestCase("55 3", true)]
        [TestCase(" ", false)]
        [TestCase("", false)]
        [TestCase("2 3 1", false)]
        [TestCase("2 31", true)]
        [TestCase("-1 4", false)]
        public void plateauSizeTest(string input, bool excepted)
        {
            Plateau platue;

            bool result = mars.CheckPlateauSize(input, out platue);

            Assert.AreEqual(result, excepted);
        }


        [TestCase("1 2 N", true)]
        [TestCase("1 2 E", true)]
        [TestCase("-1 -1 E", false)]
        [TestCase("12 E", false)]
        [TestCase("12E", false)]
        [TestCase("4 3 E", true)]
        [TestCase("2 31 EE", false)]
        [TestCase("2 31 E N", false)]
        [TestCase("N E W", false)]
        [TestCase("-1 0 W", false)]
        public void roverPositionInputCheckTest(string input, bool excepted)
        {
            Position position;

            bool result = mars.CheckRoverPosition(input, out position);

            Assert.AreEqual(result, excepted);
        }


        [TestCase(1, 2, Direction.North, "L", 1, 2, Direction.West)]
        [TestCase(1, 2, Direction.North, "LM", 0, 2, Direction.West)]
        [TestCase(1, 2, Direction.North, "LMLMLMRRMMMRLMM", 0, 1, Direction.West)]
        [TestCase(5, 5, Direction.North, "MM", 5, 5, Direction.North)]
        public void checkRoverPosition(int roverX, int roverY, Direction roverDirection, string navigationInputs, int expectedX, int expectedY, Direction expectedDirection)
        {

            var position = new Position(roverX, roverY, roverDirection);

            var newPosition = mars.Navigate(position, navigationInputs);

            var exceptedPosition = new Position(expectedX, expectedY, expectedDirection);

            Assert.AreEqual(newPosition.X, exceptedPosition.X);
            Assert.AreEqual(newPosition.Y, exceptedPosition.Y);
            Assert.AreEqual(newPosition.Direction, exceptedPosition.Direction);
        }
    }
}