using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new object initializers in C# 3.0
    /// </summary>
    public class ObjectInitializers
    {
         public void UseObjectInitializer()
         {
             var pers = new Person 
             {
                 Name = "Niklas",
                 Gender = "Male",
                 Age = 32,
                 Adr = new Address { Street = "Albog 7", City = "Lund" }
             };
             
             
             Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ ObjIni");
             Console.WriteLine(pers);

             pers.Adr = new Address { Street = "Blg 7", City = "Lund" };
             Console.WriteLine(pers);
         }
    }
}