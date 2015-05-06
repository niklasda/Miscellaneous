using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.IO.IsolatedStorage;

namespace Dahlex.Logic.HighScores
{
    public class HighScoreManager
    {
        public HighScoreManager()
        {
            _scores = LoadLocalHighScores();
        }

        private List<HighScore> _scores = new List<HighScore>();

        public void AddHighScore(string name, int level, int bombsLeft, int teleportsLeft, int moves, DateTime startTime, IntSize boardSize)
        {
            var hs = new HighScore(name, level, bombsLeft, teleportsLeft, moves, startTime, boardSize);
            _scores.Add(hs);
        }

        public IList<HighScore> GetHighScores()
        {
            return _scores;
        }

        public List<HighScore> LoadLocalHighScores()
        {
            using (IsolatedStorageFile root = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = new IsolatedStorageFileStream("dahlexhighscores.xml", FileMode.OpenOrCreate, root))
                {
                    var serializer = new DataContractSerializer(typeof(List<HighScore>));
                    try
                    {
                        _scores = (List<HighScore>)serializer.ReadObject(stream);
                        _scores.Sort(new HighScoreComparer());
                        _scores = _scores.GetRange(0, 20);
                    }
                    catch
                    {
                    }
                }
            }
            return _scores;
        }

        public void SaveLocalHighScores()
        {
            using (IsolatedStorageFile root = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = new IsolatedStorageFileStream("dahlexhighscores.xml", FileMode.Create, root))
                {
                    var serializer = new DataContractSerializer(typeof(List<HighScore>));
                    serializer.WriteObject(stream, _scores);
                }
            }
        }

        internal class HighScoreComparer : IComparer<HighScore>
        {
            public int Compare(HighScore x, HighScore y)
            {
                int cmp = y.Score.CompareTo(x.Score);
                if (cmp == 0)
                {
                    return x.GameDuration.CompareTo(y.GameDuration);
                }
                else
                {
                    return cmp;
                }
            }
        }
    }
}