using System;

namespace TennisMatch
{
    public interface ISet
    {
        int Player1Games { get; }
        int Player2Games { get; }
        void Start();
    }

    public class Set : ISet
    {
        public int Player1Games { get; private set; }
        public int Player2Games { get; private set; }

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Start Set");

            while((Player1Games < 6 || Player1Games - Player2Games < 2) && (Player2Games < 6 || Player2Games - Player1Games < 2))
            {
                var game = new Game();
                game.Start();

                if (game.Player1Score.IsGame)
                    Player1Games++;
                else
                    Player2Games++;

                Console.WriteLine($"Games: {Player1Games} - {Player2Games}");
            }

            Console.WriteLine();
            Console.WriteLine("End Set");
            Console.WriteLine();
        }
    }
}
