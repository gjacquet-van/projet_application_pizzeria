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
        private float totalSpending = 0;

        public string LastnameString
        {
            get
            {
                return this.getLastName();
            }
        }
        public string FirstnameString
        {
            get
            {
                return this.getFirstName();
            }
        }
        public string CityString
        {
            get
            {
                return this.getAddress().getCity();
            }
        }
        public string numberOfOrdersString
        {
            get
            {
                return numberOfOrders.ToString();
            }
        }
        public string totalSpendingString
        {
            get
            {
                return totalSpending.ToString()+"€";
            }
        }

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
        public void addSpending(float n)
        {
            this.totalSpending+=n;
        }
        public void addOrder()
        {
            this.numberOfOrders++;
        }
        public override string ToString()
        {
            return base.ToString() + " First order date: " + this.firstOrderDate + " Number of orders: " + this.numberOfOrders;
        }
    }
}
