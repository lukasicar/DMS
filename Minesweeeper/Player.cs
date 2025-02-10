namespace Minesweeeper
{
    public class Player : IPlayer
    {
        public Position Position { get; set; }
        public int Lives { get; set; }
        public int Moves { get; set; }

        public Player(Position startPosition, int initialLives)
        {
            Position = startPosition;
            Lives = initialLives;
            Moves = 0;
        }

        public void Move(string direction)
        {
            switch (direction.ToLower())
            {
                case "up":
                    Position = new Position(Position.x, Position.y - 1);
                    break;
                case "down":
                    Position = new Position(Position.x, Position.y + 1);
                    break;
                case "left":
                    Position = new Position(Position.x - 1, Position.y);
                    break;
                case "right":
                    Position = new Position(Position.x + 1, Position.y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }
        }

        // Check if the player is outside the board's bounds
        public bool IsOutOfBounds(int boardSize)
        {
            return Position.x < 0 || Position.x >= boardSize || Position.y < 0 || Position.y >= boardSize;
        }

        // Deduct a life when the player hits a mine
        public void TakeDamage()
        {
            Lives--;
        }

        // Reset player position to a new location
        public void ResetPosition(Position newPosition)
        {
            Position = newPosition;
        }
    }
}