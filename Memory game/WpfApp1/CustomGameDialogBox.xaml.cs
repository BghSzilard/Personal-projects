using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class CustomGameDialogBox : Window
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public CustomGameDialogBox()
        {
            InitializeComponent();
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(rowsTextBox.Text, out int rows) && int.TryParse(columnsTextBox.Text, out int columns))
            {
                if (rows * columns <= 30 && (rows % 2 == 0 || columns % 2 == 0))
                {
                    Rows = rows;
                    Columns = columns;
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("The product of Rows and Columns cannot be greater than 30, and at least one of them has to be an even number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid integers for Rows and Columns.");
            }
        }


        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
