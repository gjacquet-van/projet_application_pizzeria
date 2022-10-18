using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Client : Person
    {
        private DateTime firstOrderDate;
        private int numberOfOrders;


        public Client(string firstName, string lastName, string phoneNumber, string streetNumber, string streetName, string city, string postalCode, string country, DateTime firstOrderDate) : base(firstName, lastName, phoneNumber, streetNumber, streetName, city, postalCode, country)
        {
            this.firstOrderDate = firstOrderDate;
            this.numberOfOrders = 0;
        }
        public DateTime getFirstOrderDate()
        {
            return this.firstOrderDate;
        }
        public int getNumberOfOrders()
        {
            return this.numberOfOrders;
        }
        public override string ToString()
        {
            return base.ToString() + " First order date: " + this.firstOrderDate + " Number of orders: " + this.numberOfOrders;
        }
    }
}
