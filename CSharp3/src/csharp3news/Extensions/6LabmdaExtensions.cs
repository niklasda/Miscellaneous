using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqDemo
{
    public static class LambdaExtensions
    {
        
        
        public delegate void SomeDelegate();
        
        public static void Expector(SomeDelegate sd)
        {
            Console.WriteLine("Delegate method: " + sd.Method.ToString());
            Console.WriteLine("Delegate target: " + sd.Target.ToString());
            Console.WriteLine("Delegate: " + sd.ToString());
        }
    
 
        
        public static string Trim(this string inputString, Func<char, bool> criteria)
        {
            StringBuilder outBuilder = new StringBuilder();
            foreach(char c in inputString)
            {
                if(criteria(c))
                {
                    outBuilder.Append(c);
                }
                 
            }
            return outBuilder.ToString();
        }
    
    }
}
