using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Dahlex.HighScores;
using Dahlex.Settings;
using NUnit.Framework;

namespace DahlexTests
{
    /// <summary>
    ///This is a test class for Dahlex.BoardDefinition and is intended
    ///to contain all Dahlex.BoardDefinition Unit Tests
    ///</summary>
    [TestFixture()]
    public class HighScoresTest
    {

        [Test()]
        public void ManagerTest()
        {
            // todo Mock the options!!
            Options opt = new Options();
            opt.PlayerName = "Niklas";
            
            HighScoreManager man = new HighScoreManager(opt);
            int scoresBefore = man.GetHighScoreCount();
            
            man.AddHighScore(10, 10, 1, 1, 122, DateTime.Today, new Size(3,3));
            Assert.AreEqual(scoresBefore+1, man.GetHighScores().Count);

            man.AddHighScore(11, 10, 1, 1, 122, DateTime.Today, new Size(3, 3));

            Assert.AreEqual(scoresBefore + 2, man.GetHighScores().Count);
            Assert.AreEqual(scoresBefore + 2, man.GetHighScoresForListView().Length);
        }

        [Test()]
        public void ManagerSaveTest()
        {
            // todo Mock the options!!
            Options opt = new Options();
            opt.PlayerName = "Niklas";

            HighScoreManager man = new HighScoreManager(opt);
            man.AddHighScore(10, 10, 1, 1, 122, DateTime.Today, new Size(3, 3));

            man.AddHighScore(11, 10, 1, 1, 122, DateTime.Today, new Size(3, 3));

            man.SaveLocalHighScores();
            
            FileInfo fi = new FileInfo(opt.LocalHighScoreFileName);
            Assert.AreEqual(true, fi.Exists, "Failed to save highscores");
        }
        
        [Test()]
        public void ManagerLoadTest()
        {
            // todo Mock the options!!
            Options opt = new Options();
            opt.PlayerName = "Niklas";

            HighScoreManager man = new HighScoreManager(opt);

            List<HighScore> scores = man.LoadLocalHighScores();
            Assert.IsNotNull(scores, "Failed to load highscores");
        }
    }
}
