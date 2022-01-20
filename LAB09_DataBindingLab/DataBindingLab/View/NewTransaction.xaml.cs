using DataBindingLab.Model;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataBindingLab.View
{
    public sealed partial class NewTransaction : UserControl, INotifyPropertyChanged
    {
        private TransactionList transactions;

        public event PropertyChangedEventHandler PropertyChanged;

        private int value;
        private string desc;

        public CategoryList Categories { get; set; }

        #region Values entered into the form
        public int SelectedCategoryIndex { get; set; }
        public string Description {
            get => desc;
            set
            {
                if (this.desc != value)
                {
                    this.desc = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
            }
        }
        public int Value { 
            get => value;
            set
            {
                if(this.value != value)
                {
                    this.value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
        #endregion

        public NewTransaction()
        {
            this.InitializeComponent();
        }

        internal void SetModel(ExpenseManager expenseManager)
        {
            this.transactions = expenseManager.Transactions;
            this.Categories = expenseManager.Categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var peldany = new Transaction();
            peldany.Value = this.Value;
            peldany.Description = Description;
            peldany.Category = Categories[SelectedCategoryIndex];
            transactions.Add(peldany);
            Value = 0;
            Description = "";

        }
    }
}
