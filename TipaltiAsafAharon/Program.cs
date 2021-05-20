using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace TipaltiAsafAharon
{
    class Program
    {
        // Print Class: type + properties
        public static void PrintClass(object obj, string spacePadding)
        {
            Console.WriteLine(spacePadding + "Object of Class " + GetClassName(obj));
            Console.WriteLine(spacePadding + "--------------------");
            spacePadding += "     ";
            PrintP(obj, spacePadding);
        }
        
        // Get Name of Custom classes
        public static string GetClassName(object obj)
        {
            return obj.GetType().Name;
        }

        // Print properties
        public static void PrintP(object obj, string spacePadding)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                if (value.GetType().Namespace != "System")
                {
                    PrintClass(value, spacePadding);
                }
                else
                {
                    Console.WriteLine(spacePadding + "{0}={1}", name, string.Join(",", value));
                }
            }
        }


        static void Main(string[] args)
        {
            Name n = new Name();
            n.FirstName = "Asaf";
            n.LastName = "Aharon";

            Person p = new Person();
            p.Age = 24;
            p.Name = n;

            PrintClass(p, "");
        }
    }
}
