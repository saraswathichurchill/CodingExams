using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    public class TaxBracket
    {
        public int RateId { get; set; }
        public decimal MinRange { get; set; }
        public decimal MaxRange { get; set; }
        public decimal Rate { get; set; }
        public decimal RateAmount { get; set; }
    }
    class Program
    {
        static List<TaxBracket> taxSlab = new List<TaxBracket>();
      
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Salary Amount: ");
           
            decimal salary = Convert.ToDecimal(Console.ReadLine().Trim());
           
            var taxToBePaid = 0m;
            taxSlab.AddRange(new TaxBracket[]
               {
                    new TaxBracket{RateId=1,MinRange=0,MaxRange=3000, Rate=0m},
                    new TaxBracket{RateId=2,MinRange=3000, MaxRange=5000,Rate=0.1m },
                    new TaxBracket{RateId=3,MinRange=5000,MaxRange=7000,Rate=0.2m},
                    new TaxBracket{RateId=4,MinRange=7000,MaxRange=9000,Rate=0.3m},
                    new TaxBracket{RateId=5,MinRange=9000,MaxRange=decimal.MaxValue,Rate=0.4m}
               }
               );
            foreach (var slab in taxSlab)
            {
                            
                if(salary>slab.MinRange)
                {
                    var taxableRate = Math.Min(slab.MaxRange - slab.MinRange, salary - slab.MinRange);
                    var taxThisSlab = taxableRate * slab.Rate;
                    taxToBePaid = taxToBePaid + taxThisSlab;
                }
            }
            Console.WriteLine("Your Salary is : {0}, and You need to Pay the Tax Amount as: {1}",salary,taxToBePaid);
            Console.ReadKey();
        }
    }
}
