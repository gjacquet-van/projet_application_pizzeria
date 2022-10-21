using ProjetAppPizzeria.src.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria.src
{
    internal class Drink
    {
        private DrinkType type;
        private float price;

        public Drink(DrinkType type)
        {
            this.type = type;
            if (type == DrinkType.NULL)
            {
                this.price = 0;
            }
            else
            { 
                this.price = 1;
            }
            
        }
        public Drink(DrinkType type, float price)
        {
            this.type = type;
            this.price = price;
        }

        internal float GetPrice()
        {
            return price;
        }
        //ToString
        public override string ToString()
        {
            return type.ToString();
        }
    }
}
