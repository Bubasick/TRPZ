using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataManagement.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public TimeSpan TimeBeforeAvailability { get; set; }
    }
}
