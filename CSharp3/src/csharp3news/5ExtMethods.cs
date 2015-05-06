using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new extension methods in C# 3.0
    /// </summary>
    public class ExtMethods
    {
        public void UseExtensionMethod()
        {
            Person p = new Person();
            p.Name = "Niklas";
            
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ ExtMe1");
            
            p.NormalizeName().ExpectCall("my message 1");
            
            // Call it the regular way
            Extensions.ExpectCall(p.NormalizeName(), "my message 2");
            
            // Cannot have extension methods on void methods
            
            // direct on object instead of on method
            p.ExpectOnObject();
        }
        
        
       public void UseExtensionMethodOnAnon()
       {    
           var obj = new
           {
               Name = "Niklas",
               Gender = "Male"
           };
           
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ ExtMe2");
            
           obj.ExpectOnAnonObject();
       }
    }
}