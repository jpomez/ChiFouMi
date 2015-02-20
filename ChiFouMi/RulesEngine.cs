using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChiFouMi
{
    public class RulesEngine
    {
        private readonly IDictionary<Sign, IEnumerable<Sign>> nemesisDictionary;

        public RulesEngine()
        {
            this.nemesisDictionary = new Dictionary<Sign, IEnumerable<Sign>>
                                         {
                                             {
                                                 Sign.Pierre, 
                                                 new List<Sign> { Sign.Feuille, Sign.Spock }
                                             }, 
                                             {
                                                 Sign.Feuille, 
                                                 new List<Sign> { Sign.Ciseaux, Sign.Lezard }
                                             }, 
                                             {
                                                 Sign.Ciseaux, 
                                                 new List<Sign> { Sign.Pierre, Sign.Spock }
                                             },
                                             {
                                                 Sign.Lezard, 
                                                 new List<Sign> { Sign.Pierre, Sign.Ciseaux }
                                             },
                                             {
                                                 Sign.Spock, 
                                                 new List<Sign> { Sign.Feuille, Sign.Lezard }
                                             }
                                         };
        }

        public string Run(bool godMode, Sign userSign, Sign iaSign)
        {
            var stringBuilder = new StringBuilder();

            bool? win;

            if (godMode)
            {
                stringBuilder.AppendLine(string.Format("Tu es un roxor contre {0}", iaSign));
                win = true;
            }
            else
            {
                stringBuilder.AppendLine(string.Format("{0} contre {1}!", userSign, iaSign));
                win = userSign != iaSign ? !this.nemesisDictionary[userSign].Contains(iaSign) : (bool?)null;
            }

            return stringBuilder.AppendLine(win.HasValue ? win.Value ? Resource.Gagne : Resource.Perdu : Resource.Egalite).ToString();
        }
    }
}