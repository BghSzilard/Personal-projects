using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainGamePage.xaml
    /// </summary>
    public partial class MainGamePage : Page
    {
        private User user;
        private const int defaultColumns = 5;
        private const int defaultRows = 4;
        private int customColumns;
        private int customRows;
        private NewGamePage newGamePage;
        public MainGamePage(User user)
        {
            InitializeComponent();
            this.user = user;
            Label label = (Label)FindName("username");
            label.Content = user.username;
            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, user.imageName);
            if (File.Exists(imagePath))
            {
                profilePicture.Source = new BitmapImage(new Uri(imagePath));
            }
            else
            {
                profilePicture.Source = null;
            }
        }
        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            if (newGamePage != null)
            {
                user.gamesPlayed++;
                Dictionary<string, User> users = FileManager.ReadUsersFromFile("users.txt");
                users[user.username] = user;
                FileManager.WriteUsers("users.txt", users);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
        private void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            int columns, rows;
            if (standardMenuItem.IsChecked)
            {
                columns = defaultColumns;
                rows = defaultRows;
            }else
            {
                columns = customColumns;
                rows = customRows;
            }
            newGamePage = new NewGamePage(user, rows, columns);
            Frame frame = (Frame)FindName("frame");
            frame.Content = newGamePage;
        }
        private void OnLoadGameClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Game game = FileManager.ReadGame(user);
                newGamePage = new NewGamePage(user, game);
                Frame frame = (Frame)FindName("frame");
                frame.Content = newGamePage;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The hasn't saved any games yet");
            }
        }
        private void OnStatisticsClicked(object sender, RoutedEventArgs e)
        {
            StatisticsPage statisticsPage = new StatisticsPage(user);
            Frame frame = (Frame)FindName("frame");
            frame.Content = statisticsPage;
        }

        private void OnAboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Student Name: Balogh Szilard\nGroup Number: 10LF211\nSpecialization: Informatics");
        }

        private void OnStandardOptionClicked(object sender, RoutedEventArgs e)
        {
            customMenuItem.IsChecked = false;
            standardMenuItem.IsChecked = true;
        }

        private void OnCustomOptionClicked(object sender, RoutedEventArgs e)
        {
            CustomGameDialogBox customGameDialogBox= new CustomGameDialogBox();
            customGameDialogBox.ShowDialog();
            if ((bool)customGameDialogBox.DialogResult)
            {
                customMenuItem.IsChecked = true;
                standardMenuItem.IsChecked = false;
                customColumns = customGameDialogBox.Columns;
                customRows= customGameDialogBox.Rows;
            }else
            {
                customMenuItem.IsChecked = false;
            }
        }

        private void OnSaveGameClicked(object sender, RoutedEventArgs e)
        {
            if (newGamePage != null)
            {
                newGamePage.SaveGameToFile();
            }else
            {
                MessageBox.Show("There is no game to save");
            }
        }
    }
}
