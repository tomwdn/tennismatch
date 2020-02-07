using System;

namespace TennisMatch
{
    public interface IGame
    {
        Score Player1Score { get; }
        Score Player2Score { get; }
        void Start();
    }

    public class Game : IGame
    {
        public Game()
        {
            Player1Score = new Score();
            Player2Score = new Score();
        }

        public Score Player1Score { get; set; }
        public Score Player2Score { get; set; }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Start Game");

            while (!IsGame()) PlayPoint();

            Console.WriteLine(Player1Score.IsGame ? "Player 1 wins" : "Player 2 wins");
            Console.WriteLine("End Game");
            Console.WriteLine();
        }

        private void PlayPoint()
        {
            if (Player1WinsPoint())
                Player1Score.AddPoint();
            else
                Player2Score.AddPoint();

            if (Player1Score.IsAdvantage && Player2Score.IsAdvantage)
            {
                Player1Score.SetToForty();
                Player2Score.SetToForty();
            }
            else if (Player1Score.IsAdvantage && !Player2Score.IsForty)
            {
                Player1Score.AddPoint();
            }
            else if (Player2Score.IsAdvantage && !Player2Score.IsForty)
            {
                Player2Score.AddPoint();
            }

            if (IsGame())
                return;

            Console.WriteLine(IsDeuce() ? "Deuce" : $"{Player1Score} - {Player2Score}");
        }

        private bool IsGame()
        {
            return Player1Score.IsGame || Player2Score.IsGame;
        }

        private bool IsDeuce()
        {
            return Player1Score.IsForty && Player2Score.IsForty;
        }

        private bool Player1WinsPoint()
        {
            return new Random().Next() > int.MaxValue / 2;
        }
    }
}