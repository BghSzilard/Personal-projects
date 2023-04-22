using System.ComponentModel;
using System.Windows;

namespace WpfApp1
{
    public partial class AddUserDialog : Window, INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageName { get; set; }

        public AddUserDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
