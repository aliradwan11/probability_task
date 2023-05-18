using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prop1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.Write("Enter the number of items: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the items values:");
            double[] values = new double[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = double.Parse(Console.ReadLine());
            }
           
            Array.Sort(values);
          
            double median;
            if (n % 2 == 0)
            {
                median = (values[n / 2 - 1] + values[n / 2]) / 2;
            }
            else
            {
                median = values[n / 2];
            }
            Console.WriteLine("Median: " + median);
            double mode = values.GroupBy(x => x)
            .OrderByDescending(g => g.Count())
           .Select(g => g.Key)
           .First();
            Console.WriteLine("Mode: " + mode);
            double range = values.Last() - values.First();
            Console.WriteLine("Range: " + range);
            int q1Index = n / 4;
            double q1 = n % 4 == 0 ? (values[q1Index - 1] + values[q1Index]) / 2 : values[q1Index];
            Console.WriteLine("First Quartile: " + q1);
            int q3Index = n * 3 / 4;
            double q3 = n % 4 == 0 ? (values[q3Index - 1] + values[q3Index]) / 2 : values[q3Index];
            Console.WriteLine("Third Quartile: " + q3);
            int p90Index = n * 9 / 10;
            double p90 = values[p90Index];
            Console.WriteLine("P90: " + p90);
            double iqr = q3 - q1;
            Console.WriteLine("Interquartile Range: " + iqr);
            double lowerOutlierBound = q1 - 1.5 * iqr;
            double upperOutlierBound = q3 + 1.5 * iqr;
            Console.WriteLine("Outlier Boundaries: [" + lowerOutlierBound + ", " + upperOutlierBound + "]");
            Console.Write("Enter a value to check if it's an outlier: ");
            double inputValue = double.Parse(Console.ReadLine());
            if (inputValue < lowerOutlierBound || inputValue > upperOutlierBound)
            {
                Console.WriteLine(inputValue + " is an outlier.");
            }
            else
            {
                Console.WriteLine(inputValue + " is not an outlier.");
            }
        }
    }
}
    

