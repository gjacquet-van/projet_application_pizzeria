using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class DeliveryMan : Person
    {
        private int salary;
        private int numberOfDelivery;
        public string numberOfDeliveryString
        {
            get { return this.numberOfDelivery.ToString(); }
        }
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
        public DeliveryMan(string firstName, string lastName, string phoneNumber, string streetNumber, string streetName, string city, string postalCode, string country, int salary) : base(firstName, lastName, phoneNumber, streetNumber, streetName, city, postalCode, country)
        {
            this.salary = salary;
        }
        public int getSalary()
        {
            return this.salary;
        }
        public void addDeliveryQueue(Order order)
        {
            Task.Run(() => this.DeliverPizza(order));
        }
        public void addDelivery()
        {
            numberOfDelivery++;
        }

        public async void DeliverPizza(Order order)
        {
            while (order.GetIsDelivered() == false && order.GetIsCanceled() == false)
            {
                await Task.Delay(1000);
                Console.WriteLine("Delivering order : " + order.ToString());
                order.SetOrderTimer(order.GetOrderTimer() + 1);
            }
            Console.WriteLine("order " + order.ToString() + " Delivered!");

        }

    }
}
