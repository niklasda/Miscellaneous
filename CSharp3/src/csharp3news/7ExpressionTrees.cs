using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace LinqDemo
{
    /// <summary>
    /// Show the use of the new expression trees in C# 3.0
    /// </summary>
    public class ExpressionTrees
    {
        public delegate void SomeDelegate();
        
        public void UseExpressionTree()
        {
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ ExpTree");
            
            SomeDelegate del = () => Console.WriteLine("Hello again");
            del();
            
            // public delegate T Func<T, A>(A a);
            
            Func<int, string> xFunc = x => "x: "+ x.ToString();
            Console.WriteLine( "xFunc: "+ xFunc(13) );
            Console.WriteLine(  xFunc.GetType());
            
            
            Expression<Func<int, string>> yExpr = y => "y: "+ y.ToString();
            Console.WriteLine( yExpr.GetType());
            Console.WriteLine( yExpr.Type);
            
            Func<int, string> yFunc = yExpr.Compile();
            Console.WriteLine( "yFunc: "+ yFunc(14) );
            Console.WriteLine( yFunc.GetType() );
        }
    }
}
