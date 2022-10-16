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
        private ArrayList clients = new ArrayList();
        private ArrayList cooks = new ArrayList();
        private ArrayList helpers = new ArrayList();
        private ArrayList deliveryMen = new ArrayList();
        private ArrayList orders = new ArrayList();

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

            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            this.orders.Add(order1);
            this.orders.Add(order2);
            this.orders.Add(order3);
            
        }

        public ArrayList getClients()
        {
            return this.clients;
        }
        public ArrayList getCooks()
        {
            return this.cooks;
        }
        public ArrayList getHelpers()
        {
            return this.helpers;
        }
        public ArrayList getDeliveryMen()
        {
            return this.deliveryMen;
        }
        public ArrayList getOrders()
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
        

    }
}
