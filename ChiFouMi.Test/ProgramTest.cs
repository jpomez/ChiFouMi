using System;
using System.IO;

using ChiFouMi.Test.Tools;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class ProgramTest : IDisposable
    {
        [Fact]
        public void WhenUserEntersAllPossibleCommandsThenProgramOuputsAsExpected()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (var sr = new CustomStringReader(new[]
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
                    Console.SetIn(sr);

                    Program.Main(new[] { string.Empty });

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
                    Check.That(sr.ToString()).IsEqualTo(expectedInput);
                    Check.That(sw.ToString()).Contains(expectedOutputPart1);
                    Check.That(sw.ToString()).Contains(expectedOutputPart2);
                    Check.That(sw.ToString()).Contains(expectedOutputPart3);
                    Check.That(sw.ToString()).Contains(expectedOutputPart4);
                }
            }

            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        public void Dispose()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }
    }
}
