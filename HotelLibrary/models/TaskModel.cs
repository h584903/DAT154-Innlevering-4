using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string TaskType { get; set; } // "Cleaning", "Maintenance", "RoomService"
        public string Description { get; set; }
        public string Status { get; set; } // "New", "In Progress", "Finished"
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public Room Room { get; set; } // Navigasjon
    }
}
