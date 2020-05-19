using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public TimeSpan TimeBeforeAvailability { get; set; }
    }
}
