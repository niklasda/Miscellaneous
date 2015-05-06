using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new var keyword in C# 3.0
    /// </summary>
    public class Var
    {
        public void UseVar()
        {
            var s = "Niklas";
            var i = 123;
            var list = new List<string>();
            list.Add("Not Niklas again");
            
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Var");
            
            Console.WriteLine(s.GetType() +" - "+ s.ToUpper());     // the compiler accepts this, IntelliSense does not
            Console.WriteLine(i.GetType() +" - "+ i);
            Console.WriteLine(list.GetType() +" - "+ list.Count);
        }
    }
 
}