using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactor
{
    public class SportsCar : car
    {
        public string GetPetName() 
        {
            petName = "Fred";
            return petName;
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}
