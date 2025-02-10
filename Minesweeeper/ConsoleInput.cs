namespace Minesweeeper
{
    public class ConsoleInput : IGameInput
    {
        public string? GetMoveInput()
        {
            Console.WriteLine("Enter move (up, down, left, right): ");
            return Console.ReadLine();
        }
    }
}
