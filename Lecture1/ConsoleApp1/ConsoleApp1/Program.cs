using System;
using System.Reflection;
using System.Reflection.Emit;
using UserLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("UserLibrary.dll");
            Type type = assembly.GetType("UserLibrary.User", true, true);
            object obj = Activator.CreateInstance(type, new object[] { "Max",18});
            Console.WriteLine("By ToString override: {0}",obj);

            MethodInfo method = type.GetMethod("DisplayInfo");
            object result = method.Invoke(obj,new object[]{});
            Console.WriteLine("By method \"DisplayInfo\": {0}",result);
                
            Console.WriteLine("\n-------------------------------------------------");
            var members = type.GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }


        }
    }

}
