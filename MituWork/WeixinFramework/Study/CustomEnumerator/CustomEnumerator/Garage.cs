using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CustomEnumerator
{
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4] ;

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30); 
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        //yield 关键字可以在任何方法中使用， 而不仅仅是GetIEnumerator()方法中
        // 这就是所谓的命名迭代器，但是注意 这个方法必须返回IEnumerable而不是返回
        // 与IEnumerable先兼容的类型
        public IEnumerable GetTheCars(bool ReturnRevesed) 
        {
            // Return the items in reverse
            if (ReturnRevesed)
            {
                for (int i = carArray.Length; i != 0; i--)
                {
                    yield return carArray[i - 1];
                }
            }
            else 
            {
                // return the items as placed in the array
                for (int i = 0; i < carArray.Length; ++i) 
                {
                    yield return carArray[i];
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            //return carArray.GetEnumerator();
            // 使用内部foreach,并且使用yield语句来返回每个Car
            // yield关键字 用来指定 访问者的foreach结构的返回值
            // 当运行达到一个yield返回语句时，在容器中的当前位置会被记录，
            // 当下次被访问时，从记录的位置开始。
            foreach (Car c in carArray)
                yield return c;

            // 也可以写成这种形式 但是这种形式不适用，
            //yield return carArray[0];
            //yield return carArray[1];
            //yield return carArray[2];
            //yield return carArray[3];
        }
        

        //显式实现接口，隐藏了GetEnumerator的函数实现
        //IEnumerator IEnumerable.GetEnumerator() 
        //{
        //    return carArray.GetEnumerator();
        //}
    }
}
