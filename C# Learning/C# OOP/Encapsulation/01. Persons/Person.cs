using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        //Constructor
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        //Filds

        private string _firstName;
        private string _lastName;
        private int _age;

        //Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private set
            {
                _lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            private set
            {
                _age = value;
            }
        }
        //Methods
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
