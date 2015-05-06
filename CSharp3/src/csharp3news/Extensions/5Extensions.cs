using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    public static class Extensions
    {
        public static void ExpectCall<T>(this T source, string message)
        {
            Console.WriteLine("ExpectCall");
                
            Console.WriteLine("Source: "+ source.ToString());
            Console.WriteLine("Message: "+ message);
            //Console.WriteLine(MethodInfo.GetCurrentMethod().Name);
            
        }
 
        public static void ExpectOnObject(this Person source)
        {
            Console.WriteLine("SourceName: "+ source.Name);
            
        }
         
        public static void ExpectOnAnonObject<T>(this T source)
        {
            Console.WriteLine("Anon Source: "+ source);
            
        }
        
    }
}
