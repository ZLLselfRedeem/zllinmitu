using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    /// <summary>
    /// aggreation class of car
    /// </summary>
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return carArray.GetEnumerator();
        //}


        // 使用迭代器来构建可以使用foreach循环的类型。
        // 隐式实现该接口，如果需要封装的话，也可以显式实现该接口来达到封装的目的，foreach在需要的时候可以在底层获得。
        // foreach实现的机制是怎么样的?
        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
            {
                yield return c;
            }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    yield return carArray[0];
        //    yield return carArray[1];
        //    yield return carArray[2];
        //    yield return carArray[3];
        //}

        public IEnumerable GetTheCars(bool ReturnReversed)
        {
            if (ReturnReversed)
            {
                for (int i = carArray.Length; i != 0; i--)
                {
                    yield return carArray[i - 1];
                }
            }
            else
            {
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }
    }
}
