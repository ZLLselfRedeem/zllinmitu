using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using YJC.Toolkit.Sys;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###### Welcome to MyTypeViewer ######");
            string typeName = "";

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.WriteLine("or ent Q to quit: ");

                typeName = Console.ReadLine();

                if (typeName.ToUpper() == "Q")
                    break;
                try
                {
                    Type t = Type.GetType(typeName);
                    ListVariousStates(t);
                    ListFields(t);
                    ListProperties(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find type");
                }
            } while (true);
        }

        static void ListMethods(Type t) 
        {
            Console.WriteLine("###### Methods ######");
            //MethodInfo[] mi = t.GetMethods();
            //foreach(MethodInfo m in mi)
            //    Console.WriteLine("->{0}", m.Name);

            //MethodInfo[] methodNames = t.GetMethods();
            //foreach (var name in methodNames)
            //{
            //    Console.WriteLine("->{0}", name);
            //}
            //Console.WriteLine();
            //foreach (var mn in methodNames)
            //{
            //    string retVal = mn.ReturnType.FullName;
            //    string paramInfo = "(";
            //    foreach (ParameterInfo pi in mn.GetParameters())
            //    {
            //        paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
            //    }
            //    paramInfo += ")";
            //    Console.WriteLine("->{0} {1} {2}", retVal, mn.Name, paramInfo);
            //}
            var methodsNames = from n in t.GetMethods()
                               select n;
            foreach (MethodInfo mi in methodsNames) 
            {
                // 我们知道每一个XXXInfo类型（MethodInfo、PropertyInfo、EventInfo等）都重写
                //了ToString()方法来显示请求项的签名。Console.WriteLine会自动调用ToString()方法
                Console.WriteLine("->{0}", mi);
            }
            Console.WriteLine();
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("###### Fields ######");
            var FieldNames = from fName in t.GetFields() select fName.Name;
            foreach (var f in FieldNames) 
                Console.WriteLine("->{0}", f);
            Console.WriteLine();
        }

        static void ListProperties(Type t) 
        {
            Console.WriteLine("###### Properties ######");
            var PropertyNames = from pName in t.GetProperties() select pName.Name;
            foreach(var pn in PropertyNames)
                Console.WriteLine("->{0}", pn);
            Console.WriteLine();
        }

        static void ListInterfaces(Type t) 
        {
            Console.WriteLine("###### Interfaces ######");
            var InterfaceNames = from iName in t.GetInterfaces() select iName;
            foreach(Type ifn in InterfaceNames)
                Console.WriteLine("->{0}", ifn.Name);
            Console.WriteLine();
        }

        static void ListVariousStates(Type t)
        {
            Console.WriteLine("###### VariousStates ######");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}",t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);

            Console.WriteLine();
        }
    }
}
