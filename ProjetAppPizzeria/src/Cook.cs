using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Cook : Person
    {
        private int salary;
        private ArrayList ordersQueue;
        public Cook(string firstName, string lastName, string phoneNumber, string streetNumber, string streetName, string city, string postalCode, string country, int salary) : base(firstName, lastName, phoneNumber, streetNumber, streetName, city, postalCode, country)
        {
            this.salary = salary;
        }
        public int getSalary()
        {
            return this.salary;
        }

        public void addOrderQueue(Order order)
        {
            this.ordersQueue.Add(order);
        }

        public override string ToString()
        {
            return base.ToString() + " Salary: " + this.salary;
        }
    }
}
