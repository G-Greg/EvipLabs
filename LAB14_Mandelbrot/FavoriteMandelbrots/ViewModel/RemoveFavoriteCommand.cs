using System;

namespace FavoriteMandelbrots.ViewModel
{

    public class RemoveFavoriteCommand : CommandBase
    {
        public RemoveFavoriteCommand(MainViewerViewModel mainViewerViewModel) : base(mainViewerViewModel)
        {
        }

        public async override void Execute(object parameter)
        {
            AreaViewModel selectedVM = (AreaViewModel)parameter;
            if (selectedVM != null) 
            {
                vm.Favorites.Remove(selectedVM);
            }
            else
            {
                var m = new Windows.UI.Popups.MessageDialog("Select the favorite to update first...");
                await m.ShowAsync();
            }
        }
    }
}
