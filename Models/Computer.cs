// Using namespace to reference the code in this file
// Project name is HelloWorld, folder is Models
namespace HelloWorld.Models
{
    public class Computer
    {

        // private string _motherboard; // field
        // public string Motherboard { get{ return _motherboard; }; set { _motherboard = value; }; } // property, used to get/set the field

        // accessible from outside
        public string? Motherboard { get; set; } // nullable strings
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

        public Computer()
        {
            if (VideoCard == null)
            {
                VideoCard = "";
            }
            if (Motherboard == null)
            {
                Motherboard = "";
            }
        }
    }
}