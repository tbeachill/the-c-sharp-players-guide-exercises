// check addition of a BlockOffset works
BlockCoordinate coord = new BlockCoordinate(0, 0);
Console.WriteLine(coord);
BlockCoordinate newCoord = coord + new BlockOffset(1, 0);
Console.WriteLine(newCoord);
newCoord = coord + new BlockOffset(0, 1);
Console.WriteLine(newCoord);

// check addition of a Direction works
Console.WriteLine();
newCoord = coord + Direction.North;
Console.WriteLine(newCoord);
newCoord = coord + Direction.East;
Console.WriteLine(newCoord);

// check indexer works
Console.WriteLine();
Console.WriteLine(newCoord[0]);
Console.WriteLine(newCoord[1]);
//Console.WriteLine(newCoord[2]);

// check conversion works
Console.WriteLine();
Console.WriteLine((BlockOffset) Direction.East);
Console.WriteLine((BlockOffset) Direction.South);

public enum Direction { North, East, South, West }
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    // conversion from Direction to BlockOffset
    public static implicit operator BlockOffset(Direction d)
    {
        return d switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.East  => new BlockOffset(0, 1),
            Direction.South => new BlockOffset(1, 0),
            Direction.West  => new BlockOffset(0, -1)
        };
    }
}

public record BlockCoordinate(int Row, int Column)
{


    // indexer to return the row or column value by supplying 0 or 1
    public int this[int number]
    {
        get
        {
            if (number == 0) return Row;
            else if (number == 1) return Column;
            else throw new Exception("Not a valid index.");
        }
    }

    // return a new BlockCoordinate that is a combination of a BlockCoordinate and BlockOffset
    public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);
    // return a new BlockCoordinate that is 1 in the direction supplied
    public static BlockCoordinate operator +(BlockCoordinate a, Direction b)
    {
        return b switch
        {
            Direction.North => new BlockCoordinate(a.Row - 1, a.Column),
            Direction.East  => new BlockCoordinate(a.Row, a.Column + 1),
            Direction.South => new BlockCoordinate(a.Row + 1, a.Column),
            Direction.West  => new BlockCoordinate(a.Row, a.Column - 1)
        };
    }
}
