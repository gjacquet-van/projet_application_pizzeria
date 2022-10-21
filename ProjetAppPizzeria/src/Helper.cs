using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Helper : Person
    {
        private int id;
        private int salary;
        private int numberOfOrders;
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

        public string numberOfOrdersString
        {
            get
            {
                return numberOfOrders.ToString();
            }
        }
        public Helper(string firstName, string lastName, string phoneNumber, string streetNumber, string streetName, string city, string postalCode, string country, int salary) : base(firstName, lastName, phoneNumber, streetNumber, streetName, city, postalCode, country)
        {
            this.salary = salary;
        }

        public int getSalary()
        {
            return this.salary;
        }
        
        public override string ToString()
        {
            return base.ToString();
        }

        public void addNumberOfOrders()
        {
            this.numberOfOrders++;
        }

        public void addPreparingQueue(Order order)
        {
            Task.Run(() => this.PrepareOrder(order));
        }

        public async void PrepareOrder(Order order)
        {
            while (order.GetIsReady() == false && order.GetIsCanceled() == false)
            {
                await Task.Delay(1000);
                Console.WriteLine("Preparing order : " + order.ToString());
                order.SetOrderTimer(order.GetOrderTimer() + 1);
            }
            Console.WriteLine("order " + order.orderNumberString + " ready!");

        }
    }
}
