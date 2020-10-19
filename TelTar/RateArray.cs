using System;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;

namespace TelTar
{
    public class RateArray
    {
        private Rate[] array;

        public Rate this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public RateArray()
        {
            array = new Rate[10];
        }
        public RateArray(int length)
        {
            array = new Rate[length];
        }

        public void PrintAufstellung()
        {
            foreach (var variable in array)
            {
                if(variable != null)
                    Console.WriteLine(variable.GetInfo());
            }
        }
        
        public void PrintAufstellung(int x)
        {
            foreach (var variable in array)
            {
                if(variable != null)
                    Console.WriteLine("Kosten: " + variable.GetKosten(x) + ", Bonuspunkte: " + variable.GetBonusPoints(x));
            }
        }

        public void Reset()
        {
            array = new Rate[array.Length];
        }

        private void createRate(string[] parts)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    if(parts.Length == 3)
                        array[i] = new RateA(parts[1],parts[0],int.Parse(parts[2]));
                    if(parts.Length == 4)
                        array[i] = new RateB(parts[1],parts[0],int.Parse(parts[2]),int.Parse(parts[3]));
                    return;
                }
                        
            }
        }
        
        public void ReadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            string[] parts;
            while (line != null)
            {
                parts = line.Split(';');
                createRate(parts);
                line = reader.ReadLine();
            }
            reader.Close();
        }

        public void WriteToFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (var i in array)
            {
                if (i != null)
                    writer.WriteLine(i.GetInfo());
            }
            writer.Close();
        }
    }
}