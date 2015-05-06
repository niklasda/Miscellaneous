using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new object initializers in C# 3.0
    /// </summary>
    public class CollectionInitializers
    {
         public void UseCollectionInitializer()
         {
             // reflect
             IEnumerable<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             
             var people = new List<Person>
             {
                 new Person { Name = "Niklas " },
                 new Person { Name = "Niklas 2" },
             };
             
             Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ CollIni");
             
             foreach(int i in digits)
             {
                 Console.Write(string.Format("{0} - ", i));
             }
             Console.WriteLine("");
           
             foreach(Person p in people)
             {
                 Console.Write(string.Format("{0} - ", p.Name));
             }
             
             Console.WriteLine("");

             
         }
    }
}