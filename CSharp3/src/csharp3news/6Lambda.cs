using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new Lambda expressions in C# 3.0
    /// </summary>
    public class Lambda
    {
        public delegate void SomeDelegate();
        public delegate void SomeOneParamDelegate(string name);
        public delegate void SomeTwoParamDelegate(string name, int age);
        
        public void DoTheLambda()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Lambda1");
         
            SomeDelegate del = () => Console.WriteLine("Hello");
            del();
        
            // the compiler buys this, even though it looks bad
            SomeOneParamDelegate del2 = name => { Console.WriteLine(name); Console.WriteLine("Twice"); };
            del2("Niklas");
           
            SomeTwoParamDelegate del3 = (name, age) => Console.WriteLine(string.Format("{0} {1}", name, age.ToString()));
            del3("Niklas", 32);

        }
        
        public void UseLambdaAsParam()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Lambda2");
 
            // lambda as param
            Person p = new Person();
            p.Name = "Niklas";

            LambdaExtensions.Expector(() => p.NormalizeName());
            LambdaExtensions.Expector(() => p.DoAlmostNothing());
        }
        
        public void UseLambdaForEvent()
        {
            // old
            System.AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
            
            // new
            System.AppDomain.CurrentDomain.AssemblyLoad += (object s, AssemblyLoadEventArgs e) => Console.WriteLine("Event");
        }
        
        public void UseLambdaExtension()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ Lambda3");
            
            Console.WriteLine( "ABCDEF".Trim(x => x < 'C') ); 
        }

        // old event handler. will not be called
        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Event");
        }
    }
}