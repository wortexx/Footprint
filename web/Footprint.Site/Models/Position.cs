namespace Footprint.Site.Models
{
    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public long UtcTicks { get; set; }
    }
}