using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo
{
    /// <summary>
    /// A trivial logic class, that doesn't do much, but uses dependency injection
    /// </summary>
    public class Logic
    {
        public Logic(IDatabase database)
        {
            db = database;
        }
        private IDatabase db;
        
        public string GetDatabaseVersion()
        {
            /*
             *  do some logic... 
             */
            return db.GetVersion();
        }
    }
}
