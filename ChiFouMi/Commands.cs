using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    public static class Commands
    {
        static Commands()
        {
            Moves = Enum.GetValues(typeof(Move)).OfType<Move>().ToList();
        }

        public static IEnumerable<Move> Moves { get; private set; }

        public static string EnterCommand
        {
            get
            {
                return Resource.EnterCommand;
            }
        }

        public static string ExitCommand
        {
            get
            {
                return Resource.ExitCommand;
            }
        }
    }
}
