using System;
using AttaxxPlus.Model;

namespace AttaxxPlus.Boosters
{
    /// <summary>
    /// Booster not doing anything. (But activating it takes a turn.)
    /// Features a player-independent counter to limit the number of activations.
    /// </summary>
    public class DummyBooster : BoosterBase
    {
        // How many times can the user activate this booster
        private int[] usableCounters = new int[3];

        // EVIP: overriding abstract property in base class.
        public override string Title { get => $"Dummy ({usableCounters[GameViewModel.CurrentPlayer]})"; }

        public DummyBooster()
            : base()
        {
            // EVIP: referencing content resource with Uri.
            //  The image is added to the project as "Content" build action.
            //  See also for embedded resources: https://docs.microsoft.com/en-us/windows/uwp/app-resources/
            // https://docs.microsoft.com/en-us/windows/uwp/app-resources/images-tailored-for-scale-theme-contrast#reference-an-image-or-other-asset-from-xaml-markup-and-code
            LoadImage(new Uri(@"ms-appx:///Boosters/DummyBooster.png"));
        }

        protected override void CurrentPlayerChanged()
        {
            base.CurrentPlayerChanged();
            Notify(nameof(this.Title));
        }

        public override void InitializeGame()
        {
            usableCounters[1] = 2;
            usableCounters[2] = 2;
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            // Note: if you need a player-dependent counter, use this.GameViewModel.CurrentPlayer.
            if (GameViewModel.CurrentPlayer == 1)
            {
                if (usableCounters[1] > 0)
                {
                    usableCounters[1]--;
                    Notify(nameof(Title));
                    return true;
                }
            }
            else if (GameViewModel.CurrentPlayer == 2)
            {
                if (usableCounters[2] > 0)
                {
                    usableCounters[2]--;
                    Notify(nameof(Title));
                    return true;
                }
            }
            return false;
        }
    }
}
