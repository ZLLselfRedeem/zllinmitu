using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOverrdes
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string SSN { get; set; }

        public Person(string firstNema, string lastName, int age)
        {
            FirstName = firstNema;
            LastName = lastName;
            Age = age;
        }

        public Person() 
        {
        }

        public override string ToString()
        {
            string myState;
            myState = string.Format("[First Name: {0}; Last Name: {1}; Age: {2}]", 
                FirstName, LastName, Age);
            return myState;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is Person && obj != null)
        //    {
        //        Person temp;
        //        temp = (Person)obj;
        //        if (temp.FirstName == FirstName && temp.LastName == LastName && temp.Age == Age)
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //        return false;
        //}

        // 另一种重载Equals的方法，是比较两个对象的ToString是否相等。
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else 
            {
                return obj.ToString() == this.ToString();
            }
        }

        public override int GetHashCode()
        {
            //return SSN.GetHashCode();
             return this.ToString().GetHashCode();
        }
    }
}
