using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of Linq in C# 3.0
    /// </summary>
    public class Linq
    {

        public void UseLinq()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Linq");
            
            string[] staffList = {"Person1", "Person2", "Person3", "Person5", "boss"};
            
            IEnumerable<string> q1 = from staff in staffList 
                           where staff.Length == 4 
                            orderby staff select staff.ToUpper();

            
            
//  public static IEnumerable<T> Where<T>(
//	this IEnumerable<T> source,
//	Func<T, bool> predicate);

            // IEnumerable<string> 
            var q2 = staffList.Where(staff => staff.Length == 4);
            
            
            
            
//  public static OrderedSequence<T> OrderBy<T, K>(
//	this IEnumerable<T> source,
//	Func<T, K> keySelector);

            // IEnumerable<string> 
            var q3 = staffList.Where(staff => staff.Length == 7).OrderBy(staff => staff) ;
            
            
            
            
//  public static IEnumerable<S> Select<T, S>(
//	this IEnumerable<T> source,
//	Func<T, S> selector);
            
            // IEnumerable<?> 
            var q4 = staffList.Where(staff => staff.Length == 7).OrderBy(staff => staff).Select(staff => new {Name = staff.ToUpper()}) ;
        
            // IEnumerable<Person> 
            var q5 = staffList.Where(staff => staff.Length == 7).OrderByDescending(staff => staff).Select(staff => new Person {Name = staff.ToUpper()}) ;
        
            
            
            foreach(string s in q1)
            {
                Console.WriteLine(s);
            }
            
            
            
            Console.WriteLine("---------");
            foreach(string t in q2)
            {
                Console.WriteLine(t);
            }
            
            
            
            Console.WriteLine("----------");
            foreach(string u in q3) 
            {
                Console.WriteLine(u);
            }
              
            
            
            Console.WriteLine("----------");
            foreach(var u in q4) // q3 is IEnumerable of anon ...
            {
                Console.WriteLine(u.Name);
            }
            
            
            
            Console.WriteLine("----------");
            foreach(Person p in q5) 
            {
                Console.WriteLine(p.Name);
            }
            
        }
       
        public void LinqSadExample()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Linq2");

            var size = FuncInfer(@"..\..\Images\professor_01.png", 
                                 s => new FileInfo(s), t => t.Length);
            Console.WriteLine("Size: "+ size);
        }
        
        private static Z FuncInfer<X, Y, Z>(X value, Func<X, Y> f1, Func<Y, Z> f2)
        {
            return f2(f1(value));
        }       
        
        public void LinqSadderExample()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Linq3");
           
           Func<long, object, long> f = (A, B) => A == 0 ? 1 : (A*((Func<long,object,long>)B)(A-1,B));
           Func<long, long> factorial = A => f(A, f);

           Console.WriteLine(factorial(25).ToString("#,###"));
            // outputs 7,034,535,277,573,963,776
        }
        
        
        public void LinqExampleBetter()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Linq4");
            
            var numbers = new[] {1,2,3,4,5,6,7,8,9,0,10,11,12};
            
            var q1 = from num in numbers where num <= 4 select num;
            
            q1.ConsoleWrite();  // with extension
        }

    }
}