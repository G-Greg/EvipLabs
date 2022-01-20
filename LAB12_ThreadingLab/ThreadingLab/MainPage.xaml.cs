using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ThreadingLab
{
    public sealed partial class MainPage : Page
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Blocker_Click(object sender, RoutedEventArgs e)
        {
            Task.Delay(3000).Wait();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            EventList.Items.Add("Start clicked");
            var progressReporter = new Progress<int>(percent => this.ProgressBar.Value = percent);
            var progressReporter2 = new Progress<int>(percent => this.ProgressBar2.Value = percent);
            var slowBackgroundProcessor = new SlowBackgroundProcessor(this.EventList);
            var slowBackgroundProcessor2 = new SlowBackgroundProcessor(null);

            slowBackgroundProcessor.DoItAsync(progressReporter, cts.Token).ContinueWith(async task => 
            {
                await slowBackgroundProcessor2.DoItAsync(progressReporter2);
                cts.Dispose();
            });
            EventList.Items.Add("Start finished");
        }

        class SlowBackgroundProcessor
        {
            private ListBox eventList;

            public SlowBackgroundProcessor(ListBox eventList)
            {
                this.eventList = eventList;
            }

            public async Task DoItAsync(IProgress<int> progress, CancellationToken token = default(CancellationToken))
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    await Task.Delay(500);
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    progress.Report(i);
                    if (eventList != null)
                        eventList.Items.Add("BackgroundProcessor: " + i + "%");
                }
            }
        }
    }
}
