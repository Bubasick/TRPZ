using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataManagement.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public DateTime DateOfAvailability { get; set; }
        public int TypingSpeed { get; set; }
    }
}
