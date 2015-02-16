using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    public static class Commands
    {
        static Commands()
        {
            Moves = Enum.GetValues(typeof(Sign)).OfType<Sign>().ToList();
        }

        public static IList<Sign> Moves { get; private set; }

        public static string Enter
        {
            get
            {
                return Resource.EnterCommand;
            }
        }

        public static string Exit
        {
            get
            {
                return Resource.ExitCommand;
            }
        }
    }
}
