using System;

namespace TelTar
{
    public abstract class Rate
    {
        private string _phoneNumber;
        public string Description { get; set; }
        

        public string PhoneNumber
        {
            get => _phoneNumber;

            set
            {
                if (value.Length != 10) return;
                int sum = 0;
                char[] parts = value.ToCharArray();
                for (int i = 0; i < value.Length - 1; i++)
                    sum += int.Parse(parts[i].ToString());
                if (sum % 4 == 0)
                    _phoneNumber = value;
            }
        }
        
        public Rate(string phoneNumber, string description)
        {
            PhoneNumber = phoneNumber;
            Description = description;
        }

        public virtual int GetBonusPoints(int x) => x * 2;

        public abstract double GetKosten(int x);

        public virtual string GetInfo() => Description + ", " + "Gebühren: ";
    }
}