using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Device
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public string OwningCompany { get; set; } = string.Empty;
        public bool? isInline { get; set; } = false;
        public bool? movementDetection { get; set; } = false; 
        public bool? personDetection { get; set; } = false;
    }
    
}
