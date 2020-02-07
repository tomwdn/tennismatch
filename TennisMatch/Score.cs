using System;

namespace TennisMatch
{
    public class Score
    {
        private ScoreEnum _score;

        public Score()
        {
            _score = ScoreEnum.Love;
        }

        public bool IsForty => _score == ScoreEnum.Forty;
        public bool IsGame => _score == ScoreEnum.Game;
        public bool IsAdvantage => _score == ScoreEnum.Advantage;

        public override string ToString()
        {
            switch (_score)
            {
                case ScoreEnum.Love:
                    return "Love";
                case ScoreEnum.Fifteen:
                    return "15";
                case ScoreEnum.Thirty:
                    return "30";
                case ScoreEnum.Forty:
                    return "40";
                case ScoreEnum.Advantage:
                    return "Adv";
                default:
                    throw new InvalidOperationException("Can't ToString this score.");
            }
        }

        public void AddPoint()
        {
            _score++;
        }

        public void SetToForty()
        {
            _score = ScoreEnum.Forty;
        }

        private enum ScoreEnum
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3,
            Advantage = 4,
            Game = 5
        }
    }
}