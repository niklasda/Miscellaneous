using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OredevLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // type inference means its type-safe
            var hello = "kotte";
            var i = 8;
            //var f = 's';
            //hello = 4711;   // not possible

            Console.WriteLine(hello);
            Console.WriteLine(i);

            // type inference may be hard
            // will try to find best common type
            // will not infer something that will cause boxing.
            // string and int will not automatically cause an object[][]
            // you don't have to specify types on the arrays
            var xss = new [] { new [] { 2 },
                            new[] { 0, 1, 2 },
            };

            Console.WriteLine(xss);

            var cust = new Customer();
            cust.City = "Lund";
            Console.WriteLine(cust.City);

            // object initializers
            var c2 = new Customer 
            { 
                City = "Mmö", ContactName = "Nikl", CustomerID = "1" 
            };
            Console.WriteLine(c2.ContactName);


            // works for types with Add() methods
            // have to specify type, otherwise confusion will come
            var tutorials = new List<string>
            {
                "lalalala",
                "w00t",
                "niklas"

            };

            foreach (string s in tutorials)
            {
                Console.WriteLine(s);
            }



            // anon types
            // tutorial13 is of new type! with fields of vinfered types
            // because the CLR does not know anon types, the anon type cannot be known and written
            var tutorial13 = new
            {
                Title = "linq from the source",
                Presenters = new[] { "eric m", "ted new" },
                Room = "r516c"
            };

            Console.WriteLine(tutorial13);

            var tutorial14 = new
            {
                Title = "linq from the source",
                Presenters = new[] { "eric m", "ted new" },
                Room = "r516c"
            };

            // tutorial13 and 14 gets the same anon type.
            // if fields are changed arount it will not work,
            // which may be a bug
            tutorial13 = tutorial14;

            // haha read-onnly
        //    tutorial13.Title = "new tit";
          
            // but the read-only-ness is not transitive
            tutorial13.Presenters[0] = null;

            //wpf databinding with anan-types


            // lambda
            var l = "L";
            // the customer type cannot be inferred
            Func<Customer, bool> p = c => c.City.StartsWith(l); // using variable from outside of delegate
            // the Func p only has the reference to l so when p is called it will have the value "M"

            l = "M";
            // the type of c is specified here, but still cannot be inferred,
            // the compiler dont want to
            Func<Customer, bool> p1 = (Customer c) => c.City.StartsWith(l);

           // Func<Customer, bool> p2 = c => delegate(Customer c) { return true; };

            // expression tree
            // set breakpoint
            Expression<Func<Customer, bool>> ip =  c => c.City.StartsWith("M");

            Func<Customer, bool> ipc = ip.Compile();
            var vipc = ip.Compile();
            Console.Write(ip);
            Console.Write(ipc);
            Console.Write(vipc);


            // linq to sql
            // no demo since we have no sql data source
            // executing a query does not return anything,
            // just an ienumerable will will fetch data upon enumeration
            // make sure the query is not disposed before iterating
            // convering it with .ToList will execute it
            // you can query a query without executing it

            // a query either end with a select or group

            // ext methods
            var z = 2;
            Console.WriteLine(z.Double());
            var s1 = z.To(5);


            // lazyness
            IEnumerable<int> xs = null;
            try
            {
                xs = (from x in new[] { 0, 1, 2 } 
                      //where x > 0
                      select x / x).ToList() ;
            }
                // this block will not catch the div/0 since it not executed yet
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            var bomb = xs.ElementAt(0);
            Console.WriteLine(bomb);


            // use the objectdumper from the linq sample code

            // .Take, Group x by, into

            Console.ReadLine();

        }
    }
    
    // why not extension properties etc?
    // it was to hard, no good syntax

    // ext methods
    static class ext
    {
        public static int Double(this int x)
        {
            return x + x;
        }

        public static IEnumerable<int> To(this int start, int end)
        {
            for (var i = start; i < end; i++)
            {
                yield return i;
            }
        }
    }

    class Customer
    {
        // automatic getters and setters
        // can have different visibility
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }

}
