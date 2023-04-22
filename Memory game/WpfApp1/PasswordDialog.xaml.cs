using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class PasswordDialog : UserControl
    {
        public PasswordDialog()
        {
            InitializeComponent();
        }

        public bool ShowDialog(string message)
        {
            var window = new Window
            {
                Content = this,
                Title = message,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.ToolWindow,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            bool? result = window.ShowDialog();
            return result.HasValue && result.Value;
        }

        public string Password => txtPassword.Password;

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.DialogResult = true;
            window.Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.DialogResult = false;
            window.Close();
        }
    }
}
