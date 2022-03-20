/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
    public struct Room
    {
        public int X { get; }
        public int Y { get; }
        public dynamic Contents { get; }
        public bool PitDesc { get; set; } = false;

        public Room(int x, int y, MapFeature contents)
        {
            X = x; Y = y; Contents = contents;
        }

        public static Coord[] GetSurroundingRooms(Room room, int mapSize)
        {
            // get a list of rooms that surround the input room

            Coord[] roomList = new Coord[8];

            int k = 0;
            for (int i = -1; i < 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    if (room.X + i >= 0 && room.X + i < mapSize && room.Y + i >= 0 && room.Y + 1 < mapSize)
                    {
                        roomList[k] = new Coord(room.X + i, room.Y + j);
                    }
                    k++;
                }
            }

            return roomList;
        }

        public string Description()
        {
            // return the description of the room contents
            return Contents.Description;
        }

        public void Interact()
        {
            // return the result of interacting with the rooms contents
            Contents.Interact();
        }
    }
}
