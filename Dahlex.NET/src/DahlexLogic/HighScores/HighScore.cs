using System;
using System.Drawing;

namespace Dahlex.HighScores
{
    [Serializable()]
    public class HighScore
    {
        public HighScore(string name, int score, int level, int bombsLeft, int teleportsLeft, int moves, DateTime startTime, Size boardSize)
        {
            _name = name;
            _score = score;
            _level = level;
            _bombsLeft = bombsLeft;
            _teleportsLeft = teleportsLeft;
            _moves = moves;
            _gameDuration = DateTime.Now - startTime;
            _boardSize = boardSize;
        }
        
        private string _name;
        private int _score;
        private int _level;
        private int _bombsLeft;
        private int _teleportsLeft;
        private int _moves;
        private TimeSpan _gameDuration;
        private Size _boardSize;

        public string Name
        {
            get { return _name; }
        }

        public int Score
        {
            get { return _score; }
        }
        public int Level
        {
            get { return _level; }
        }
        public int BombsLeft
        {
            get { return _bombsLeft; }
        }
        public int TeleportsLeft
        {
            get { return _teleportsLeft; }
        }
        public int Moves
        {
            get { return _moves; }
        }
        public TimeSpan GameDuration
        {
            get { return _gameDuration; }
        }
        public Size BoardSize
        {
            get { return _boardSize; }
        }
    }
}
