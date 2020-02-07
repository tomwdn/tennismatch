using System;

namespace TennisMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var match = new Match(new SetFactory());

            var sets = match.Play();

            for (var i = 0; i < sets.Count; i++)
            {
                var set = sets[i];

                Console.WriteLine($"Set {i + 1}: {set.Player1Games} - {set.Player2Games}");
            }

            Console.ReadLine();
        }
    }
}
