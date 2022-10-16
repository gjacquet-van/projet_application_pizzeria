using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria
{
    internal class Address
    {
        private string streetNumber;
        private string streetName;
        private string city;
        private string postalCode;
        private string country;
        
        public Address(string streetNumber, string streetName, string city, string postalCode, string country)
        {
            this.streetNumber = streetNumber;
            this.streetName = streetName;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
        }

        public string getStreetNumber()
        {
            return this.streetNumber;
        }
        public string getStreetName()
        {
            return this.streetName;
        }
        public string getCity()
        {
            return this.city;
        }
        public string getPostalCode()
        {
            return this.postalCode;
        }
        public string getCountry()
        {
            return this.country;
        }
        //tostring
        public override string ToString()
        {
            return " Street number: " + this.streetNumber + " Street name: " + this.streetName + " City: " + this.city + " Postal code: " + this.postalCode + " Country: " + this.country;
        }




    }
}
