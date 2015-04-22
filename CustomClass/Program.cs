using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClass
{
     class Program
    {
 

        public static void Main(string[] args)
        {
            Product x = new Product()
            {
                Name = "Eggs",
                Price = new decimal(233, 0, 0, false, 2)
            };
            Product x2 = new Product()
            {
                Name = "Eggs",
                Price = new decimal(233, 0, 0, false, 2)
            };
            Console.WriteLine(x.Name);
            Console.WriteLine(x.Price.ToString());
            decimal num = x.CalculateTax();
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            Console.WriteLine("Overloads");
            num = x.CalculateTax(new decimal(9, 0, 0, false, 2));
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            num = x.CalculateTax(new decimal(8, 0, 0, false, 2));
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            num = x.CalculateTax(new decimal(8, 0, 0, false, 2));
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            num = x.CalculateTax(new decimal(6), new decimal(8, 0, 0, false, 1));
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            num = new decimal(10);
            num = x.CalculateTax(new decimal(6), num);
            Console.WriteLine(string.Concat("Tax :", num.ToString()));
            Console.ReadLine();
        }
    }

     class Product
    {
        /// <summary>
        /// Represents name of product
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Represents price as decimal type
        /// </summary>
        public decimal Price
        {
            get;
            set;
        }

        public decimal TaxRate
        {
            get;
            set;
        }

        public Product()
        {
            this.TaxRate = new decimal(8, 0, 0, false, 2);
        }

        /// <summary>
        /// Caluclate tax based upon price and taxrate
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTax()
        {
            return this.Price * this.TaxRate;
        }

        public decimal CalculateTax(decimal taxRate)
        {
            return this.Price * taxRate;
        }

        public decimal CalculateTax(decimal price, decimal taxR = 0.08m)
        {
            return price * taxR;
        }

        public string concatstring(params string[] s)
        {
            return string.Join(" *** ", s);
        }
    }
}
