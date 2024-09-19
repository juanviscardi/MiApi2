using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public abstract class BaseDevice
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public string OwningCompant { get; set; }
        public bool? isInline { get; set; }
    }
}
