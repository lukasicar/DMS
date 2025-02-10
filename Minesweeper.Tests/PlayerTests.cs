using Minesweeeper;

namespace Minesweeper.Tests
{
    internal class PlayerTests
    {
        private Player _player;
        private int _boardSize;

        [SetUp]
        public void SetUp()
        {
            _boardSize = 5;
            _player = new Player(new Position(0, 0), 3);
        }

        [Test]
        public void Player_InitialPosition_ShouldBe_0_0()
        {
            Assert.AreEqual(0, _player.Position.x);
            Assert.AreEqual(0, _player.Position.y);
        }

        [Test]
        public void Player_LosingLife_When_SteppingOnMine()
        {
            _player.Lives = 3;
            var initialLives = _player.Lives;

            // Simulate stepping on a mine
            _player.TakeDamage();

            Assert.AreEqual(initialLives - 1, _player.Lives);
        }
    }
}