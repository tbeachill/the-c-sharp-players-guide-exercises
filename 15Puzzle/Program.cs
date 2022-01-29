// 15 puzzle game that runs in a console window

bool gridSelected = false;

// While a grid size has not been chosen, keep prompting until one has, then create a new game
while (gridSelected == false)
{
    Console.Write("How large do you want the grid to be? ");
    if (Int32.TryParse(Console.ReadLine(), out int gridSize))   // check input is a valid int
    {
        if (gridSize == 0 || gridSize == 1)
        {
            Console.WriteLine($"Cannot create a grid of {gridSize}x{gridSize}. Default size of 4x4 will be used.");

            Game currentGame = new Game(4);
        }
        else
        {
            Game currentGame = new Game(gridSize);
        }

        gridSelected = true;
    }
    else
    {
        Console.WriteLine("Only numbers are accepted");
    }

    // Check if the user wants to play another game - Will run after the last game has finished
    while (gridSelected == true)
    {
        Console.Write("Do you want to play again? (Y/N): ");
        if (Char.TryParse(Console.ReadLine(), out char replay))
        {
            if (replay == 'Y' || replay == 'y')
            {
                Console.Clear();
                gridSelected = false;
            }
            else if (replay == 'N' || replay == 'n')
            {
                Environment.Exit(0);
            }

        }
    }
}

public class Game
{
    // Class for the main game logic

    public int MoveCounts { get; set; }
    public bool Won = false;
    public int BoardSize { get; set; }

    public Game(int boardSize)
    {
        Board currentBoard = new Board(4);
        // Set up a new game and check it is solvable before proceeding
        this.BoardSize = boardSize;
        do
        {
            currentBoard = new Board(boardSize);
        }
        while (Math.CheckSolvable(currentBoard) == false);

        Console.WriteLine();
        currentBoard.PrintBoard();

        // Continue the game until the user has won
        while (Won == false)
        {
            AcceptInput(currentBoard);
        }

        Console.WriteLine();
        Console.WriteLine("Congratulations! You have won!\n");
    }

    private void AcceptInput(Board currentBoard)
    {
        // Accepts arrow key inputs from the user and calls the shift tile function accordingly

        var ch = Console.ReadKey(false).Key;
        switch (ch)
        {
            case ConsoleKey.UpArrow:
                currentBoard.ShiftTile(currentBoard.CurrentBoard, ConsoleKey.UpArrow);
                CheckStatus(currentBoard);
                break;
            case ConsoleKey.DownArrow:
                currentBoard.ShiftTile(currentBoard.CurrentBoard, ConsoleKey.DownArrow);
                CheckStatus(currentBoard);
                break;
            case ConsoleKey.RightArrow:
                currentBoard.ShiftTile(currentBoard.CurrentBoard, ConsoleKey.RightArrow);
                CheckStatus(currentBoard);
                break;
            case ConsoleKey.LeftArrow:
                currentBoard.ShiftTile(currentBoard.CurrentBoard, ConsoleKey.LeftArrow);
                CheckStatus(currentBoard);
                break;
        }
    }

    private void CheckStatus(Board currentBoard)
    {
        // Function to run after every tile shift to check the current status of the game

        if (CheckOrder(currentBoard))
        {
            Won = true;
        }
        else
        {
            currentBoard.PrintBoard();
        }
    }

    public bool CheckOrder(Board currentBoard)
    {
        // Check if the tile numbers are in numerical order

        int[] boardSequence = currentBoard.GetBoardSequence();

        for (int i = 0; i < boardSequence.Length - 1; i++)
        {
            if (boardSequence[i + 1] != boardSequence[i] + 1 && boardSequence[i + 1] != 0)
            {
                return false;
            }
        }

        // If the above loop doesn't return
        return true;
    }
}

public class Board
{
    // Class for the board of tiles

    public int BoardSize;
    public int[][] NumberBoard { get; set; }
    public Tile[][] CurrentBoard { get; set; }

    public Board(int boardSize)
    {
        // Store board size, then create int matrix, then create tile matrix
            
        this.BoardSize = boardSize;
        this.NumberBoard = Math.MatCreate(boardSize, boardSize);
        this.CurrentBoard = new Tile[BoardSize][];

        for (int i = 0; i < BoardSize; i++)
        {
            CurrentBoard[i] = new Tile[BoardSize];
        }

        this.CurrentBoard = CreateBoard(NumberBoard);
    }

    private Tile[][] CreateBoard(int[][] numberBoard)
    {
        // Create a tile object matrix with the number corresponding to the int matrix

        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                CurrentBoard[x][y] = new Tile(numberBoard[x][y]);
            }
        }

        return CurrentBoard;
    }

    public void ShiftTile(Tile[][] currentBoard, ConsoleKey input)
    {
        // Swap the 0 with the opposite side of the arrow, unless the 0 is at the edge

        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                if (currentBoard[x][y].Number == 0)
                {
                    try
                    {
                        switch (input)
                        {
                            case ConsoleKey.UpArrow:
                                // Move 0 down
                                (currentBoard[x][y], currentBoard[x + 1][y]) = (currentBoard[x + 1][y], currentBoard[x][y]);
                                return;
                            case ConsoleKey.DownArrow:
                                // Move 0 up
                                (currentBoard[x][y], currentBoard[x - 1][y]) = (currentBoard[x - 1][y], currentBoard[x][y]);
                                return;
                            case ConsoleKey.RightArrow:
                                // Move 0 left
                                (currentBoard[x][y], currentBoard[x][y - 1]) = (currentBoard[x][y - 1], currentBoard[x][y]);
                                return;
                            case ConsoleKey.LeftArrow:
                                // Move 0 right
                                (currentBoard[x][y], currentBoard[x][y + 1]) = (currentBoard[x][y + 1], currentBoard[x][y]);
                                return;
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        return;
                    }
                }
            }
        }
    }

    public void PrintBoard()
    {
        // Print the board to console, ensuring correct spacing between tiles and ignoring 0 (space)
        Console.Clear();

        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                int digits = CurrentBoard[x][y].Number.ToString().Length;

                if (CurrentBoard[x][y].Number != 0)
                {
                    Console.Write(Convert.ToString(CurrentBoard[x][y].Number + String.Concat(Enumerable.Repeat(" ", 5 - digits))));
                } 
                else
                {
                    Console.Write(" " + String.Concat(Enumerable.Repeat(" ", 4))); // replace 0 with whitespace
                }

                // Print two lines at the end of each row
                if (y == BoardSize - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }

    public int[] GetBoardSequence()
    {
        // Get a 1D array of the sequence of numbers from the board

        int i = 0;
        int[] boardSequence = new int[BoardSize * BoardSize];
        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                boardSequence[i] = CurrentBoard[x][y].Number;
                i++;
            }
        }

        return boardSequence;
    }

    public (int?, int?) GetSpaceLocation()
    {
        // Get the location of the 0 (space)

        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                if (CurrentBoard[x][y].Number == 0)
                {
                    return (x, y);
                }
            }
        }

        return (null, null);
    }
}

public class Tile
{
    // Represents a single tile on the board

    public int Number { get; set; }

    public Tile(int number)
    {
        this.Number = number;
    }
}

public static class Math
{
    public static int[][] MatCreate(int rows, int cols)
    {
        // create a new grid of 0s
        int numberLength = (rows * cols) - 1;
        int[] numberArray = ShuffleNumbers(numberLength);
            
        int[][] newBoard = new int[rows][];
        for (int i = 0; i < rows; ++i)
            newBoard[i] = new int[cols];

        // assign numbers to each position in the grid
        int j = 0;

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                newBoard[x][y] = numberArray[j];
                j++;
            }
        }

        return newBoard;
    }

    private static int[] ShuffleNumbers(int num)
    {
        // Create an array from 1 to {num} and randomly shuffle the array

        int[] numberArray = Enumerable.Range(1, num).ToArray(); // create array of sequence
        Array.Resize(ref numberArray, num + 1);   // add an extra number for the space

        Random random = new Random();
        numberArray = numberArray.OrderBy(x => random.Next()).ToArray();    // shuffle the sequence

        return numberArray;
    }
        
    public static bool CheckSolvable(Board currentBoard)
    {
        // Check that the current board is solvable

        // Create a 1D array from the current board
        int[] numberArray = currentBoard.GetBoardSequence();
        int inversions = CountInversions(numberArray);

        // If board width is odd and the number of inversions is even the puzzle is solvable
        if (currentBoard.BoardSize % 2 != 0 && inversions % 2 == 0)
        {
            return true;
        }
        else if (currentBoard.BoardSize % 2 != 0 && inversions % 2 != 0)
        {
            return false;
        }
        else
        {
            (int? x, int? y) = currentBoard.GetSpaceLocation();
            if (x.HasValue)
            {
                // Count how many rows from the bottom the space is
                int? rowFromBottom = currentBoard.BoardSize - x;

                // Puzzle is solvable if row from bottom is even and inversions are odd, or row is odd and inversions are even
                if (rowFromBottom % 2 == 0 && inversions % 2 != 0)
                {
                    return true;
                }
                else if (rowFromBottom % 2 != 0 && inversions % 2 == 0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static int CountInversions(int[] numberArray)
    {
        // Count the number of inversions for a sequence of numbers

        int inversionCount = 0;

        // Go through every number in the array
        for (int i = 0; i < numberArray.Length; i++)
        {
            // Go through every number after i in the array
            for (int j = i + 1; j < numberArray.Length; j++)
            {
                if (numberArray[i] > numberArray[j] && numberArray[j] != 0)
                {
                    inversionCount++;
                }
            }
        }

        return inversionCount;
    }
}

static class ArrayExtensions
{
    public static int IndexOf<T>(this T[] array, T value)
    {
        return Array.IndexOf(array, value);
    }
}
