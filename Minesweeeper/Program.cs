using Minesweeeper;

public class Program
{
    static void Main(string[] args)
    {
        // Setup the game parameters
        int boardSize = 5; // For example, a 5x5 board
        int numberOfMines = 3; // Number of mines to place on the board
        int playerLives = 3; // Initial lives of the player

        // Initialize the components
        Player player = new Player(new Position(0, 0), playerLives); // Player starts at position A1
        IMineService mineService = new MineService(numberOfMines);
        IGameDisplay gameDisplay = new ConsoleGameDisplay(player, boardSize, mineService);

        // Initialize the game
        MinesweeperGame game = new MinesweeperGame(player, gameDisplay, mineService, boardSize);

        // Start the game
        game.PlayGame();
    }
}