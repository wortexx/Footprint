namespace Footprint.Domain.Model
{
    public class CountryProfile
    {
        public string Name { get; set; }
        public double TotalFootprint { get; set; }
        public double ElectricityPercent { get; set; }
        public double WaterPercent { get; set; }
        public double HeatingPercent { get; set; }
        public double CoolingPercent { get; set; }
    }
}