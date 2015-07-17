using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClassExample
{
    class Employee
    {
        private string name;
        private string alias;
        private decimal salary = 3000.00m;

        public Employee() 
        {
        }

        public Employee(string name, string alias)
            : this(name, alias, 3000.00m)
        {
        }

        public Employee(string name, string alias, decimal slry) 
        {
            this.name = name;
            this.alias = alias;
            salary = slry;
        }

        public void printEmployee() 
        {
            Console.WriteLine("Name: {0}\nAlias: {1}", name, alias);
            Console.WriteLine("Taxes: {0:C}", Tax.CalcTax(this));
        }

        public decimal Salary
        {
            get { return salary; }
        }
    }

    class Tax 
    {
        public static decimal CalcTax(Employee E) 
        {
            return 0.08m * E.Salary;
        }
    }
}
