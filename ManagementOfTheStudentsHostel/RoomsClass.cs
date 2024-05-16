using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfTheStudentsHostel
{
    public class RoomsClass
    {
        public int FloorRoom { get; set; }
        public int NumberRoom { get; set; }
        public int SquareRoom { get; set; }
        public int CountBadroom { get; set; }
        public int CountWardrobe { get; set; }
        public int TableRoom { get; set; }
        public int ChairsRoom { get; set; }
        public bool StoveRoom { get; set; }
        public string ElectricRoom { get; set; }
        public bool WiFiRoom { get; set; }

        public RoomsClass() { }

        public RoomsClass(int floorRoom,
            int numberRoom,
            int squareRoom,
            int countBadroom,
            int countWardrobe, 
            int tableRoom, 
            int chairsRoom,
            bool stoveRoom,
            string electricRoom,
            bool wiFiRoom)
        {
            FloorRoom = floorRoom;
            NumberRoom = numberRoom;
            SquareRoom = squareRoom;
            CountBadroom = countBadroom;
            CountWardrobe = countWardrobe;
            TableRoom = tableRoom;
            ChairsRoom = chairsRoom;
            StoveRoom = stoveRoom;
            ElectricRoom = electricRoom;
            WiFiRoom = wiFiRoom;
        }
    }
}
