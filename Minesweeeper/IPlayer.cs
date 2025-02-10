namespace Minesweeeper
{
    public interface IPlayer
    {
        Position Position { get; set; }
        int Lives { get; set; }
        int Moves { get; set; }

        void Move(string direction);
        bool IsOutOfBounds(int boardSize);
        void TakeDamage();
        void ResetPosition(Position newPosition);
    }
}
