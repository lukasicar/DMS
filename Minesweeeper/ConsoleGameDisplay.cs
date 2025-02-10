namespace Minesweeeper
{
    public class ConsoleGameDisplay : IGameDisplay
    {
        private Player _player;
        private int _boardSize;
        private IMineService _mineService;
        private Queue<string> _messageQueue;  // Now the message queue is inside the display

        public ConsoleGameDisplay(Player player, int boardSize, IMineService mineService)
        {
            _player = player;
            _boardSize = boardSize;
            _mineService = mineService;
            _messageQueue = new Queue<string>();  // Initialize the message queue inside the display
        }

        public void DisplayBoard()
        {
            Console.Clear(); // Clear the console before rendering

            // Display the board
            for (int y = 0; y < _boardSize; y++)
            {
                for (int x = 0; x < _boardSize; x++)
                {
                    var currentPosition = new Position(x, y);

                    if (_player.Position.Equals(currentPosition))
                        Console.Write("[P] "); // Player's position
                    else if (_mineService.IsMine(currentPosition))
                        Console.Write("[ ] "); // Mine position (hidden to the player)
                    else
                        Console.Write("[ ] "); // Empty space
                }
                Console.WriteLine();
            }

            // Display messages from the queue (if any)
            while (_messageQueue.Count > 0)
            {
                string message = _messageQueue.Dequeue();
                Console.WriteLine(message);
            }

            // Display player stats: position, lives, moves
            Console.WriteLine($"Player Position: {_player.Position}");
            Console.WriteLine($"Lives: {_player.Lives}, Moves: {_player.Moves}");
        }

        public void DisplayMessage(string message)
        {
            // Add the message to the queue so it can be displayed later
            Console.WriteLine(message);
            _messageQueue.Enqueue(message);
        }
    }
}
