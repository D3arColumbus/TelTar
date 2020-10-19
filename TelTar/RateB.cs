namespace TelTar
{
    public class RateB : Rate
    {
        private double _baseRate;
        private double _ratePerMinute;

        public double BaseRate
        {
            get => _baseRate;
            set
            {
                if (value >= 0)
                    _baseRate = value;
            }
        }
        
        public double RatePerMinute
        {
            get => _ratePerMinute;
            set
            {
                if (value >= 0)
                    _ratePerMinute = value;
            }
        }
        

        public RateB(string phoneNumber, string description, double baseRate, double ratePerMinute) : base(phoneNumber, description)
        {
            BaseRate = baseRate;
            RatePerMinute = ratePerMinute;
        }

        public override int GetBonusPoints(int x)
        {
            if (x <= 1000)
                return x;
            if (x <= 2000)
                return 1000 + (x - 1000) * 2;
            return 3000 + (x - 2000) * 3;
        }

        public override double GetKosten(int x) => BaseRate + RatePerMinute * x;

        public override string GetInfo()
        {
            return base.GetInfo() + BaseRate + "/Monat und " + RatePerMinute + "/Minute";
        }
    }
}