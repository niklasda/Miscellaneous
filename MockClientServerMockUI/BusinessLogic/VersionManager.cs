using System;
using System.Reflection;
using Mockdemo.BusinessClasses;
using Mockdemo.Server;

namespace Mockdemo.BusinessLogic
{
    public class VersionManager
    {
        public VersionManager(bool isConnected)
        {
            connected = isConnected;
            db = new Database(connected);
        }
        public VersionManager(IDatabase database)
        {
            db = database;
        }
        private bool connected = false;
        private IDatabase db;
        
        private string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public string GetDatabaseVersion()
        {
          //  Database db = new Database(connected);
            return db.GetVersion();
        }


        public void PrintVersionNumber(IViewUI view)
        {
            UiRenderer uir = new UiRenderer();
            uir.AppendString(view, "Database:" + GetDatabaseVersion(), true);
            uir.AppendString(view, "Ctrl:" + GetVersion(), false);
            uir.AppendString(view, new Random().NextDouble(), false);
        }

        // dont use
        public void PrintVersionNumber(IViewUI view, string ver)
        {
            UiRenderer uir = new UiRenderer();
            uir.AppendString(view, ver, false);
            //throw new Exception("The method or operation is not implemented.");
            
        }
    }
}
