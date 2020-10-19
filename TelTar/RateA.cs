namespace TelTar
{
    public class RateA : Rate
    {
        private int _baseRate;

        public int BaseRate
        {
            get => _baseRate;
            set
            {
                if (value >= 0)
                    _baseRate = value;
            }
        }

        
        
        public RateA(string phoneNumber, string description, int baseRate) : base(phoneNumber, description)
        {
            BaseRate = baseRate;
        }

        public override double GetKosten(int x) => BaseRate;


        public override string GetInfo()
        {
            return base.GetInfo() + BaseRate + "/Monat";
        }
    }
}