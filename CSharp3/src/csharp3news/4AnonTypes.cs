using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new anonymous types in C# 3.0
    /// </summary>
    public class AnonTypes
    {
        
        public void UseAnonType()
        {
            var obj = new
            {
                Name = "Niklas",
                Gender = "Male",
                Numbers = new[] { 1, 2, 3, 4 }
            };
           
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Anon");
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.Gender);
            Console.WriteLine(obj);             // Cannot override ToString() in this case 
                                                // since anon methods have no methods.
            
            foreach(var i in obj.Numbers)       // the compiler decided that an int[] was good
            {
                Console.Write(string.Format("{0} - ", i));
            }
            Console.WriteLine(""); 
        }
    }
}