using System.ComponentModel;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace zh2
{
    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool colorChangeEnable;

        public bool ColorChangeEnable
        {
            get => colorChangeEnable;
            set
            {
                if (colorChangeEnable != value)
                {
                    colorChangeEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorChangeEnable)));
                }
            }
        }

        private SolidColorBrush fillBrush = new SolidColorBrush(Colors.Yellow);

        public SolidColorBrush FillBrush
        {
            get => fillBrush;
            set
            {
                if (fillBrush != value)
                {
                    fillBrush = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FillBrush)));
                }
            }
        }
    }
}
