using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LinqDemo
{   
    
    public class Program
    {
        public static void Main(string[] args)
        { 
            Var varDemo = new Var();
            varDemo.UseVar();
            
            Console.ReadLine();
            
            ObjectInitializers objIniDemo = new ObjectInitializers();
            objIniDemo.UseObjectInitializer();
            
            Console.ReadLine();
            
            CollectionInitializers collIniDemo = new CollectionInitializers();
            collIniDemo.UseCollectionInitializer();
            
            Console.ReadLine();
            
            AnonTypes anonDemo = new AnonTypes();
            anonDemo.UseAnonType();
            
            Console.ReadLine();
            
            ExtMethods extDemo = new ExtMethods();
            extDemo.UseExtensionMethod();
            Console.ReadLine();
            extDemo.UseExtensionMethodOnAnon();
            
            Console.ReadLine();
            
            Lambda lambdaDemo = new Lambda();
            lambdaDemo.DoTheLambda();
            Console.ReadLine();
            lambdaDemo.UseLambdaAsParam();
            Console.ReadLine();
            lambdaDemo.UseLambdaExtension();
            
            Console.ReadLine();
            
            ExpressionTrees expTreeDemo = new ExpressionTrees();
            expTreeDemo.UseExpressionTree();
            
            Console.ReadLine();
            
            Linq linqDemo = new Linq();
            linqDemo.UseLinq();
            Console.ReadLine();
            linqDemo.LinqSadExample();
            Console.ReadLine();
            linqDemo.LinqSadderExample();
            Console.ReadLine();
            linqDemo.LinqExampleBetter();
            
            
            Console.ReadLine();
            
        }
    }
}
