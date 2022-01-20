using System;
using System.Windows.Input;

namespace minta_zh2_2021
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            new Windows.UI.Popups.MessageDialog($"Slider értéke: {parameter}").ShowAsync();
        }
    }
}
