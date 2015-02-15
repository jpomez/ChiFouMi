using System.Text;

namespace ChiFouMi
{
    public class RulesEngine
    {
        public string Run(bool godMode, Move userMove, Move iaMove)
        {
            var stringBuilder = new StringBuilder();

            bool? win = null;

            if (godMode)
            {
                stringBuilder.AppendLine(string.Format("Tu es un roxor contre {0}", iaMove));
                win = true;
            }
            else
            {
                stringBuilder.AppendLine(
                   string.Format(
                       "{0} contre {1}!",
                       userMove,
                       iaMove));

                if (userMove == Move.Pierre && iaMove == Move.Feuille) win = false;
                else if (userMove == Move.Pierre && iaMove == Move.Ciseaux) win = true;
                else if (userMove == Move.Feuille && iaMove == Move.Pierre) win = true;
                else if (userMove == Move.Feuille && iaMove == Move.Ciseaux) win = false;
                else if (userMove == Move.Ciseaux && iaMove == Move.Pierre) win = false;
                else if (userMove == Move.Ciseaux && iaMove == Move.Feuille) win = true;
            }

            stringBuilder.AppendLine(win.HasValue ? win.Value ? "Gagne!" : "Perdu!" : "Egalite!");

            return stringBuilder.ToString();
        }
    }
}