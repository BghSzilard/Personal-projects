using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private const string fileName = "users.txt";
        Dictionary<string, User> users = FileManager.ReadUsersFromFile(fileName);

        public MainWindow()
        {
            InitializeComponent();
            lstUsernames.ItemsSource = users.Keys;
        }
        private void OnUserSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUsernames.SelectedItem != null)
            {
                btnRemoveUser.IsEnabled = true;
                btnPlay.IsEnabled = true;
                User selectedUser = users[lstUsernames.SelectedItem.ToString()];

                string imagePath = Path.Combine(Environment.CurrentDirectory, selectedUser.imageName);
                if (File.Exists(imagePath))
                {
                    imgUser.Source = new BitmapImage(new Uri(imagePath));
                }
                else
                {
                    imgUser.Source = null;
                }
            }
            else
            {
                btnRemoveUser.IsEnabled = false;
                imgUser.Source = null;
            }
        }

        private void OnRemoveUserButtonClick(object sender, RoutedEventArgs e)
        {
            if (lstUsernames.SelectedItem != null)
            {
                string selectedUserKey = (string)lstUsernames.SelectedItem;

                var passwordDialog = new PasswordDialog();
                if (!passwordDialog.ShowDialog($"Please enter the password for '{selectedUserKey}'"))
                {
                    return;
                }

                if (users[selectedUserKey].password == passwordDialog.Password)
                {
                    FileManager.deleteFile(users[selectedUserKey].username + ".txt");
                    users.Remove(selectedUserKey);

                    // Create a new ObservableCollection<string> from the updated dictionary keys
                    var newUsersList = new ObservableCollection<string>(users.Keys);

                    // Set the new ObservableCollection<string> as the ItemsSource of the ListBox
                    lstUsernames.ItemsSource = newUsersList;

                    MessageBox.Show($"User '{selectedUserKey}' has been deleted.");
                    FileManager.WriteUsers(fileName, users);
                }
                else
                {
                    MessageBox.Show("Incorrect password, could not delete user.");
                }
            }
        }
        private void OnAddUserButtonClick(object sender, RoutedEventArgs e)
        {
            var addUserDialog = new AddUserDialog();
            if (addUserDialog.ShowDialog() == true)
            {
                // Get the values from the dialog
                string username = addUserDialog.Username;
                string password = addUserDialog.Password;
                string image = addUserDialog.ImageName;

                // Check if username or password fields are empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password fields cannot be empty.");
                    return;
                }

                // Check if username is already taken
                if (users.ContainsKey(username))
                {
                    MessageBox.Show("This username is taken.");
                    return;
                }

                // Create a new User object and add it to the dictionary
                User newUser;
                if (image is null)
                {
                    newUser = new User(username, password, 0, 0);
                }
                else
                {
                    newUser = new User(username, password, 0, 0, image);
                }
                users.Add(username, newUser);

                // Update the list of usernames in the ListBox
                var newUsersList = new ObservableCollection<string>(users.Keys);
                lstUsernames.ItemsSource = newUsersList;

                MessageBox.Show($"User '{username}' has been added.");
                FileManager.WriteUsers(fileName, users);
            }
        }
        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            User selectedUser = users[lstUsernames.SelectedItem.ToString()];

            var passwordDialog = new PasswordDialog();
            if (!passwordDialog.ShowDialog($"Please enter the password for '{selectedUser}'"))
            {
                return;
            }

            if (users[selectedUser.username].password == passwordDialog.Password)
            {
                MessageBox.Show($"Welcome, {selectedUser.username}!");
                GameWindow gameWindow = new GameWindow(selectedUser);
                gameWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect password, please try again.");
            }
        }

    }
}
