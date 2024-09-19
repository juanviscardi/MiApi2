namespace Models.In
{
    public class CreateDeviceRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
        public string OwningCompany { get; set; } = string.Empty;
        public bool? isInline { get; set; } = false;
        public bool? movementDetection { get; set; } = false;
        public bool? personDetection { get; set; } = false;

        public CreateDeviceRequest() { }

        public CreateDeviceRequest(string name, string type, string model, string description, string photoPath, string owningCompany, bool? isInline, bool? movementDetection, bool? personDetection)
        {
            Name = name;
            Type = type;
            Model = model;
            Description = description;
            PhotoPath = photoPath;
            OwningCompany = owningCompany;
            this.isInline = isInline;
            this.movementDetection = movementDetection;
            this.personDetection = personDetection;
        }

        public override bool Equals(object? obj)
        {
            return obj is CreateDeviceRequest request &&
                   Name == request.Name;
        }
    }
}
