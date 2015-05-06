using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemo
{
    public static class LinqExtensions
    {
       
        
        public static void ConsoleWrite<T>(this IEnumerable<T> enumer)
        {
            foreach(T item in enumer)
            {
                Console.WriteLine(item);
            }
        }
    
    }
}
