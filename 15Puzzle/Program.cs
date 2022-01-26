// TODO Replace for loops for finding 0 with a FindSpace function that returns an x and y value.
// TODO Check if puzzle is solvable https://www.geeksforgeeks.org/check-instance-15-puzzle-solvable/
// TODO Check number of inversions
// TODO Write function

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
        Console.WriteLine("Do you want to play again? (Y/N): ");
        if (Char.TryParse(Console.ReadLine(), out char replay))
        {
            if (replay == 'Y')
            {
                gridSelected = false;
            }
            else if (replay == 'N')
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
        while (this.Won == false)
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
        if (CheckOrder(currentBoard.CurrentBoard))
        {
            Won = true;
        }
        else
        {
            currentBoard.PrintBoard();
        }
    }

    public bool CheckOrder(Tile[][] currentBoard)
    {
        int i = 0;
        // Check the order of the tile numbers.
        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                if (currentBoard[x][y].Number == i + 1 || currentBoard[x][y].Number == i && i != BoardSize * BoardSize)
                {
                    // proceed
                }
                else
                {
                    return false;
                }
            }
        }

        // If the above loop doesn't return
        return true;

    }
}
public class Board
{
    public int BoardSize;
    public int[][] NumberBoard { get; set; }
    public Tile[][] CurrentBoard { get; set; }

    public Board(int boardSize)
    {
        // store board size, then create int matrix, then create tile matrix
            
        this.BoardSize = boardSize;
        this.NumberBoard = Math.MatCreate(boardSize, boardSize);
        this.CurrentBoard = new Tile[BoardSize][];

        for (int i = 0; i < this.BoardSize; i++)
        {
            CurrentBoard[i] = new Tile[BoardSize];
        }

        CurrentBoard = CreateBoard(NumberBoard);
    }

    private Tile[][] CreateBoard(int[][] numberBoard)
    {
        // create a tile object matrix with the number corresponding to the int matrix

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

        // swap the 0 with the opposite side of the arrow, unless the 0 is at the edge
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
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
                                Console.Clear();
                                return;
                            case ConsoleKey.DownArrow:
                                // Move 0 up
                                (currentBoard[x][y], currentBoard[x - 1][y]) = (currentBoard[x - 1][y], currentBoard[x][y]);
                                Console.Clear();
                                return;
                            case ConsoleKey.RightArrow:
                                // Move 0 left
                                (currentBoard[x][y], currentBoard[x][y - 1]) = (currentBoard[x][y - 1], currentBoard[x][y]);
                                Console.Clear();
                                return;
                            case ConsoleKey.LeftArrow:
                                // Move 0 right
                                (currentBoard[x][y], currentBoard[x][y + 1]) = (currentBoard[x][y + 1], currentBoard[x][y]);
                                Console.Clear();
                                return;
                        }
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                        Console.Clear();
                        return;
                    }

                }
            }
        }
    }

    public void PrintBoard()
    {
        // print the board to console, ensuring correct spacing between tiles and ignoring 0 (space)
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {
                int digits = CurrentBoard[x][y].Number.ToString().Length;

                if (CurrentBoard[x][y].Number != 0)
                    Console.Write(Convert.ToString(CurrentBoard[x][y].Number + String.Concat(Enumerable.Repeat(" ", digits + 1))));
                else
                    Console.Write(" " + String.Concat(Enumerable.Repeat(" ", digits))); // replace 0 with whitespace

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
        int[] boardSequence = new int[BoardSize * BoardSize];
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {
                boardSequence.Append(CurrentBoard[x][y].Number);
            }
        }

        return boardSequence;
    }

    public (int?, int?) GetSpaceLocation()
    {
        // Get the location of the 0 (space)
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {
                if (CurrentBoard[x][y].Number == 0)
                {
                    return (x, y);
                }
            }
        }

        return (null, null);
    }

    /*
    public Tile IterateTile(Board currentBoard)
    {
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {

            }
        }
    }
    */
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

    // Create an array from 1 to {num} and randomly shuffle the array
    private static int[] ShuffleNumbers(int num)
    {
        int[] numberArray = Enumerable.Range(1, num).ToArray(); // create array of sequence

        Array.Resize(ref numberArray, num + 1);   // add an extra number for the space

        Random random = new Random();
        numberArray = numberArray.OrderBy(x => random.Next()).ToArray();    // shuffle the sequence

        return numberArray;
    }
        
    public static bool CheckSolvable(Board currentBoard)
    {
        // Create a 1D array from the current board
        int[] numberArray = currentBoard.GetBoardSequence();

        int inversions = CountInversions(numberArray);
        // If length is odd and the number of inversions is even the puzzle is solvable
        if (numberArray.Length % 2 != 0 && inversions % 2 == 0)
        {
            return true;
        }
        else
        {
            (int? x, int? y) = currentBoard.GetSpaceLocation();
            if (x.HasValue)
            {
                // Count how many rows from the bottom the space is
                int? rowFromBottom = currentBoard.BoardSize - (x - 1);

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
        for (int i = 1; i < numberArray.Length; i++)
        {
            // Go through every number after i in the array
            for (int j = i + 1; j < numberArray.Length; j++)
            {
                if (numberArray[i] > numberArray[j])
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