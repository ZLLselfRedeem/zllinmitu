using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace DynamicAsmBuider
{
    class Program
    {
        // 调用者传入一个AppDomain类型
        public static void CreateMyAsm(AppDomain curAppDomain)
        {
            // 建立通用的程序集特征
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "MyAssembly";
            assemblyName.Version = new Version("1.0.0.0");

            // 在当前AppDomain（应用程序域）中创建一个新的程序集
            AssemblyBuilder assembly = 
                curAppDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

            // 鉴于我们构造的是一个单文件程序集，模块的名字就是程序集的名字
            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            // 定义一个公共类“HelloWorld”
            TypeBuilder helloWorldClass = 
                module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);

            // 定义一个私有字符串成员变量“theMessage”
            FieldBuilder msgField = 
                helloWorldClass.DefineField("theMessage", Type.GetType("System.String"), 
                FieldAttributes.Private);

            // 创建自定义的构造函数

            Type[] constructorArgs = new Type[1];
            constructorArgs[0] = typeof(string);

            ConstructorBuilder constructor = 
                helloWorldClass.DefineConstructor(MethodAttributes.Public, 
                CallingConventions.Standard, constructorArgs);

            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            Type objectClass = typeof(object);
            ConstructorInfo superConstructor = objectClass.GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);

            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            MethodBuilder getMsgMethod =
                helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);

            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Hello form the HelloWorld class!");
            methodIL.Emit(OpCodes.Ret);

            helloWorldClass.CreateType();

            assembly.Save("MyAssembly.dll");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Dynamic Assembly Builder App *****");
            // 得到当前线程的应用程序域
            AppDomain curAppDomain = Thread.GetDomain();

            // 使用辅助函数创建动态程序集
            CreateMyAsm(curAppDomain);
            Console.WriteLine("-> Finished creating MyAssembly.dll");

            // 加载到新的程序集
            Console.WriteLine("-> Loading MyAssembly.dll from file.");
            Assembly a = Assembly.Load("MyAssembly");
            Type hello = a.GetType("MyAssembly.HelloWorld");
            Console.WriteLine("-> Enter message to pass HelloWorld class:");
            string msg = Console.ReadLine();
            object[] ctorArgs = new object[1];
            ctorArgs[0] = msg;
            object obj = Activator.CreateInstance(hello, ctorArgs);

            // 调用SayHello()并且显示返回的字符串
            Console.WriteLine("-> Calling SayHello() via late binding");
            MethodInfo mi = hello.GetMethod("SayHello");
            mi.Invoke(obj, null);

            // 出发GetMsg()
            mi = hello.GetMethod("GetMsg");
            Console.WriteLine(mi.Invoke(obj, null));
        }
    }
}
