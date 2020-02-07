using System;
using System.Collections.Generic;

namespace TennisMatch
{
    public class Match
    {
        private readonly ISetFactory _setFactory;

        public Match(ISetFactory setFactory)
        {
            _setFactory = setFactory;
        }

        public List<ISet> Play()
        {
            Console.WriteLine("Start Match");

            var sets = new List<ISet>();
            var player1Sets = 0;
            var player2Sets = 0;

            while (player1Sets < 2 && player2Sets < 2)
            {
                var set = _setFactory.Create();
                set.Start();

                if (set.Player1Games > set.Player2Games)
                    player1Sets++;
                else
                    player2Sets++;

                Console.WriteLine($"Sets: {player1Sets} - {player2Sets}");
                Console.WriteLine(player1Sets == 2 ? "Player 1 wins!" : "Player 2 wins!");

                sets.Add(set);
            }

            Console.WriteLine();
            Console.WriteLine("End Match");
            Console.WriteLine();
            Console.WriteLine("Match Score:");

            return sets;
        }
    }
}