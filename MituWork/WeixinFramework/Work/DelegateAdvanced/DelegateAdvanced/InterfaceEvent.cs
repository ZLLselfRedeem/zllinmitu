using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAdvanced
{
    public interface IDrawingObject
    {
        event EventHandler OnDraw;
    }

    public interface IShape
    {
        event EventHandler OnDraw;
    }

    public class Shape : IDrawingObject, IShape
    {
        event EventHandler PreDrawEvent;
        event EventHandler PostDrawEvent;

        object objectLock = new object();

        // 需要显示的实现接口，并且把IDrawingObject的事件与
        // PreDrawEvent联系起来
        event EventHandler IDrawingObject.OnDraw
        {
            add 
            {
                lock (objectLock)
                {
                    PreDrawEvent += value;
                }
            }
            remove 
            {
                lock (objectLock)
                {
                    PreDrawEvent -= value;
                }
            }
        }

        // 同理把PostDrawEvent与IShap接口关联起来
        event EventHandler IShape.OnDraw
        {
            add 
            {
                lock (objectLock)
                {
                    PostDrawEvent += value;
                }
            }
            remove 
            {
                lock (objectLock)
                {
                    PostDrawEvent -= value;
                }
            }
        }

        public void Draw()
        {
            EventHandler handler = PreDrawEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            Console.WriteLine("Drawing a shape");

            handler = PostDrawEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }

    public class Subscriber1
    {
        public Subscriber1(Shape shape)
        {
            IDrawingObject d = (IDrawingObject)shape;
            d.OnDraw += delegate(object sender, EventArgs e)
            {
                Console.WriteLine("Sub1 receives the IDrawingObject event.");
            };
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub1 receives the IDrawingObject event.");
        }
    }

    public class Subscribe2
    {
        public Subscribe2(Shape shape)
        {
            IShape d = (IShape)shape;
            d.OnDraw += (sender, e) =>
                {
                    Console.WriteLine("Sub2 receives the IShape event.");
                };
        }
    }
}
