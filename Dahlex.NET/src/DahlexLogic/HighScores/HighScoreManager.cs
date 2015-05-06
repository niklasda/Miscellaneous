using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Dahlex.Settings;

namespace Dahlex.HighScores
{
    public class HighScoreManager
    {
        public HighScoreManager(Options gameOptions)
        {
            _gameOptions = gameOptions;
            scores = LoadLocalHighScores();
        }

        private Options _gameOptions;
        private List<HighScore> scores;
        
        public void AddHighScore(int score, int level, int bombsLeft, int teleportsLeft, int moves, DateTime startTime, Size boardSize)
        {
            HighScore hs = new HighScore(_gameOptions.PlayerName, score, level, bombsLeft, teleportsLeft, moves, startTime, boardSize);
            scores.Add(hs);
        }

        public List<HighScore> GetHighScores()
        {
            return scores;
        }

        public int GetHighScoreCount()
        {
            return scores.Count;
        }

        public ListViewItem[] GetHighScoresForListView()
        {
            ListViewItem[] items = new ListViewItem[scores.Count];
            int i = 0;
            foreach(HighScore score in scores)
            {
                items[i++] = new ListViewItem(new string[] { score.Score.ToString(), score.Name, score.Level.ToString(), score.Moves.ToString(), "H:"+score.BoardSize.Height +" W:"+ score.BoardSize.Width, ((int)score.GameDuration.TotalSeconds).ToString() + "s" });
            }

            return items;
        }

        public List<HighScore> LoadLocalHighScores()
        {
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fs = null;

            try
            {
                //Options opt = new Options();
                FileInfo fi = new FileInfo(_gameOptions.LocalHighScoreFileName);
                if(fi.Exists)
                {
                    fs = fi.OpenRead();
                    scores = (List<HighScore>)fmt.Deserialize(fs);
                }
                else
                {
                    scores = new List<HighScore>();
                }
                return scores;
            }
            catch
            {
                return new List<HighScore>();   
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public void SaveLocalHighScores()
        {
            BinaryFormatter fmt = new BinaryFormatter();
            FileStream fs = null;
            
            try
            {
                FileInfo fi = new FileInfo(_gameOptions.LocalHighScoreFileName);
                fs = fi.Create();
                fmt.Serialize(fs, scores);
            }
            
            finally
            {
                if(fs!=null)
                {
                    fs.Close();
                }
            }
        }
    }
}
