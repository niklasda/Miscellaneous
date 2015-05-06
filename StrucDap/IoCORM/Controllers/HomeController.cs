using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;

using Dapper;
using IoCORM.Services;
using Microsoft.Ajax.Utilities;
using StructureMap;

namespace IoCORM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public static void BootstrapStructureMap()
        {
            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x => x.For<IRepository>().Use<Repository>().Ctor<string>("connectionString").Is("Data Source=tcp:oe2k49hqjl.database.windows.net,1433;Initial Catalog=leaderboard;User ID=niklas@oe2k49hqjl;Password=Vermin88;"));

            Debug.WriteLine(ObjectFactory.Container.WhatDoIHave());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            BootstrapStructureMap();

            var re = ObjectFactory.GetInstance<IRepository>();
            IEnumerable<IGame> games = re.GetGames();

            //List<HighScore> scores = re.GetHighScores();

            return View(games);
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    // C#
    public interface IGame
    {
        int Id { get; set; }

        string Name { get; set; }

    }

    public class Game : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IRepository
    {
        void Save(object target);

        string ConnectionString { get; }

        IEnumerable<IGame> GetGames();

        List<HighScore> GetHighScores();
    }

    public class Repository : IRepository
    {   
        public IEnumerable<IGame> GetGames()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                const string query = "select * from [dahlmanlabs_leaderboards].[Game]";
                return connection.Query<Game>(query);
            }
        }

        public List<HighScore> GetHighScores()
        {
            var svc = new LeaderboardService();
            var leaderboard = svc.GetLeaderboard();
            return leaderboard.Result;
        }

        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            this._connectionString = connectionString;
            // set up the persistence infrastructure using the connectionString
            // from the constructor argument
        }

        public string ConnectionString
        {
            get
            {
                return this._connectionString;
            }
        }

        public void Save(object target)
        {
            // save the object
        }
    }
}