using System;
using System.IO;

using ChiFouMi.Test.Tools;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class ChiFouMiTest
    {
        private readonly Func<bool, Move, Move, string> run;

        public ChiFouMiTest()
        {
            this.run = new RulesEngine().Run;
        }

        [Fact]
        public void WhenOnlyExitIsEnteredThenRulesAreCorrectlyDisplayed()
        {
            using (var input = new CustomStringReader(new[] { Commands.Exit }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Run(new[] { string.Empty });
                    Check.That(output.ToString()).IsEqualTo(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
");
                }
            }
        }

        [Fact]
        public void WhenOnlyEnterIsPressedInRoxorModeThenRulesAreCorrectlyDisplayed()
        {
            using (var input = new CustomStringReader(new[] { Commands.Exit }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Run(new[] { "roxor" });
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
                                                               Commands.Enter, 
                                                               "1",
                                                               Commands.Enter, 
                                                               "2",
                                                               Commands.Enter, 
                                                               "3",
                                                               Commands.Exit
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Run(new[] { string.Empty });

                    var expectedOutputPart1 = @"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
";

                    var expectedOutputPart2 = @"Pierre contre";
                    var expectedOutputPart3 = @"Feuille contre";
                    var expectedOutputPart4 = @"Ciseaux contre";

                    var expectedInput = @"
1

2

3
exit
";

                    Check.That(input.ToString()).IsEqualTo(expectedInput);
                    Check.That(output.ToString()).Contains(expectedOutputPart1);
                    Check.That(output.ToString()).Contains(expectedOutputPart2);
                    Check.That(output.ToString()).Contains(expectedOutputPart3);
                    Check.That(output.ToString()).Contains(expectedOutputPart4);
                }
            }
        }

        [Fact]
        public void WhenAllCommandsAreEnteredInRoxorModeThenProgramOutputsAsExpected()
        {
            using (var input = new CustomStringReader(new[]
                                                           {
                                                               Commands.Enter, 
                                                               "1",
                                                               Commands.Enter, 
                                                               "2",
                                                               Commands.Enter, 
                                                               "3",
                                                               Commands.Exit
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Run(new[] { "roxor" });

                    var expectedOutputPart1 = @"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
";

                    var expectedOutputPart2 = @"Tu es un roxor contre";

                    var expectedInput = @"
1

2

3
exit
";

                    Check.That(input.ToString()).IsEqualTo(expectedInput);
                    Check.That(output.ToString()).Contains(expectedOutputPart1);
                    Check.That(output.ToString()).Contains(expectedOutputPart2);
                }
            }
        }

        [Fact]
        public void WhenIncorrectMoveIsEnteredThenProgramOuputsAsExpected()
        {
            using (var input = new CustomStringReader(new[] { Commands.Enter, "7", Commands.Exit }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine, this.run);
                    game.Run(new[] { string.Empty });
                    Check.That(output.ToString()).IsEqualTo(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
Je sais pas
");
                }
            }
        }
    }
}