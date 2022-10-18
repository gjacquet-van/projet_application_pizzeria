using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Pizzeria
    {
        private List<Client> clients = new List<Client>();
        private List<Cook> cooks = new List<Cook>();
        private List<Helper> helpers = new List<Helper>();
        private List<Order> orders = new List<Order>();
        private List<DeliveryMan> deliveryMen = new List<DeliveryMan>();


        public Pizzeria()
        {
            Client client1 = new Client("Guillaume", "Jacquet", "0601020304", "1", "rue de la paix", "Paris", "75000", "France", new DateTime(2019, 1, 1));
            Client client2 = new Client("Victorin", "Huet", "0605060708", "12", "rue des tournesols", "Paris", "75000", "France", new DateTime(2020, 10, 12));
            Client client3 = new Client("Brahim", "Hda", "0609101112", "21", "Boulevard Maxime Gorki", "Paris", "75000", "France", new DateTime(2021, 8, 25));

            this.clients.Add(client1);
            this.clients.Add(client2);
            this.clients.Add(client3);

            Cook cook1 = new Cook("Jean", "Dupont", "0613141516", "34", "rue de la boite", "Paris", "75000", "France", 1000);

            this.cooks.Add(cook1);

            Helper helper1 = new Helper("Jacques", "L'aideur", "0617181920", "24", "rue de l'aide", "Paris", "75000", "France", 1000);
            Helper helper2 = new Helper("Jeanne", "L'aideuse", "0621222324", "25", "rue de l'aide", "Paris", "75000", "France", 1000);

            this.helpers.Add(helper1);
            this.helpers.Add(helper2);

            DeliveryMan deliveryMan1 = new DeliveryMan("Jean", "Le livreur", "0625262728", "26", "rue du livreur", "Paris", "75000", "France", 1000);
            DeliveryMan deliveryMan2 = new DeliveryMan("Jeanne", "La livreuse", "0629303132", "27", "rue du livreur", "Paris", "75000", "France", 1000);
            
            this.deliveryMen.Add(deliveryMan1);
            this.deliveryMen.Add(deliveryMan2);
            /*
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();
            
            this.orders.Add(order1);
            this.orders.Add(order2);
            this.orders.Add(order3);
            */
        }

        public List<Client> getClients()
        {
            return this.clients;
        }
        public List<Cook> getCooks()
        {
            return this.cooks;
        }
        public List<Helper> getHelpers()
        {
            return this.helpers;
        }
        public List<DeliveryMan> getDeliveryMen()
        {
            return this.deliveryMen;
        }
        public List<Order> getOrders()
        {
            return this.orders;
        }

        public void addClient(Client client)
        {
            this.clients.Add(client);
        }
        public void addCook(Cook cook)
        {
            this.cooks.Add(cook);
        }
        public void addHelper(Helper helper)
        {
            this.helpers.Add(helper);
        }
        public void addDeliveryMan(DeliveryMan deliveryMan)
        {
            this.deliveryMen.Add(deliveryMan);
        }
        public void addOrder(Order order)
        {
            this.orders.Add(order);
            cooks[0].addOrderQueue(order);
        }
        public void removeClient(Client client)
        {
            this.clients.Remove(client);
        }
        public void removeCook(Cook cook)
        {
            this.cooks.Remove(cook);
        }
        public void removeHelper(Helper helper)
        {
            this.helpers.Remove(helper);
        }
        public void removeDeliveryMan(DeliveryMan deliveryMan)
        {
            this.deliveryMen.Remove(deliveryMan);
        }
        public void removeOrder(Order order)
        {
            this.orders.Remove(order);
        }
        internal IEnumerable GetOrdersToCook()
        {
            //Console.WriteLine("updated");
            return this.orders.FindAll(order => order.GetIsCooked() == false);
        }
        internal IEnumerable GetOrdersToDeliver()
        {
            return this.orders.FindAll(order => (order.GetIsCooked() == true) && (order.GetIsDelivered() == false));
        }

        public override string ToString()
        {
            string result = "Clients: \n";
            foreach (Client client in this.clients)
            {
                result += client.ToString() + "\n";
            }
            result += "Cooks: \n";
            foreach (Cook cook in this.cooks)
            {
                result += cook.ToString() + "\n";
            }
            result += "Helpers: \n";
            foreach (Helper helper in this.helpers)
            {
                result += helper.ToString() + "\n";
            }
            result += "DeliveryMen: \n";
            foreach (DeliveryMan deliveryMan in this.deliveryMen)
            {
                result += deliveryMan.ToString() + "\n";
            }
            result += "Orders: \n";
            foreach (Order order in this.orders)
            {
                result += order.ToString() + "\n";
            }
            return result;
        }

        
    }
}
