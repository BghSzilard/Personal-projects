using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private User user;
        private float winPercentage;
        public StatisticsPage(User user)
        {
            InitializeComponent();
            this.user = user;
            winPercentage = (float)user.gamesWon / user.gamesPlayed;
            gamesPlayedTextBlock.Text = user.gamesPlayed.ToString();
            gamesWonTextBlock.Text = user.gamesWon.ToString();
            winPercentageTextBlock.Text = winPercentage.ToString("P");
        }
        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainGamePage mainGamePage = new MainGamePage(user);
            parentWindow.Content = mainGamePage;
        }
    }
}
