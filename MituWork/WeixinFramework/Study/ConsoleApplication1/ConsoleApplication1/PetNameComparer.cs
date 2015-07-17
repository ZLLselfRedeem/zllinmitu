using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class PetNameComparer : IComparer<Car>
    {
        // 显式实现接口，起到封装作用，不让外部访问
        public int Compare(Car x, Car y)
        {
            return string.Compare(x.PetName, y.PetName);
        }
    }
}
