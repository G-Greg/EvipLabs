using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uwp_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int counter = 1;
        private SolidColorBrush def = new SolidColorBrush(Windows.UI.Colors.White);
        private SolidColorBrush kek = new SolidColorBrush(Windows.UI.Colors.AliceBlue);
        private SolidColorBrush piros = new SolidColorBrush(Windows.UI.Colors.Firebrick);

        private List<List<Button>> buttons = new List<List<Button>>();
        public MainPage()
        {
            this.InitializeComponent();
            
            for (int i = 1; i < 4; i++)
            {
                List<Button> oszlopok = new List<Button>();
                for (int j = 1; j < 4; j++)
                {
                    Button newButton = new Button();
                    newButton.Background = kek;
                    newButton.Click += matrix_Click;
                    newButton.Width = 40;
                    newButton.Name = i.ToString()+"_"+j.ToString();
                    newButton.Content = " ";
                    if (i == 1 && j > 1)
                    {
                        RelativePanel.SetRightOf(newButton, oszlopok[j-2]);
                    }
                    else if (i != 1 && j == 1) {
                        RelativePanel.SetBelow(newButton, buttons[i-2][0]);
                    }
                    else if (i != 1 && j > 1)
                    {
                        RelativePanel.SetRightOf(newButton, oszlopok[j - 2]);
                        RelativePanel.SetBelow(newButton, buttons[i-2][j-1]);
                    }
                    relative.Children.Add(newButton);
                    oszlopok.Add(newButton);
                }
                buttons.Add(oszlopok);
            }
        }

        private void matrix_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string pos = btn.Name.ToString();
            int x = int.Parse(pos[2].ToString());
            int y = int.Parse(pos[0].ToString());
            try
            {
                //önmagát színezze
                setColor(buttons[y - 1][x - 1]);

                //szomszédjait /-1, +1
                if (y-2 > -1)
                    setColor(buttons[y - 2][x - 1]);
                if (y < 3)
                    setColor(buttons[y][x - 1]);
                if (x - 2 > -1)
                    setColor(buttons[y - 1][x - 2]);
                if (x < 3)
                    setColor(buttons[y - 1][x]);

            }
            catch (Exception er)
            {
                Debug.WriteLine(er);
            }

            if (isAllColored())
                new Windows.UI.Popups.MessageDialog("You won!").ShowAsync();
        }

        private void setColor(Button gomb)
        {
            if (gomb.Background.Equals(piros))
                gomb.Background = kek;
            else
                gomb.Background = piros;
        }

        private bool isAllColored()
        {
            foreach (var sorok in buttons)
            {
                foreach (var box in sorok)
                {
                    if (!box.Background.Equals(piros))
                        return false;
                } 
            }
            return true;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            btn1.Background = kek;
            btn1.Foreground = piros;

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (ablak.Background.Equals(kek))
            {
                ablak.Background = piros;
            }
            else 
            {
                ablak.Background = kek;
            }
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                r1.Fill = piros;
                r2.Fill = def;
                r3.Fill = def;
                counter++;
            }
            else if (counter == 2)
            {
                r1.Fill = def;
                r2.Fill = piros;
                r3.Fill = def;
                counter++;
            }
            else if (counter == 3)
            {
                r1.Fill = def;
                r2.Fill = def;
                r3.Fill = piros;
                counter = 1;
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input1 = tbox1.Text.ToString();
                int szam1 = int.Parse(input1);

                string input2 = tbox2.Text.ToString();
                int szam2 = int.Parse(input2);

                tblock1.Text = (szam1 + szam2).ToString();
            }
            catch (Exception er)
            {
                Debug.WriteLine(er);
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            tbox1.IsEnabled = false;
            tbox2.IsEnabled = false;
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            tbox3.Text = slider1.Value.ToString();
        }

        private void tbox3_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            try
            {
                slider1.Value = double.Parse(tbox3.Text);

            }
            catch (Exception er)
            {
                Debug.WriteLine(er);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = new Button();
            newButton.Click += delete_Click;
            newButton.Content = "delete_me";
            panel.Children.Add(newButton);

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Remove(panel.Children[1]);
        }
    }
}
