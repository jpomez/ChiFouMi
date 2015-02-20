using System;
using System.Linq;

namespace ChiFouMi
{
    public class ChiFouMi
    {
        private readonly Random r;

        private readonly Func<string> readLine;

        private readonly Action<string> writeLine;

        private readonly Func<bool, Sign, Sign, string> run;

        public ChiFouMi(Func<string> readLine, Action<string> writeLine, Func<bool, Sign, Sign, string> run)
        {
            this.readLine = readLine;
            this.writeLine = writeLine;

            this.r = new Random(DateTime.Now.Millisecond);

            this.run = run;
        }

        public void Play(string[] args)
        {
            this.writeLine(Resource.WelcomeMessage);

            while (!this.readLine().StartsWith(Resource.Exit))
            {
                this.writeLine(Resource.Intro);

                for (var i = 1; i < 6; i++)
                {
                    this.writeLine(string.Format("{0}- {1}", i, (Sign)i));
                }

                Sign userCommand;
                if (!Enum.TryParse(this.readLine(), out userCommand) || !Enum.IsDefined(typeof(Sign), userCommand))
                {
                    continue;
                }

                this.writeLine(this.run(args.Any() && args[0].Equals(Resource.Roxor), userCommand, (Sign)this.r.Next(1, 6)));
            }
        }
    }
}