using System;
using System.Linq;

namespace ChiFouMi
{
    public class ChiFouMi
    {
        private readonly RulesEngine engine;

        private readonly Random r;

        private readonly Func<string> readLine;

        private readonly Action<string> writeLine;

        private bool roxorMod;

        public ChiFouMi(Func<string> readLine, Action<string> writeLine)
        {
            this.readLine = readLine;
            this.writeLine = writeLine;

            this.engine = new RulesEngine();
            this.r = new Random(DateTime.Now.Millisecond);
        }

        public void Run(string[] args)
        {
            if (args.Any())
            {
                if (args[0].Equals(Resource.Roxor))
                {
                    this.roxorMod = true;
                }
            }

            this.writeLine(Resource.WelcomMessage);
            this.writeLine(Resource.Instructions);

            while (!this.readLine().StartsWith(Resource.ExitCommand))
            {
                this.DisplayCommands();

                Move userCommand;
                if (!Enum.TryParse(this.readLine(), out userCommand) || !Enum.IsDefined(typeof(Move), userCommand))
                {
                    this.writeLine("Je sais pas");
                    continue;
                }

                this.writeLine(this.engine.Run(this.roxorMod, userCommand, (Move)this.r.Next(1, 4)));
            }
        }

        private void DisplayCommands()
        {
            this.writeLine(Resource.Intro);

            for (var i = 0; i < Commands.Moves.Count; i++)
            {
                this.writeLine(string.Format("{0}- {1}", i + 1, Commands.Moves[i]));
            }
        }
    }
}