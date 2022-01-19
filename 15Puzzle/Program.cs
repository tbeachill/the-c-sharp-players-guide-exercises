Board currentBoard = new Board(4);
currentBoard.PrintBoard();

public class Board
{
    public int BoardSize;
    public int[][] CurrentBoard { get; set; }
    public Board(int boardSize)
    {
        this.BoardSize = boardSize;
        this.CurrentBoard = CreateBoard(BoardSize);
    }

    private int[][] CreateBoard(int boardSize)
    {
        CurrentBoard = Math.MatCreate(boardSize, boardSize);
        
        return CurrentBoard;
    }

    public void PrintBoard()
    {
        for (int x = 0; x < this.BoardSize; x++)
        {
            for (int y = 0; y < this.BoardSize; y++)
            {
                if (y == 0 && x != 0)
                    Console.WriteLine();

                Console.Write(Convert.ToString(CurrentBoard[x][y] + " "));
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