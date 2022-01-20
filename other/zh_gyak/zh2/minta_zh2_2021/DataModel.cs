using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace minta_zh2_2021
{
    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int slidervalue;
        public int SliderValue
        {
            get => slidervalue;
            set
            {
                if (slidervalue != value)
                {
                    slidervalue = value;

                    if (slidervalue > 50)
                        color = piros;
                    else
                        color = new SolidColorBrush(Windows.UI.Colors.Green);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RectangleFill)));
                }
            }
        }

        private SolidColorBrush piros = new SolidColorBrush(Windows.UI.Colors.Red);
        private SolidColorBrush color = new SolidColorBrush(Windows.UI.Colors.Green);

        public SolidColorBrush RectangleFill
        {
            get => color;
            set { }
        }
    }
}
