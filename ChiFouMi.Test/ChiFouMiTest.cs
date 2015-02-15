using System.IO;

using ChiFouMi.Test.Tools;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class ChiFouMiTest
    {
        [Fact]
        public void WhenOnlyExitIsEnteredThenRulesAreCorrectlyDisplayed()
        {
            using (var input = new CustomStringReader(new[] { Commands.ExitCommand }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine);
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
            using (var input = new CustomStringReader(new[] { Commands.ExitCommand }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine);
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
                                                               Commands.EnterCommand, 
                                                               "1",
                                                               Commands.EnterCommand, 
                                                               "2",
                                                               Commands.EnterCommand, 
                                                               "3",
                                                               Commands.ExitCommand
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine);
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
                                                               Commands.EnterCommand, 
                                                               "1",
                                                               Commands.EnterCommand, 
                                                               "2",
                                                               Commands.EnterCommand, 
                                                               "3",
                                                               "exit"
                                                           }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine);
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
            using (var input = new CustomStringReader(new[] { Commands.EnterCommand, "7", Commands.ExitCommand }))
            {
                using (var output = new StringWriter())
                {
                    var game = new ChiFouMi(input.ReadLine, output.WriteLine);
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