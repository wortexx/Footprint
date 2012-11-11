namespace Footprint.Site.Models
{
    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public long UtcTicks { get; set; }
    }

    public class QuizViewModel
    {
        public string Country { get; set; }
        public Sex Sex { get; set; }
        public decimal CityPopulation { get; set; }
        public string Occupation { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}