using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//主要程序集或模板级别特性必须在命名空间范围外定义

[assembly: CLSCompliant(true)]
//如果在该类中定义了不符合CLS的代码则会编译错误
namespace AttributedCarLibrary
{
    // 处于安全性的考虑，把所有的自定义特性都设计成密封的 这是为什么？？！！
    //限制自定义特性只能被应用到选定的代码元素上，需要在自定义特性的定义中应用
    //[AttributeUsage]特性
    // 一下表示特性[VehicleDescripionAttribute]特性只能在类或者结构中应用，并且该特性不能被派生类继承。
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute() 
        {
        }

        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
    }
}
