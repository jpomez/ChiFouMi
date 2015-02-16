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
            Check.That(engine.Run(false, Sign.Pierre, Sign.Feuille)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Sign.Pierre, Sign.Feuille, Environment.NewLine));
        }

        [Fact]
        public void WhenPierreAgainstCiseauxThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Sign.Pierre, Sign.Ciseaux)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Sign.Pierre, Sign.Ciseaux, Environment.NewLine));
        }

        [Fact]
        public void WhenFeuilleAgainstPierreThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Sign.Feuille, Sign.Pierre)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Sign.Feuille, Sign.Pierre, Environment.NewLine));
        }

        [Fact]
        public void WhenFeuilleAgainstCiseauxThenLose()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Sign.Feuille, Sign.Ciseaux)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Sign.Feuille, Sign.Ciseaux, Environment.NewLine));
        }

        [Fact]
        public void WhenCiseauxAgainstPierreThenLose()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Sign.Ciseaux, Sign.Pierre)).IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", Sign.Ciseaux, Sign.Pierre, Environment.NewLine));
        }

        [Fact]
        public void WhenCiseauxAgainstFeuilleThenWin()
        {
            var engine = new RulesEngine();
            Check.That(engine.Run(false, Sign.Ciseaux, Sign.Feuille)).IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", Sign.Ciseaux, Sign.Feuille, Environment.NewLine));
        }
    }
}
