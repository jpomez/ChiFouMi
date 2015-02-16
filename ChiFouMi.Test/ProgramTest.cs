using System;
using System.IO;

using ChiFouMi.Test.Tools;

using NFluent;

using Xunit;

namespace ChiFouMi.Test
{
    public class ProgramTest
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
                                                               Commands.Enter,
                                                               "4",
                                                               Commands.Enter,
                                                               "5",
                                                               Commands.Exit
                                                           }))
                {
                    Console.SetIn(sr);

                    Program.Main(new[] { string.Empty });

                    Check.That(sr.ToString()).IsEqualTo(@"
1

2

3

4

5
exit
");
                    Check.That(sw.ToString()).Contains(@"Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!
Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.
Veuillez choisir un signe:
1- Pierre
2- Feuille
3- Ciseaux
4- Lezard
5- Spock
");
                    Check.That(sw.ToString()).Contains("Pierre contre");
                    Check.That(sw.ToString()).Contains("Feuille contre");
                    Check.That(sw.ToString()).Contains("Ciseaux contre");
                    Check.That(sw.ToString()).Contains("Lezard contre");
                    Check.That(sw.ToString()).Contains("Spock contre");
                }
            }

            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }
    }
}
