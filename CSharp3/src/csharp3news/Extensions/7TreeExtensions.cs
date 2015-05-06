using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    public static class TreeExtensions
    {
       
        public delegate void SomeDelegate();
        
        public static void Expector(SomeDelegate sd)
        {
            Console.WriteLine("Delegate method: " + sd.Method.ToString());
            Console.WriteLine("Delegate target: " + sd.Target.ToString());
            Console.WriteLine("Delegate: " + sd.ToString());
        }
    
    }
}
