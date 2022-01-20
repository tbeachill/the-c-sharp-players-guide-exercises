Board currentBoard = new Board(4);
currentBoard.PrintBoard();

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

    public void PrintBoard()
    {
        // print the board to console, ensuring correct spacing between tiles and ignoring 0 (space)

        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {
                int digits = 3;
                if (CurrentBoard[x][y].Number.ToString().Length == 2) digits = 2;

                if (CurrentBoard[x][y].Number != 0)
                    Console.Write(Convert.ToString(CurrentBoard[x][y].Number + String.Concat(Enumerable.Repeat(" ", digits))));
                else
                    Console.Write(" " + String.Concat(Enumerable.Repeat(" ", digits))); // replace 0 with whitespace

                if (y == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
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

        Array.Resize(ref numberArray, num+1);   // add an extra number for the space
        
        Random random = new Random();
        numberArray = numberArray.OrderBy(x => random.Next()).ToArray();    // shuffle the sequence

        return numberArray;
    }
}