// A game of tic-tac-toe playable by two local players in a console window

new GameRunner().Run();

public class Player
{
    // Keeps track of the current players stats and enables them to play a turn

    public string Name { get; }
    public int Wins { get; set; }
    public Cell Symbol { get; }

    public Player(string name, Cell symbol)
    {
        this.Name = name;
        this.Symbol = symbol;
        this.Wins = 0;
    }

    public void PickCell(Board board)
    {
        // Allows the player to pick where to place their symbol on the board

        while (true)
        {
            Console.Write("\nWhich cell do you want to play? ");
            ConsoleKey key = Console.ReadKey().Key;

            Coord choice = key switch
            {
                ConsoleKey.NumPad7 => new Coord(0, 0),
                ConsoleKey.NumPad8 => new Coord(0, 1),
                ConsoleKey.NumPad9 => new Coord(0, 2),
                ConsoleKey.NumPad4 => new Coord(1, 0),
                ConsoleKey.NumPad5 => new Coord(1, 1),
                ConsoleKey.NumPad6 => new Coord(1, 2),
                ConsoleKey.NumPad1 => new Coord(2, 0),
                ConsoleKey.NumPad2 => new Coord(2, 1),
                ConsoleKey.NumPad3 => new Coord(2, 2),
                _ => new Coord(3,3)
            };

            if (choice.Row == 3)
            {
                // If the key pressed was not a valid numpad key prompt to re-enter
                Console.WriteLine("\nUse the numpad to select a cell. ");
            }
            else if (board.IsEmpty(choice.Row, choice.Column))
            {
                // If the key pressed is valid and the cell is empty, place the players symbol on the board and return
                board.FillCell(choice.Row, choice.Column, Symbol);
                return;
            }
            else
            {
                // if the key pressed is valid but the cell is already occupied prompt to re-enter
                Console.WriteLine("\nThat cell is already taken");
            }
        }
    }
}

public class Coord
{
    // A 2D coordinate allowing a row-column value to be stored

    public int Row { get; }
    public int Column { get; }

    public Coord(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }
}

public class Board
{
    // Keeps track of the current status of the board and played symbols

    public Cell[,] Cells { get; set; }

    public Board()
    {
        this.Cells = new Cell[3,3];
    }

    public Cell ContentsOf(int row, int column) => Cells[row, column];
    public void FillCell(int row, int column, Cell value) => Cells[row, column] = value;
    public bool IsEmpty(int row, int column) => Cells[row, column] == Cell.Empty;
    private char GetChar(Cell cell) => cell switch { Cell.Empty => ' ', Cell.O => 'O', Cell.X => 'X' };
    
    public void Print()
    {
        // Print out the current state of the board
        Console.Clear();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + GetChar(Cells[i, j]));

                if (j != 2)
                {
                    Console.Write(" |");
                }
            }

            if (i != 2)
            {
                Console.WriteLine("\n---+---+---");
            }
        }
    }
}

public class GameRunner
{
    public void Run()
    {
        // Run the whole game

        Console.Write("Player 1 name: ");
        Player player1 = new Player(Console.ReadLine(), Cell.X);

        Console.Write("Player 2 name: ");
        Player player2 = new Player(Console.ReadLine(), Cell.O);

        Console.Write("How many rounds do you want to play? ");
        int totalRounds = Convert.ToInt32(Console.ReadLine());

        // Run the number of user-defined rounds
        for (int roundNumber = 1; roundNumber <= totalRounds; roundNumber++)
        {
            NewRound(player1, player2, roundNumber, totalRounds);

            // If all rounds have been played, display the winner of the most rounds
            if (roundNumber == totalRounds)
            {
                if (player1.Wins > player2.Wins)
                {
                    Console.WriteLine($"\n{player1.Name} is the winner with {player1.Wins} out of {totalRounds} wins!");
                }
                else if ((player1.Wins < player2.Wins))
                {
                    Console.WriteLine($"\n{player2.Name} is the winner with {player2.Wins} out of {totalRounds} wins!");
                }
                else
                {
                    Console.WriteLine($"\nDraw! After {totalRounds} rounds, both players won {player1.Wins} rounds.");
                }
            }
            else
            {
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
        }
    }

    private void NewRound(Player player1, Player player2, int roundNumber, int totalRounds)
    {
        // Begin a new round

        Board board = new Board();
        Player currentPlayer = player1;
        int turnNumber = 0;

        // Keep looping through turns - if 9 turns have been played, all cells are full and it is a draw
        while (turnNumber < 9)
        {
            // Print the board and ask the current player for their input
            board.Print();
            Console.WriteLine($"\nIt is {currentPlayer.Name}'s turn ({currentPlayer.Symbol}).");
            currentPlayer.PickCell(board);

            // Check if the current players turn has caused a win
            if (HasWon(board, currentPlayer.Symbol))
            {
                Console.Clear();
                board.Print();

                Console.WriteLine($"\n\n{currentPlayer.Name} ({currentPlayer.Symbol}) has won round {roundNumber}/{totalRounds}!");
                currentPlayer.Wins++;

                Console.WriteLine($"\n{player1.Name} has {player1.Wins} wins and {player2.Name} has {player2.Wins} wins.");
                return;
            }

            // Switch player
            currentPlayer = currentPlayer == player1 ? player2 : player1;
            turnNumber++;
        }
        board.Print();

        Console.WriteLine($"\n\nDraw for round {roundNumber}/{totalRounds}.");
        Console.WriteLine($"\n{player1.Name} has {player1.Wins} wins and {player2.Name} has {player2.Wins} wins.");
    }

    private bool HasWon(Board board, Cell symbol)
    {
        // Checks whether there is a row of three symbols - causing a win

        // Rows
        if (board.Cells[0, 0] == symbol && board.Cells[0, 1] == symbol && board.Cells[0, 2] == symbol) return true;
        if (board.Cells[1, 0] == symbol && board.Cells[1, 1] == symbol && board.Cells[1, 2] == symbol) return true;
        if (board.Cells[2, 0] == symbol && board.Cells[2, 1] == symbol && board.Cells[2, 2] == symbol) return true;

        // Columns
        if (board.Cells[0, 0] == symbol && board.Cells[1, 0] == symbol && board.Cells[2, 0] == symbol) return true;
        if (board.Cells[0, 1] == symbol && board.Cells[1, 1] == symbol && board.Cells[2, 1] == symbol) return true;
        if (board.Cells[0, 2] == symbol && board.Cells[1, 2] == symbol && board.Cells[2, 2] == symbol) return true;

        // Diagonals
        if (board.Cells[0, 0] == symbol && board.Cells[1, 1] == symbol && board.Cells[2, 2] == symbol) return true;
        if (board.Cells[0, 2] == symbol && board.Cells[1, 1] == symbol && board.Cells[2, 0] == symbol) return true;

        return false;
    }
}

public enum Cell { Empty, X, O };