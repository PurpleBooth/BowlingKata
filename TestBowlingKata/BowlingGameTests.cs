using System.Linq;
using BowlingKata;
using Xunit;

namespace TestBowlingKata
{
    public class BowlingGameTests
    {
        [Fact]
        public void TestGutterBallGame()
        {
            var game = new BowlingGame();

            Enumerable.Range(0, 20).ToList().ForEach(arg => game.Roll(0));

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void TestItIsInitialisable()
        {
            var game = new BowlingGame();
            Assert.IsType(typeof(BowlingGame), game);
        }

        [Fact]
        public void TestNormalScore()
        {
            var game = new BowlingGame();

            Enumerable.Range(0, 10).ToList().ForEach(arg => game.Roll(1));
            Enumerable.Range(0, 10).ToList().ForEach(arg => game.Roll(2));

            Assert.Equal(30, game.Score());
        }


        [Fact]
        public void TestPerfectGame()
        {
            var game = new BowlingGame();

            Enumerable.Range(0, 12).ToList().ForEach(unused => game.Roll(10));

            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void TestSpareScore()
        {
            var game = new BowlingGame();
            game.Roll(3);
            game.Roll(7);
            game.Roll(1);
            game.Roll(2);

            Enumerable.Range(0, 16).ToList().ForEach(arg => game.Roll(0));

            Assert.Equal(14, game.Score());
        }

        [Fact]
        public void TestStrikeScore()
        {
            var game = new BowlingGame();
            game.Roll(10);

            game.Roll(1);
            game.Roll(2);

            game.Roll(3);
            game.Roll(0);

            Enumerable.Range(0, 14).ToList().ForEach(unused => game.Roll(0));

            Assert.Equal(19, game.Score());
        }
    }
}