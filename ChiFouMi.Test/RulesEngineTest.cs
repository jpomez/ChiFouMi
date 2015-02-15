using System;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class RulesEngineTest
    {
        [Fact]
        public void WhenRoxorAgainstTheWorldThenRoxorWins()
        {
            var engine = new RulesEngine();

            foreach (var command in Commands.Moves)
            {
                foreach (var iaCommand in Commands.Moves)
                {
                    Check.That(engine.Run(true, command, iaCommand)).IsEqualTo(string.Format("Tu es un roxor contre {0}{1}Gagne!{1}", iaCommand, Environment.NewLine));
                }
            }
        }

        [Fact]
        public void WhenPlayerAgainstIaThenGameEndsAsExpected()
        {
            var engine = new RulesEngine();

            foreach (var command in Commands.Moves)
            {
                Check.That(engine.Run(false, command, command)).IsEqualTo(string.Format("{0} contre {0}!{1}Egalite!{1}", command, Environment.NewLine));
            }
        }

        [Fact]
        public void WhenPierreAgainstFeuilleThenLose()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Pierre, Move.Feuille)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Move.Pierre, Move.Feuille, Environment.NewLine));
        }

        [Fact]
        public void WhenPierreAgainstCiseauxThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Pierre, Move.Ciseaux)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Move.Pierre, Move.Ciseaux, Environment.NewLine));
        }

        [Fact]
        public void WhenFeuilleAgainstPierreThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Feuille, Move.Pierre)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Move.Feuille, Move.Pierre, Environment.NewLine));
        }

        [Fact]
        public void WhenFeuilleAgainstCiseauxThenLose()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Feuille, Move.Ciseaux)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Move.Feuille, Move.Ciseaux, Environment.NewLine));
        }

        [Fact]
        public void WhenCiseauxAgainstPierreThenLose()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Ciseaux, Move.Pierre)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Move.Ciseaux, Move.Pierre, Environment.NewLine));
        }

        [Fact]
        public void WhenCiseauxAgainstFeuilleThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Move.Ciseaux, Move.Feuille)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Move.Ciseaux, Move.Feuille, Environment.NewLine));
        }
    }
}
