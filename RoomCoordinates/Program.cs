/*
 * ROOM LAYOUT
 * ┌───┬───┬───┐
 * │   │ A │   │
 * ├───┼───┼───┤
 * │   │ C │ B │
 * ├───┼───┼───┤
 * │   │   │   │
 * └───┴───┴───┘
*/

Room roomA = new Room(1, 2);
Room roomB = new Room(2, 1);
Room roomC = new Room(1, 1);

// test the AreAdjacent function
Console.WriteLine(Room.AreAdjacent(roomA, roomB));  // false
Console.WriteLine(Room.AreAdjacent(roomA, roomC));  // true
Console.WriteLine(Room.AreAdjacent(roomB, roomC));  // true

public struct Room
{
    public int X { get; }
    public int Y { get; }

    public Room(int x, int y)
    {
        X = x; Y = y; 
    }

    public static bool AreAdjacent(Room a, Room b)
    {
        // check if two given rooms are adjacent

        int xDiff = a.X - b.X;
        int yDiff = a.Y - b.Y;

        if ( (Math.Abs(xDiff) == 1 && yDiff == 0) || (Math.Abs(yDiff) == 1 && xDiff == 0) )
        {
            return true;
        }

        return false;
    }
}
