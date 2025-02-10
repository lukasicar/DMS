namespace Minesweeeper
{
    public class MineService : IMineService
    {
        private HashSet<Position> _mines;
        private Random _random;

        // Constructor to place a number of mines randomly on the grid
        public MineService(int numberOfMines)
        {
            _mines = new HashSet<Position>();
            _random = new Random();

            // Place mines randomly on the grid
            while (_mines.Count < numberOfMines)
            {
                var mine = new Position(_random.Next(0, 5), _random.Next(0, 5));  // Default to 5x5 grid (or dynamically use board size)
                _mines.Add(mine);
            }
        }

        // Check if a given position contains a mine
        public bool IsMine(Position position)
        {
            return _mines.Contains(position);
        }

        // Disarm a mine when the player steps on it
        public void DisarmMine(Position position)
        {
            _mines.Remove(position);
        }
    }
}
