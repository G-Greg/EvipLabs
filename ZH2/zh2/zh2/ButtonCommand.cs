using System;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace zh2
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            DataModel dm = (DataModel)parameter;

            if (dm.ColorChangeEnable)
                dm.FillBrush = new SolidColorBrush(Colors.Green);
            else
                dm.FillBrush = new SolidColorBrush(Colors.Yellow);
        }
    }
}
