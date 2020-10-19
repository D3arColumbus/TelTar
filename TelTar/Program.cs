namespace TelTar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RateArray rateArray = new RateArray();
            rateArray[0] = new RateA("0555555554","bla", 10);
            rateArray[1] = new RateB("8888888888","blaB", 15,1);
            rateArray.ReadFromFile(@"C:\git\TelTar\Rates.txt");
            rateArray.WriteToFile(@"C:\git\TelTar\RatesOutput.txt");
            rateArray.PrintAufstellung();
            rateArray.PrintAufstellung(2000);
        }
    }
}