using System;
using System.IO;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class ChiFouMiTest
    {
        private readonly Func<bool, Sign, Sign, string> run;

        public ChiFouMiTest()
        {
            this.run = new RulesEngine().Run;
        }

        [Fact]
        public void WhenOnlyExitIsEnteredThenRulesAreCorrectlyDisplayed()
        {
            using (var input = new CustomStringReader(new[] { "exit" }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Play(new[] { string.Empty });
                    Check.That(output.ToString()).IsEqualTo(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
");
                }
            }
        }

        [Fact]
        public void WhenOnlyEnterIsPressedInRoxorModeThenRulesAreCorrectlyDisplayed()
        {
            using (var input = new CustomStringReader(new[] { "exit" }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Play(new[] { "roxor" });
                    Check.That(output.ToString()).IsEqualTo(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
");
                }
            }
        }

        [Fact]
        public void WhenAllCommandsAreEnteredThenProgramOutputsAsExpected()
        {
            using (var input  = new CustomStringReader(new[]
                                                           {
                                                               string.Empty, 
                                                               "1",
                                                               string.Empty, 
                                                               "2",
                                                               string.Empty, 
                                                               "3",
                                                               string.Empty, 
                                                               "4",
                                                               string.Empty, 
                                                               "5",
                                                               "exit"
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Play(new[] { string.Empty });

                    Check.That(input.ToString()).IsEqualTo(@"
1

2

3

4

5
exit
");
                    Check.That(output.ToString()).Contains(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
4- Lezard
5- Spock
");
                    Check.That(output.ToString()).Contains("Pierre contre");
                    Check.That(output.ToString()).Contains("Feuille contre");
                    Check.That(output.ToString()).Contains("Ciseaux contre");
                    Check.That(output.ToString()).Contains("Lezard contre");
                    Check.That(output.ToString()).Contains("Spock contre");
                }
            }
        }

        [Fact]
        public void WhenAllCommandsAreEnteredInRoxorModeThenProgramOutputsAsExpected()
        {
            using (var input = new CustomStringReader(new[]
                                                           {
                                                               string.Empty, 
                                                               "1",
                                                               string.Empty, 
                                                               "2",
                                                               string.Empty, 
                                                               "3",
                                                               string.Empty, 
                                                               "4",
                                                               string.Empty, 
                                                               "5",
                                                               "exit"
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Play(new[] { "roxor" });

                    Check.That(input.ToString()).IsEqualTo(@"
1

2

3

4

5
exit
");
                    Check.That(output.ToString()).Contains(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
4- Lezard
5- Spock
");
                    Check.That(output.ToString()).Contains(@"Tu es un roxor contre");
                }
            }
        }

        [Fact]
        public void WhenIncorrectMoveIsEnteredThenProgramOuputsAsExpected()
        {
            using (var input = new CustomStringReader(new[] { string.Empty, "7", "exit" }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Play(new[] { string.Empty });
                    Check.That(output.ToString()).IsEqualTo(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
4- Lezard
5- Spock
");
                }
            }
        }
    }
}