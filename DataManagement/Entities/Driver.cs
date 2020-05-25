using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public DateTime DateOfAvailability { get; set; }
        public int SpeedOfCarInKm { get; set; }
    }
}
