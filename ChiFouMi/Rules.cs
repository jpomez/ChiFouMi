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
                                                 new List<Sign> { Sign.Feuille }
                                             }, 
                                             {
                                                 Sign.Feuille, 
                                                 new List<Sign> { Sign.Ciseaux }
                                             }, 
                                             {
                                                 Sign.Ciseaux, 
                                                 new List<Sign> { Sign.Pierre }
                                             }
                                         };
        }

        public string Run(bool godMode, Sign userSign, Sign iaSign)
        {
            var stringBuilder = new StringBuilder();

            bool? win = null;

            if (godMode)
            {
                stringBuilder.AppendLine(string.Format("Tu es un roxor contre {0}", iaSign));
                win = true;
            }
            else
            {
                stringBuilder.AppendLine(string.Format("{0} contre {1}!", userSign, iaSign));

                if (userSign != iaSign)
                {
                    win = !this.nemesisDictionary[userSign].Contains(iaSign);
                }
            }

            stringBuilder.AppendLine(win.HasValue ? win.Value ? Resource.Gagne : Resource.Perdu : Resource.Egalite);

            return stringBuilder.ToString();
        }
    }
}