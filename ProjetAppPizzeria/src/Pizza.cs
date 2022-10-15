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

        public Pizza(PizzaType type, PizzaSize size, float price)
        {
            this.type = type;
            this.size = size;
            this.price = price;
        }
    }
}
