using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLib;
using Numbers;
using System.Reflection;

namespace AttrPracticeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectOnAttributesUsingEarlyBinding(); // early binding
            EvenNumbersWithIteration();
            NotEvenNumbers(); // late binding
            EvenNumbers(); // late binding
            EvenNotEvenOrBoth(); // late binding
            Console.ReadLine();

        }


        static void EvenNumbersWithIteration() {

            // get types
            Assembly asm = Assembly.LoadFile("C:\\C#\\MyC#StudyProjects\\08_Attributes\\Practice\\AttrPracticeMain\\AttrPracticeMain\\bin\\Debug\\Numbers.dll");
            Type TCustomAttribute = asm.GetType("Numbers.CustomAttribute");
            PropertyInfo PropertyDescription = TCustomAttribute.GetProperty("Description");


            Type[] types = asm.GetTypes();          

            //iterate through types
            foreach (Type t in types)
            {
                object[] objs = t.GetCustomAttributes(TCustomAttribute, false);
                foreach (object o in objs)
                {
                    if ((t.Name == "EvenNumbers") && (PropertyDescription.GetValue(o, null).ToString() == "EvenNumbersClass"))
                    {
                        //    Console.WriteLine("Catched");

                        //Create instance and fill array with Evens
                        object EvenNumbersObject = Activator.CreateInstance(t);
                        (EvenNumbersObject as EvenNumbers).Content = new int[]
                        {
                            2,
                            4,
                            6
                        };

                        Console.WriteLine("Success even numbers with iteration");                        
                    }
                }
                
            }


        }



        static void EvenNumbers()
        {
            Assembly asm = Assembly.LoadFile("C:\\C#\\MyC#StudyProjects\\08_Attributes\\Practice\\AttrPracticeMain\\AttrPracticeMain\\bin\\Debug\\Numbers.dll");
            Type TCustomAttribute = asm.GetType("Numbers.CustomAttribute");
            Type TEvenNumbers=asm.GetType("Numbers.EvenNumbers");
            PropertyInfo PropertyDescription = TCustomAttribute.GetProperty("Description");

            
            var myCustomAttribute= TEvenNumbers.GetCustomAttribute(TCustomAttribute);
            if (PropertyDescription.GetValue(myCustomAttribute, null).ToString() == "EvenNumbersClass")
            {
                // create instance and fill array
                object EvenNumbersObject = Activator.CreateInstance(TEvenNumbers);
                (EvenNumbersObject as EvenNumbers).Content = new int[]
                {
                            2,
                            4,
                            6
                };
                Console.WriteLine("Success with Even Numbers");
            }

        }


        static void NotEvenNumbers()
        {
            Assembly asm = Assembly.LoadFile("C:\\C#\\MyC#StudyProjects\\08_Attributes\\Practice\\AttrPracticeMain\\AttrPracticeMain\\bin\\Debug\\Numbers.dll");
            Type TCustomAttribute = asm.GetType("Numbers.CustomAttribute");
            Type TNotEvenNumbers = asm.GetType("Numbers.NotEvenNumbers");
            PropertyInfo pi = TCustomAttribute.GetProperty("Description");

            var myCustomAttribute = TNotEvenNumbers.GetCustomAttribute(TCustomAttribute);
            if (pi.GetValue(myCustomAttribute, null).ToString() == "NotEvenNumbersClass")
            {
                // create instance and fill array
                object EvenNumbersObject = Activator.CreateInstance(TNotEvenNumbers);
                (EvenNumbersObject as NotEvenNumbers).Content = new int[]
                {
                            1,
                            3,
                            5
                };
                Console.WriteLine("Success with non Even Numbers");
            }

        }




        static void EvenNotEvenOrBoth()
        {
            Assembly asm = Assembly.LoadFile("C:\\C#\\MyC#StudyProjects\\08_Attributes\\Practice\\AttrPracticeMain\\AttrPracticeMain\\bin\\Debug\\Numbers.dll");
            Type TCustomAttribute = asm.GetType("Numbers.CustomAttribute");
           
            Type TAllNumbers = asm.GetType("Numbers.AllNumbers");
            PropertyInfo pi = TCustomAttribute.GetProperty("Description");

            var myCustomAttribute = TAllNumbers.GetCustomAttribute(TCustomAttribute);



            if (pi.GetValue(myCustomAttribute, null).ToString() == "EvenNumbers")
            {
                // create instance and fill array
                object EvenNumbersObject = Activator.CreateInstance(TAllNumbers);
                (EvenNumbersObject as AllNumbers).Content = new int[]
                {
                            2,
                            4,
                            6
                };
                
            }

            else

            if (pi.GetValue(myCustomAttribute, null).ToString() == "NotEvenNumbers")
            {
                // create instance and fill array
                object EvenNumbersObject = Activator.CreateInstance(TAllNumbers);
                (EvenNumbersObject as AllNumbers).Content = new int[]
                {
                            1,
                            3,
                            5
                };
              
            }


            else

            if (pi.GetValue(myCustomAttribute, null).ToString() == "EvenAndUnEvenNumbers")
            {
                // create instance and fill array
                object NumbersObject = Activator.CreateInstance(TAllNumbers);
                (NumbersObject as AllNumbers).Content = new int[]
                {
                            1,
                            2,
                            3,
                            4,
                            5,
                            6
                };
                
            }
            Console.
                WriteLine("Success with non Even Numbers. Current option is "+ (pi.GetValue(myCustomAttribute, null).ToString()));

            
        }



        // read attributes early binding
        private static void ReflectOnAttributesUsingEarlyBinding()
        {
            Type t = typeof(SportsCar); // Knowing type SportsCar, so early binding
            object[] customAtts = t.GetCustomAttributes(false);
            foreach (Object o in customAtts)
            {
                if (o is CustomAttributeDescription)
                Console.WriteLine("->{0}\n", (o as CustomAttributeDescription).Description);
            }
                
        }


    }
}
