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
        private List<Order> ordersQueue = new List<Order>();
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
            Task t = new Task(() => this.makePizza(order));
            t.Start();
            

        }
        public void removeOrderQueue()
        {
            this.ordersQueue.RemoveAt(0);
        }

        public async void makePizza(Order order)
        {
            while (order.GetIsCooked() == false)
            {
                await Task.Delay(1000);
                Console.WriteLine("Cooking order : " + order.GetOrderDate());
            }
            Console.WriteLine("order" + order.GetOrderDate() + "cooked!");

        }

        public override string ToString()
        {
            return base.ToString() + " Salary: " + this.salary;
        }
    }
}
