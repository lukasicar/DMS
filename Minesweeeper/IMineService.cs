namespace Minesweeeper
{
    public interface IMineService
    {
        bool IsMine(Position position);
        void DisarmMine(Position position);
    }
}
