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
            try { a = Assembly.LoadFrom("CarLibrary.dll"); }
            catch (FileNotFoundException ex) { Console.WriteLine(ex.Message);return; }

            if (a != null) CreateUsingLateBinding(a);
            Console.ReadLine();

        }

        static void CreateUsingLateBinding(Assembly asm) {
            try {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                object obj = Activator.CreateInstance(miniVan);                
                Console.WriteLine("Created a {0} using late binding!",obj);
            } catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }



}
