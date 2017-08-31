using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Fun with Late Binding***");
            Assembly a = null;
            try {
                a = Assembly.LoadFrom("C:\\C#\\MyC#StudyProjects\\07_DifferentMains\\LateBindingApp\\LateBindingApp\\bin\\Debug\\CarLibrary2.dll");
                }
            catch (FileNotFoundException ex)
                {
                Console.WriteLine(ex.Message);
                return;
                }

                if (a != null) CreateUsingLateBinding(a);
                Console.ReadLine();

        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                object obj = Activator.CreateInstance(miniVan);

                // call method with reflection
                MethodInfo mi = miniVan.GetMethod("TurboBoost"); // invoke method without params
                mi.Invoke(obj, null);

                // call method with reflection with params
                MethodInfo mi1 = miniVan.GetMethod("TurnOnRadio"); // invoke method with params
                //object[] paramsArray=new object[] {true, "someRadioMessage"}
                mi1.Invoke(obj, new object[] { true, "someRadioMessage" });

                // setting private field
                // typeof(Foo).GetField("_bar", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(objectForFoocClass, "newValue");
                miniVan.GetField("SomeField", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(obj, "SomeValue");

                // getting private field
                // var _barVariable = typeof(Foo).GetField("_bar", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(objectForFooClass);
                var fieldValue =miniVan.GetField("SomeField", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);
                Console.WriteLine(fieldValue);


                Console.WriteLine("Created a {0} using late binding!", obj);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }



}
