using System;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class RulesEngineTest
    {
        private readonly RulesEngine engine;

        public RulesEngineTest()
        {
            this.engine = new RulesEngine();
        }

        [Fact]
        public void WhenRoxorAgainstTheWorldThenRoxorWins()
        {
            foreach (var command in Commands.Signs)
            {
                foreach (var iaCommand in Commands.Signs)
                {
                    Check.That(this.engine.Run(true, command, iaCommand)).IsEqualTo(string.Format("Tu es un roxor contre {0}{1}Gagne!{1}", iaCommand, Environment.NewLine));
                }
            }
        }

        [Fact]
        public void WhenSameSignThenEquality()
        {
            foreach (var command in Commands.Signs)
            {
                Check.That(this.engine.Run(false, command, command)).IsEqualTo(string.Format("{0} contre {0}!{1}Egalite!{1}", command, Environment.NewLine));
            }
        }

        [Fact]
        public void PaperCoversRock()
        {
            this.CheckRule(Sign.Feuille, Sign.Pierre);
        }

        [Fact]
        public void ScissorsCutPaper()
        {
            this.CheckRule(Sign.Ciseaux, Sign.Feuille);
        }

        [Fact]
        public void RockCrushesScissors()
        {
            this.CheckRule(Sign.Pierre, Sign.Ciseaux);
        }

        [Fact]
        public void SpockSmashesScissors()
        {
            this.CheckRule(Sign.Spock, Sign.Ciseaux);
        }

        [Fact]
        public void LizardPoisonsSpock()
        {
            this.CheckRule(Sign.Lezard, Sign.Spock);
        }

        [Fact]
        public void SpockVaporizesRock()
        {
            this.CheckRule(Sign.Spock, Sign.Pierre);
        }

        [Fact]
        public void LizardEatsPaper()
        {
            this.CheckRule(Sign.Lezard, Sign.Feuille);
        }

        [Fact]
        public void ScissorsDecapitatesLizard()
        {
            this.CheckRule(Sign.Ciseaux, Sign.Lezard);
        }

        [Fact]
        public void PaperDisprovesSpock()
        {
            this.CheckRule(Sign.Feuille, Sign.Spock);
        }

        [Fact]
        public void RockCrushesLizard()
        {
            this.CheckRule(Sign.Pierre, Sign.Lezard);
        }

        private void CheckRule(Sign strongSign, Sign weakSign)
        {
            Check.That(this.engine.Run(false, strongSign, weakSign))
                .IsEqualTo(string.Format("{0} contre {1}!{2}Gagne!{2}", strongSign, weakSign, Environment.NewLine));

            Check.That(this.engine.Run(false, weakSign, strongSign))
                .IsEqualTo(string.Format("{0} contre {1}!{2}Perdu!{2}", weakSign, strongSign, Environment.NewLine));
        }
    }
}
