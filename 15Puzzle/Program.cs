// Replace for loops for finding 0 with a FindSpace function that returns an x and y value.

bool gridSelected = false;

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
    public int MoveCounts { get; set; }
    public bool Won = false;
    public int BoardSize { get; set; }

    public Game(int boardSize)
    {
        this.BoardSize = boardSize;
        Board currentBoard = new Board(boardSize);
        Console.WriteLine();
        currentBoard.PrintBoard();

        while (this.Won == false)
        {
            AcceptInput(currentBoard);
        }

        Console.WriteLine();
        Console.WriteLine("Congratulations! You have won!");
        

    }

    private void AcceptInput(Board currentBoard)
    {
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

    public class Board
    {
        public int BoardSize;
        public int[][] NumberBoard { get; set; }
        public Tile[][] CurrentBoard { get; set; }



        public Board(int boardSize)
        {
            // store board size, then create int matrix, then create tile matrix and check if solvable
            do
            {
                this.BoardSize = boardSize;
                this.NumberBoard = Math.MatCreate(boardSize, boardSize);
                this.CurrentBoard = new Tile[BoardSize][];

                for (int i = 0; i < this.BoardSize; i++)
                {
                    CurrentBoard[i] = new Tile[BoardSize];
                }

                CurrentBoard = CreateBoard(NumberBoard);
            }
            while (!Math.CheckSolvable(NumberBoard));
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
                                    // move 0 down
                                    (currentBoard[x][y], currentBoard[x + 1][y]) = (currentBoard[x + 1][y], currentBoard[x][y]);
                                    Console.Clear();
                                    return;
                                case ConsoleKey.DownArrow:
                                    (currentBoard[x][y], currentBoard[x - 1][y]) = (currentBoard[x - 1][y], currentBoard[x][y]);
                                    Console.Clear();
                                    return;
                                case ConsoleKey.RightArrow:
                                    (currentBoard[x][y], currentBoard[x][y - 1]) = (currentBoard[x][y - 1], currentBoard[x][y]);
                                    Console.Clear();
                                    return;
                                case ConsoleKey.LeftArrow:
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

                    if (y == BoardSize - 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
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


    }

    public class Tile
    {
        public int Number { get; set; }

        public Tile(int number)
        {
            this.Number = number;
        }
    }

    public class Math
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
            int[] numberArray = Enumerable.Range(1, num).ToArray(); // create array of sequence

            Array.Resize(ref numberArray, num + 1);   // add an extra number for the space

            Random random = new Random();
            numberArray = numberArray.OrderBy(x => random.Next()).ToArray();    // shuffle the sequence

            return numberArray;
        }
        /*
        public bool CheckSolvable()
        {

        }

        private int CountInversions()
        {

        }
        */
    }
}