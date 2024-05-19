using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Beds { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
        public bool NeedsCleaning { get; set; }
        public bool NeedsMaintenance { get; set; }
        public bool NeedsRoomService { get; set; }


    }
}
