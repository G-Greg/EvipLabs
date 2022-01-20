using System;
using AttaxxPlus.Model;

namespace AttaxxPlus.Boosters
{
    /// <summary>
    /// Booster filling all empty fields with the opponents' color (assuming 2 players).
    /// </summary>
    public class SurrenderBooster : BoosterBase
    {
        // EVIP: compact override of getter for Title returning constant.
        public override string Title => "Surrender";

        public SurrenderBooster() : base()
        {
            LoadImage(new Uri(@"ms-appx:///Boosters/SurrenderBooster.png"));
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            int loser = GameViewModel.Model.CurrentPlayer;
            int winner = loser == 1 ? 2 : 1;
            var fields = GameViewModel.Model.Fields;

            foreach (var field in fields)
            {
                if (field.Owner == 0)
                field.Owner = winner;
            }
            GameViewModel.Model.EndOfTurn();
            return true;
        }
    }
}
