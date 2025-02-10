using Minesweeeper;
using NSubstitute;

namespace Minesweeper.Tests
{
    public class ConsoleGameDisplayTests
    {
        private ConsoleGameDisplay _gameDisplay;
        private Player _player;
        private int _boardSize;
        private IMineService _mineService;

        [SetUp]
        public void SetUp()
        {
            _boardSize = 5;
            _player = new Player(new Position(0,0), 3);
            _mineService = Substitute.For<IMineService>();
            _gameDisplay = new ConsoleGameDisplay(_player, _boardSize, _mineService);
        }

        [Test]
        public void DisplayBoard_ShouldClearPreviousMessages()
        {
            // Display a message before displaying the board
            _gameDisplay.DisplayMessage("Test Message");

            // Display the board, which should clear previous messages
            _gameDisplay.DisplayBoard();

            // Check that the message "Test Message" was displayed
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s == "Test Message"));

            // Clear the message queue and ensure no further message is displayed
            _gameDisplay.ClearMessages();
            _gameDisplay.DisplayBoard();
            _gameDisplay.DidNotReceive().DisplayMessage(Arg.Is<string>(s => s == "Test Message"));
        }

        [Test]
        public void DisplayBoard_ShouldDisplayPlayerPosition()
        {
            _player.Move("right");
            _gameDisplay.DisplayBoard();

            // Test that the position is displayed on the board
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("[P]")));
        }

        [Test]
        public void DisplayAvailableMoves_ShouldDisplayCorrectMoves()
        {
            _player.Move("right");
            _gameDisplay.DisplayBoard();

            var availableMoves = new List<Position> { new Position(1, 0), new Position(0, 1) };
            _gameDisplay.DisplayMessage("Available moves: ");
            foreach (var move in availableMoves)
            {
                _gameDisplay.DisplayMessage($"({move.x},{move.y})");
            }

            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("(1,0)")));
            _gameDisplay.Received().DisplayMessage(Arg.Is<string>(s => s.Contains("(0,1)")));
        }
    }
}
