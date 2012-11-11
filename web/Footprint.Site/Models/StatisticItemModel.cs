namespace Footprint.Site.Models
{
    public class StatisticItemModel
    {
        public string Consumer { get; set; }
        public decimal Usage { set; get; }
        public ConsumerType ConsumerType { get; set; }
        public string UsageInCosumerMeasurements
        {
            get
            {
                var ret = string.Empty;
                switch (this.ConsumerType)
                {
                    case ConsumerType.Plastic:
                        {
                            ret = string.Format("{0} kg.", this.Usage);
                            break;
                        }
                    case ConsumerType.Vehicle:
                        {
                            ret = string.Format("{0} km.", this.Usage);
                            break;
                        }
                    case  ConsumerType.Printer:
                        {
                            ret = string.Format("{0} pcs", this.Usage);
                            break;
                        }
                    case ConsumerType.Water:
                        {
                            ret = string.Format("{0} lt.", this.Usage);
                            break;
                        }
                    case ConsumerType.Electricity:
                        {
                            ret = string.Format("{0} kW.", this.Usage);
                            break;
                        }
                    case ConsumerType.Heating:
                        {
                            ret = string.Format("{0} kcal.", this.Usage);
                            break;
                        }
                    case ConsumerType.Cooling:
                        {
                            ret = string.Format("{0} kW.", this.Usage);
                            break;
                        }
                        
                }
                return ret;
            }
        }
        public decimal Norm { set; get; }
        public bool IsEffective { get { return Usage <= Norm; }}
        public decimal C02
        {
            get
            {
                //var ret = decimal.Zero;
                //switch (this.ConsumerType)
                //{
                //    case ConsumerType.Plastic:
                //        {
                //            ret = this.Usage * 1.5M;
                //            break;
                //        }
                //    case ConsumerType.Vehicle:
                //        {
                //            ret = string.Format("{0} km.", this.Usage);
                //            break;
                //        }
                //    case ConsumerType.Printer:
                //        {
                //            ret = string.Format("{0} pcs", this.Usage);
                //            break;
                //        }
                //    case ConsumerType.Water:
                //        {
                //            ret = string.Format("{0} lt.", this.Usage);
                //            break;
                //        }
                //    case ConsumerType.Electricity:
                //        {
                //            ret = string.Format("{0} kW.", this.Usage);
                //            break;
                //        }
                //    case ConsumerType.Heating:
                //        {
                //            ret = string.Format("{0} kcal.", this.Usage);
                //            break;
                //        }
                //    case ConsumerType.Cooling:
                //        {
                //            ret = string.Format("{0} kW.", this.Usage);
                //            break;
                //        }

                //}
                return this.Usage;
            }
        }
    }

    public enum ConsumerType
    {
        None = 0,
        Vehicle = 1,
        Printer = 2,
        Water = 3,
        Electricity = 4,
        Heating = 5,
        Cooling = 6,
        Plastic = 7
    }
}