﻿using ProjetAppPizzeria.src.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetAppPizzeria.src
{
    internal class Order //Besoin de : client, commis, livreur, liste pizza, liste boisson, prix total
    {
        private DateTime orderDate;
        private int orderNumber;
        private Client client;
        private Helper helper;
        private DeliveryMan deliveryMan;
        private List<Pizza> pizzas = new List<Pizza>();
        private List<Drink> drinks = new List<Drink>();
        private float totalPrice;
        private bool isCooked;
        private bool isDelivered;
        private int orderTimer;
        private bool isCanceled;
        private bool isClosed;
        private bool isReady;
        private bool isPaid;

        public string Details {
            get
            {
                string s = "";
                foreach (Pizza p in pizzas)
                {
                    s += p.ToString()+"\n";
                }
                return s;
            }
        }
        public string DetailsDrink
        {
            get
            {
                string s = "";
                foreach (Drink d in drinks)
                {
                    s += d.ToString() + "\n";
                }
                return s;
            }
        }
        public string orderNumberString
        {
            get
            {
                return orderNumber.ToString();
            }
        }

        public string orderTimerString
        {
            get
            {
                string s = "";
                if (orderTimer < 60)
                {
                    s += orderTimer.ToString()+"s";
                }
                else
                {
                    s = (orderTimer / 60).ToString()+"m";
                    s += (orderTimer % 60).ToString() + "s";
                }
                return s;
            }
        }
        
        public string orderAddressString
        {
            get
            {
                {
                    return ""+client.getAddress();
                }
            }
        }
        public string orderCity
        {
            get
            {
                return client.getAddress().getCity();
            }
        }
        public string State
        {
            get
            {
                string s = "";
                if (this.isCanceled)
                {
                    s = "Canceled";
                }
                else if (this.isClosed)
                {
                    s = "Closed";
                }
                else if (this.isPaid)
                {
                    s = "Paid";
                }
                else if (this.isReady && !this.isDelivered)
                {
                    s = "In delivery";
                } else if (this.isDelivered)
                {
                    s = "Delivered";
                } else if (this.isCooked)
                {
                    s = "Cooked";
                } else if (!this.isCooked)
                {
                    s = "Cooking";
                } else
                {
                    s = "Error";
                }
                    return s;
            }
        }

        public bool isEnabledGreen
        {
            get
            {
                return !isCanceled && !isClosed && !isDelivered && isCooked && !isReady;
            }
        }

        public bool isEnabledBlue
        {
            get
            {
                return !isCanceled && !isClosed && isDelivered;
            }
        }
        public string priceString
        {
            get { return totalPrice + "€"; }
        }




        public Order(Client client, Helper helper, DeliveryMan deliveryMan, List<Pizza> pizzas, List<Drink> drinks, int orderNumber)
        {
            this.orderDate = DateTime.Now;
            this.orderNumber = orderNumber; // J'imagine qu'il faudra réfléchir à un moyen d'indenter.
            this.client = client;
            this.helper = helper;
            this.deliveryMan = deliveryMan;
            this.pizzas = pizzas;
            this.drinks = drinks;
            this.totalPrice = CalculTotalPrice();
            this.isCooked = false;
            this.isDelivered = false;
            this.isCanceled = false;
            this.isClosed = false;
            this.isReady = false;
            this.isPaid = false;

        }

        public Order(Client client, Helper helper, DeliveryMan deliveryMan)
        {
            this.orderDate = DateTime.Now;
            this.client = client;
            this.helper = helper;
            this.deliveryMan = deliveryMan;
            this.isCooked = false;
            this.isDelivered = false;
            this.isCanceled = false;
            this.isClosed = false;
            this.isReady = false;
            this.isPaid = false;


        }
        
        public void SetOrderDate(DateTime orderDate)
        {
            this.orderDate = orderDate;
        }
        public DateTime GetOrderDate()
        {
            return this.orderDate;
        }
        public void SetOrderNumber(int orderNumber)
        {
            this.orderNumber = orderNumber;
        }
        public int GetOrderNumber()
        {
            return this.orderNumber;
        }
        public void SetClient(Client client)
        {
            this.client = client;
        }
        public Client GetClient()
        {
            return this.client;
        }
        public void SetHelper(Helper helper)
        {
            this.helper = helper;
        }
        public Helper GetHelper()
        {
            return this.helper;
        }
        public void setDeliveryMan(DeliveryMan deliveryMan)
        {
            this.deliveryMan = deliveryMan;
        }
        public DeliveryMan GetDeliveryMan()
        {
            return this.deliveryMan;
        }
        public void SetPizzas(List<Pizza> pizzas)
        {
            this.pizzas = pizzas;
        }

        public void AddPizza(Pizza pizza)
        {
            this.pizzas.Add(pizza);
        }
        public void AddDrink(Drink drink)
        {
            this.drinks.Add(drink);
        }
        public List<Pizza> GetPizzas()
        {
            return this.pizzas;
        }
        public void SetDrinks(List<Drink> drinks)
        {
            this.drinks = drinks;
        }
        public List<Drink> GetDrinks()
        {
            return this.drinks;
        }
        public void SetTotalPrice(float totalPrice)
        {
            this.totalPrice = totalPrice;
        }
        public float GetTotalPrice()
        {
            return this.totalPrice;
        }
        public void SetIsCooked(bool isCooked)
        {
            this.isCooked = isCooked;
            if (isCooked)
            {
                this.orderTimer = 0;
                this.helper.addPreparingQueue(this);
            }
        }
        public bool GetIsCooked()
        {
            return this.isCooked;
        }
        public void SetIsDelivered(bool isDelivered)
        {
            this.isDelivered = isDelivered;
        }
        public bool GetIsDelivered()
        {
            return this.isDelivered;
        }
        public void SetIsCanceled(bool isCanceled)
        {
            this.isCanceled = isCanceled;
        }
        public bool GetIsCanceled()
        {
            return this.isCanceled;
        }
        public void SetIsClosed(bool isClosed)
        {
            this.isClosed = isClosed;
        }
        public bool GetIsClosed()
        {
            return this.isClosed;
        }
        public void SetIsReady(bool isReady)
        {
            this.isReady = isReady;
            if (isReady)
            {
                this.orderTimer = 0;
                this.deliveryMan.addDeliveryQueue(this);
            }
        }
        public bool GetIsReady()
        {
            return this.isReady;
        }
        public void SetIsPaid(bool isPaid)
        {
            this.isPaid = isPaid;
        }
        public bool GetIsPaid()
        {
            return this.isPaid;
        }
        public void SetOrderTimer(int t)
        {
            this.orderTimer = t;
        }
        public int GetOrderTimer()
        {
            return orderTimer;
        }
        public void DeletePizza(int index)
        {
            pizzas.RemoveAt(index);
        }
        public IEnumerable GetOrderElements()
        {
            return this.pizzas.FindAll(p => p != null);
        }
            public float CalculTotalPrice() 
        {
            float result = 0;
            foreach (Pizza pizza in pizzas)
            {
                result += pizza.GetPrice();
            }
            foreach (Drink drink in drinks)
            {
                result += drink.GetPrice();
            }
            return result;
        }
        public override string ToString() // à revoir
        {
            return "Order date: " + this.orderDate + " Order number: " + this.orderNumber;
        }

    }
}
