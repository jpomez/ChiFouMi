using System.Text;

namespace ChiFouMi
{
    public class RulesEngine
    {
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
                stringBuilder.AppendLine(
                   string.Format(
                       "{0} contre {1}!",
                       userSign,
                       iaSign));

                if (userSign == Sign.Pierre && iaSign == Sign.Feuille) win = false;
                else if (userSign == Sign.Pierre && iaSign == Sign.Ciseaux) win = true;
                else if (userSign == Sign.Feuille && iaSign == Sign.Pierre) win = true;
                else if (userSign == Sign.Feuille && iaSign == Sign.Ciseaux) win = false;
                else if (userSign == Sign.Ciseaux && iaSign == Sign.Pierre) win = false;
                else if (userSign == Sign.Ciseaux && iaSign == Sign.Feuille) win = true;
            }

            stringBuilder.AppendLine(win.HasValue ? win.Value ? Resource.Gagne : Resource.Perdu : Resource.Egalite);

            return stringBuilder.ToString();
        }
    }
}