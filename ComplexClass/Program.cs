using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexClass
{
     class Account
    {
        public decimal Amount
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public bool IsOpen
        {
            get;
            set;
        }

        public AccountType Type
        {
            get;
            set;
        }

        public Account()
        {
        }
    }
     enum AccountType
    {
        Checking,
        Saving
    }
     class Address
    {
        public string City
        {
            get;
            set;
        }

        public string Street
        {
            get;
            set;
        }

        public string ZIP
        {
            get;
            set;
        }

        public Address()
        {
        }
    }

     class Customer
    {
        public Account Account1
        {
            get;
            set;
        }

        public Account Account2
        {
            get;
            set;
        }

        public Address BillingAddress
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

        public Address ShippingAddress
        {
            get;
            set;
        }

        public Customer()
        {
            this.BillingAddress = new Address();
            this.ShippingAddress = new Address();
        }

        public Customer(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.BillingAddress = new Address();
            this.ShippingAddress = new Address();
        }

        public Customer(string fname, string lname, Account acct1, Account acct2)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.BillingAddress = new Address();
            this.ShippingAddress = new Address();
            this.Account1 = acct1;
            this.Account2 = acct2;
        }

        public bool Transfer(Direction direction, decimal amount)
        {
            bool retvalue = false;
            Debug.Assert(this.Account1 != null, "1st account no specified");
            Debug.Assert(this.Account2 != null, "2nd account no specified");
            if ((this.Account1 == null ? false : this.Account2 != null))
            {
                if (direction == Direction.FromAccount2)
                {
                    retvalue = true;
                    Account account1 = this.Account1;
                    account1.Amount = account1.Amount + amount;
                    Account account2 = this.Account2;
                    account2.Amount = account2.Amount - amount;
                }
                else if (direction == Direction.FromAccount1)
                {
                    retvalue = true;
                    Account account = this.Account1;
                    account.Amount = account.Amount - amount;
                    Account account21 = this.Account2;
                    account21.Amount = account21.Amount + amount;
                }
            }
            return retvalue;
        }
    }

     enum Direction
    {
        FromAccount1,
        FromAccount2
    }
     class Program
    {
        public Program()
        {
        }

        private static void Main(string[] args)
        {
            Customer alicwithcons = new Customer("alice", "hhh", new Account(), null);
            Customer customer = new Customer()
            {
                FirstName = "Alice"
            };
            Account account = new Account()
            {
                Amount = new decimal(100),
                Id = "checking account no.",
                Type = AccountType.Checking,
                IsOpen = true
            };
            customer.Account1 = account;
            bool result = customer.Transfer(Direction.FromAccount1, new decimal(100));
            Customer customer1 = new Customer()
            {
                FirstName = "Alice"
            };
            Account account1 = new Account()
            {
                Amount = new decimal(100),
                Id = "checking account no.",
                Type = AccountType.Checking,
                IsOpen = true
            };
            customer1.Account1 = account1;
            Account account2 = new Account()
            {
                Amount = new decimal(0),
                Id = "saving account no.",
                Type = AccountType.Saving,
                IsOpen = false
            };
            customer1.Account2 = account2;
            Customer alice2 = customer1;
            result = alice2.Transfer(Direction.FromAccount1, new decimal(5));
            result = alice2.Transfer(Direction.FromAccount2, new decimal(15));
        }
    }
}
