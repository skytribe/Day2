using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProperties
{
     class Program
    {


        public static void Main(string[] args)
        {
            Console.ReadLine();
            Customer sally = new Customer()
            {
                FirstName = "Sally",
                LastName = "Williams",
                Age = 23,
                Birthdate = new DateTime(2028, 1, 18)
            };
            Debug.Assert(sally.Age == 23, "Sally is 23.");
            Customer mike = new Customer()
            {
                FirstName = "Mike",
                LastName = "Harrison",
                Age = 10,
                Birthdate = new DateTime(2019, 1, 18)
            };
            mike.Age = -5;
            Debug.Assert(mike.Age == 10, "Mike is 10.");
            Debug.Assert(mike.Age < 0, "Mike cannot be younger than is 0.");
            Customer customer = new Customer()
            {
                FirstName = "Bill",
                LastName = "Smith",
                Age = 10,
                Birthdate = new DateTime(2020, 2, 10)
            };
            Console.WriteLine("Complete");
        }
    }

     class Customer
    {
        private int _age;

        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                Debug.Assert(value > 0, "Age cannot be negative");
                if (value < 0)
                {
                    value = 0;
                }
                this._age = value;
            }
        }

        public DateTime Birthdate
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Customer()
        {
        }
    }
}
