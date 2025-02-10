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
        public void Player_ShouldLose_When_LivesReachZero()
        {
            // Simulate player losing all lives
            _player.Lives = 0;

            _game.PlayGame();

            // Check if the "Game Over" message was displayed
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("Game Over")));
        }
    }
}