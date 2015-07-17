using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericStudy
{
    public class Person 
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() 
        {
        }

        public Person(string firstName, string lastName, int age) 
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", FirstName, LastName, Age);
        }
    }

    public class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        public Person GetPerson(int pos) 
        {
            return (Person)arPeople[pos];
        }

        public void AddPerson(Person p) 
        {
            arPeople.Add(p);
        }

        public void ClearPeople() 
        {
            arPeople.Clear();
        }

        public int Count
        {
            get 
            {
                return arPeople.Count;
            } 
        }
        public IEnumerator GetEnumerator()
        {
            return arPeople.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int>
        }
    }
}
