﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppPizzeria
{
    internal abstract class Person
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private Address address;
        public string NameString
        {
            get
            {
                return firstName+" "+lastName;
            }
        }
        public Person(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
        public Person(string firstName, string lastName, string phoneNumber, string streetNumber, string streetName, string city, string postalCode, string country)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.address = new Address(streetNumber, streetName, city, postalCode, country);
        }
        
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getPhoneNumber()
        {
            return this.phoneNumber;
        }
        public Address getAddress()
        {
            return this.address;
        }
        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
