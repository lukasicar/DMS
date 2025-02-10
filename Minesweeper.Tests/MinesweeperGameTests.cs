using Minesweeeper;
using NSubstitute;

namespace Minesweeper.Tests
{
    public class MinesweeperGameTests
    {
        private MinesweeperGame _game;
        private IPlayer _player;
        private IGameDisplay _gameDisplay;
        private IMineService _mineService;
        private int _boardSize;

        [SetUp]
        public void SetUp()
        {
            _boardSize = 5;
            _player = Substitute.For<IPlayer>();
            _gameDisplay = Substitute.For<IGameDisplay>();
            _mineService = Substitute.For<IMineService>();

            _game = new MinesweeperGame(_player, _gameDisplay, _mineService, _boardSize);
        }

        [Test]
        public void Player_ShouldWin_When_ReachEnd()
        {
            // Simulate the player moving to the last column (winning condition)
            _player.Position = new Position(_boardSize - 1, 0);  // Move player to (4, 0)
            _mineService.IsMine(Arg.Any<Position>()).Returns(false);  // No mine at position

            _game.PlayGame();

            // Check if the "You win" message was displayed
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("You win")));
        }

        [Test]
        public void Player_ShouldLose_When_LivesReachZero()
        {
            // Simulate player losing all lives
            _player.Lives = 0;

            _game.PlayGame();

            // Check if the "Game Over" message was displayed
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("Game Over")));
        }

        [Test]
        public void Player_ShouldStepOnMine()
        {
            // Simulate stepping on a mine
            _player.Position = new Position(2, 2);
            _mineService.IsMine(_player.Position).Returns(true);
            _mineService.DisarmMine(Arg.Any<Position>());

            _game.PlayGame();

            // Check if the correct message was shown when stepping on a mine
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("Boom!")));
            Assert.AreEqual(2, _player.Lives);  // Assuming player starts with 3 lives and lost one
        }
    }
}