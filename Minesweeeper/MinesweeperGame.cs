namespace Minesweeeper
{
    public class MinesweeperGame
    {
        private IPlayer _player;
        private IGameDisplay _gameDisplay;
        private IMineService _mineService;
        private int _boardSize;

        public MinesweeperGame(IPlayer player, IGameDisplay gameDisplay, IMineService mineService, int boardSize)
        {
            _player = player;
            _gameDisplay = gameDisplay;
            _mineService = mineService;
            _boardSize = boardSize;
        }

        public void PlayGame()
        {
            while (_player.Lives > 0)
            {
                _gameDisplay.DisplayBoard();  // Display the board and any queued messages

                string move = Console.ReadLine().ToLower();  // Get the player move input

                // Check if the move is valid
                if (!IsValidMove(move))
                {
                    _gameDisplay.DisplayMessage("Invalid move direction! Use: up, down, left, right.");
                    continue;  // Don't count this as a move
                }

                Position previousPosition = _player.Position;
                _player.Move(move);  // Update the player position

                // Check if the move is out of bounds
                if (_player.IsOutOfBounds(_boardSize))
                {
                    _gameDisplay.DisplayMessage("Move out of bounds! Try a different direction.");
                    _player.ResetPosition(previousPosition);  // Revert the move
                    continue;  // Don't count this as a move
                }

                // Only count the move if it's valid and within bounds
                _player.Moves++;

                // Check if the player stepped on a mine
                if (_mineService.IsMine(_player.Position))
                {
                    _mineService.DisarmMine(_player.Position);  // Disarm the mine
                    _player.TakeDamage();  // Reduce lives
                    _gameDisplay.DisplayMessage($"Boom! You stepped on a mine at {PositionToString(_player.Position)}.");
                }
                else
                {
                    //_gameDisplay.ClearMessages(); // Clear the message queue if no mine is hit
                }

                // If the player reaches the other side (last column), they win
                if (_player.Position.x == _boardSize - 1)
                {
                    _gameDisplay.DisplayMessage($"You win! Reached the other side with {_player.Moves} moves.");
                    break;
                }
            }

            if (_player.Lives == 0)
            {
                _gameDisplay.DisplayMessage("Game Over! You lost all your lives.");
            }
        }

        // Method to check if the move direction is valid
        private bool IsValidMove(string move)
        {
            return move == "up" || move == "down" || move == "left" || move == "right";
        }

        // Convert a Position to a readable string format (e.g., A1, B2)
        private string PositionToString(Position position)
        {
            char column = (char)('A' + position.x);  // Convert x to a column letter
            int row = position.y + 1;  // Convert y to a 1-based index for row
            return $"{column}{row}";
        }
    }
}
