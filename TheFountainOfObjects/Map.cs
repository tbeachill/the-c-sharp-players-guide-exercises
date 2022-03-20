/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
    public class Map
    {
        public int MapSize { get; }
        public Room[,] Rooms { get; }
        public Coord FountainPos { get; }
        public Coord[] Coords { get; } = new Coord[4];

        public Map(int mapSize)
        {
            // generate a new map of rooms with a specified size

            Rooms = new Room[mapSize, mapSize];
            MapSize = mapSize;

            // Pick random positions for the features and ensure they don't overlap
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                int x;
                int y;
                bool inCoords;
                do
                {
                    x = r.Next(0, mapSize - 1);
                    y = r.Next(0, mapSize - 1);

                    inCoords = false;
                    foreach (Coord c in Coords)
                    {
                        // make sure there isn't already a feature there and isn't put near the entrance
                        if (c.X == x && c.Y == y || (c.X == 0 && c.Y == 1) || (c.X == 1 && c.Y == 0))
                            inCoords = true;
                    }
                }
                while (inCoords == true);
                Coords[i].X = x;
                Coords[i].Y = y;
            }

            // generate the map
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    // fill the rooms with empty features
                    Rooms[x, y] = new Room(x, y, new MapFeature());
                }
            }

            // add entrance
            Rooms[0, 0] = new Room(0, 0, new Entrance());

            // add fountain
            Rooms[Coords[0].X, Coords[0].Y] = new Room(Coords[0].X, Coords[0].Y, new FountainOfObjects());
            FountainPos = new Coord(Coords[0].X, Coords[0].Y);

            // add pits
            for (int i = 1; i < (MapSize / 2); i++)
            {
                Rooms[Coords[i].X, Coords[i].Y] = new Room(Coords[i].X, Coords[i].Y, new BottomlessPit());
            }

            // add pit descriptions to surrounding rooms if it doesn't already exist
            for (int i = 1; i < (MapSize / 2); i++)
            {
                foreach (Coord c in Room.GetSurroundingRooms(Rooms[Coords[i].X, Coords[i].Y], MapSize))
                {
                    // Make sure the desc hasn't already been appended and that the coord isn't empty
                    if (Rooms[c.X, c.Y].PitDesc == false && !(c.X == 0 && c.Y == 0))
                    {
                        Rooms[c.X, c.Y].Contents.Description += "\nYou feel a draft. There is a pit in a nearby room.";
                        Rooms[c.X, c.Y].PitDesc = true;
                    }
                }
            }
        }
    }


    public struct Coord
    {
        public int X = 0;
        public int Y = 0;

        public Coord(int x, int y)
        {
            X = x; Y = y;
        }
    }
}
