using ProjetAppPizzeria.src.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Pizza
    {
        private PizzaType type;
        private PizzaSize size;
        private float price;
        public string typeString
        {
            get
            {
                return type.ToString();
            }
        }
        public string sizeString
        {
            get
            {
                return size.ToString();
            }
        }
        public string priceString
        {
            get
            {
                return price.ToString()+"€";
            }
        }
        public Pizza(PizzaType type, PizzaSize size)
        {
            this.type = type;
            this.size = size;
            this.price = SetPrice();
        }
        public Pizza(PizzaType type, PizzaSize size, float price)
        {
            this.type = type;
            this.size = size;
            this.price = price;
        }
        

        public PizzaType getType()
        {
            return this.type;
        }
        public PizzaSize getSize()
        {
            return this.size;
        }

        public override string ToString()
        {
            return " Type: " + this.type + " // Size: " + this.size + " // Price: " + this.price +"€";
        }

        internal float GetPrice()
        {
            return price;
        }
        internal float SetPrice()
        {
            float p = 0;
            switch (this.type)
            {
                case PizzaType.MARGHERITA:
                    p = 5;
                    break;
                case PizzaType.FOUR_CHEESES:
                    p = 7;
                    break;
                case PizzaType.HAWAIIAN:
                    p = 6;
                    break;
                case PizzaType.PEPPERONI:
                    p = 6;
                    break;
                case PizzaType.MEXICAN:
                    p = 6;
                    break;
                case PizzaType.VEGETARIAN:
                    p = 6;
                    break;
            }
            switch (this.size)
            {
                case PizzaSize.SMALL:
                    p *= 1;
                    break;
                case PizzaSize.MEDIUM:
                    p *= 1.5f;
                    break;
                case PizzaSize.LARGE:
                    p *= 2;
                    break;
            }
            return p;
        }
    }
}
