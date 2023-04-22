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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewGamePage.xaml
    /// </summary>
    public partial class NewGamePage : Page
    {
        //private static string reverseCardPath = System.IO.Path.Combine(Environment.CurrentDirectory, "reverseCard.jpg");
        //private static BitmapImage reverseCard = ResizeImage(new BitmapImage(new Uri(reverseCardPath)));
        private static BitmapImage reverseCard = ResizeImage(new BitmapImage(new Uri("reverseCard.jpg", UriKind.RelativeOrAbsolute)));
        private User user;
        private Dictionary<Button, ImageSource> originalImages = new Dictionary<Button, ImageSource>();
        private int numCardsFaceUp = 0;
        private Button firstCardButton;
        private Button secondCardButton;
        private const int NumGames = 3;
        private int currentGame = 1;
        private List<ImageSource> images = new List<ImageSource>();
        private List<Button> buttons = new List<Button>();
        private List<Button> matchedButtons = new List<Button>();
        private int numButtonsPerRow;
        private int numButtonsPerColumn;
        private Game game;

        public NewGamePage(User user, Game game)
        {
            InitializeComponent();
            this.user = user;
            this.game = game;
            numButtonsPerRow = game.rows;
            numButtonsPerColumn = game.cols;
            currentGame = game.level;
            addButtons();
            StartNewGame(true);
            SizeChanged += (sender, e) =>
            {
                ResizeButtons();
            };
        }
        public NewGamePage(User user, int numButtonsPerRow, int numButtonsPerColumn)
        {
            InitializeComponent();
            this.user = user;
            this.numButtonsPerColumn = numButtonsPerColumn;
            this.numButtonsPerRow = numButtonsPerRow;
            addButtons();
            StartNewGame(false);
            //Adjust button sizes and margins when the window size changes
            SizeChanged += (sender, e) =>
            {
                ResizeButtons();
            };
        }

        void addButtons()
        {
            Grid grid = (Grid)FindName("grid");
            // Calculate the width and height of each button
            double buttonWidth = Math.Floor((grid.ActualWidth - (numButtonsPerRow + 1) * 10) / numButtonsPerRow);
            double buttonHeight = Math.Floor((grid.ActualHeight - (numButtonsPerColumn + 1) * 10) / numButtonsPerColumn);

            if (buttonWidth <= 0)
            {
                buttonWidth = 50;
            }
            if (buttonHeight <= 0)
            {
                buttonHeight = 50;
            }
            // Create buttons with specified number of rows and columns
            for (int row = 0; row < numButtonsPerRow; row++)
            {
                for (int col = 0; col < numButtonsPerColumn; col++)
                {
                    Button button = new Button();
                    button.Name = "Image" + (buttons.Count + 1);
                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Top;
                    button.Width = buttonWidth;
                    button.Height = buttonHeight;
                    double horizontalMargin = col * (button.Width + 10) + 10;
                    double verticalMargin = row * (button.Height + 10) + 10;

                    button.Margin = new Thickness(horizontalMargin, verticalMargin, 0, 0);
                    button.Click += OnImageClicked;
                    buttons.Add(button);
                    grid.Children.Add(button);
                }
            }
        }
       
        
        private void ResizeButtons()
        {
            double buttonWidth = Math.Floor((grid.ActualWidth - (numButtonsPerColumn + 1) * 10) / numButtonsPerColumn);
            double buttonHeight = Math.Floor((grid.ActualHeight - (numButtonsPerRow + 1) * 10) / numButtonsPerRow);

            for (int i = 0; i < buttons.Count; i++)
            {
                int row = i / numButtonsPerColumn;
                int col = i % numButtonsPerColumn;
                double horizontalMargin = col * (buttonWidth + 10) + 10;
                double verticalMargin = row * (buttonHeight + 10) + 20;

                buttons[i].Width = buttonWidth;
                buttons[i].Height = buttonHeight;
                buttons[i].Margin = new Thickness(horizontalMargin, verticalMargin, 0, 0);
            }
        }

       
        private List<ImageSource> ShuffleImages(List<ImageSource> images)
        {
            Random rand = new Random();
            // Shuffle the image list using Fisher-Yates shuffle algorithm
            for (int i = images.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                ImageSource temp = images[j];
                images[j] = images[i];
                images[i] = temp;
            }
            return images;
        }
        private ImageSource FindImageByName(string name)
        {
            return images.Find(x => x.ToString() == name);
        }

        private void AssignImagesToButtons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (game.isFlipped[i] == true)
                {
                    buttons[i].Content = new Image() { Source = FindImageByName(game.cards[i]) };
                    matchedButtons.Add(buttons[i]);
                }
                else
                {
                    buttons[i].Content = new Image() { Source = reverseCard };
                }
                originalImages[buttons[i]] = FindImageByName(game.cards[i]);
            }
        }
        private void AssignRandomImagesToButtons()
        {
            Random rand = new Random();
            // Put the buttons into a set
            HashSet<Button> buttonSet = new HashSet<Button>(buttons);

            // Loop until there are no more buttons in the set
            while (buttonSet.Count > 0)
            {
                // Select two random buttons from the set
                List<Button> selectedButtons = buttonSet.OrderBy(x => rand.Next()).Take(2).ToList();

                // Select a random image
                int j = rand.Next(images.Count);
                ImageSource selectedImage = images[j];

                // Assign the image to the selected buttons
                foreach (Button button in selectedButtons)
                {
                    button.Content = new Image() { Source = reverseCard };

                    originalImages[button] = selectedImage;
                    buttonSet.Remove(button);
                }

                // Remove the selected image from the list of available images
                images.RemoveAt(j);
            }
        }

      
        public void StartNewGame(bool loadedGame)
        {
            // Reset game state
            matchedButtons.Clear();
            numCardsFaceUp = 0;
            firstCardButton = null;
            secondCardButton = null;
            originalImages.Clear();
            string temp = (string)level.Content;
            temp = temp.Substring(0, temp.Length - 1);
            level.Content = temp;
            level.Content += currentGame.ToString();
            buttons.Clear();
            Grid grid = (Grid)FindName("grid");
            images.Clear();
            images.Add(ResizeImage(new BitmapImage(new Uri("card1.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card2.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card3.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card4.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card5.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card6.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card7.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card8.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card9.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card10.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card11.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card12.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card13.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card14.jpg", UriKind.RelativeOrAbsolute))));
            images.Add(ResizeImage(new BitmapImage(new Uri("card15.jpg", UriKind.RelativeOrAbsolute))));
            foreach (UIElement child in grid.Children)
            {
                if (child is Button button)
                {
                    button.IsEnabled = true;
                    button.Content = new Image() { Source = reverseCard };
                    originalImages.Add(button, null);
                    buttons.Add(button);
                }
            }
            // Shuffle the images
            images = ShuffleImages(images);
            if (loadedGame)
            {
                AssignImagesToButtons();
            }
            else
            {
                AssignRandomImagesToButtons();
            }
        }
        private void OnImageClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Image img = button.Content as Image;
            if (img != null && img.Source == reverseCard && numCardsFaceUp < 2)
            {
                img.Source = originalImages[button];
                numCardsFaceUp++;
                if (numCardsFaceUp == 1)
                {
                    firstCardButton = button;
                }
                else if (numCardsFaceUp == 2)
                {
                    secondCardButton = button;
                    if (originalImages[firstCardButton] != originalImages[secondCardButton])
                    {
                        DisableButtons();
                        StartTimer();
                    }
                    else
                    {
                        matchedButtons.Add(firstCardButton);
                        matchedButtons.Add(secondCardButton);
                        if (matchedButtons.Count == originalImages.Count)
                        {
                            if (currentGame < NumGames)
                            {
                                MessageBox.Show("Congratulations, you have completed level " + currentGame);
                                currentGame++;
                                StartNewGame(false);
                            }
                            else
                            {
                                MessageBox.Show("Congratulations, you have won");
                                user.gamesPlayed++;
                                user.gamesWon++;
                                Dictionary<string, User> users = FileManager.ReadUsersFromFile("users.txt");
                                users[user.username] = user;
                                FileManager.WriteUsers("users.txt", users);
                                Window parentWindow = Window.GetWindow(this);
                                MainGamePage mainGamePage = new MainGamePage(user);
                                parentWindow.Content = mainGamePage;
                            }
                        }
                        numCardsFaceUp = 0;
                    }
                }
            }
        }

        private void DisableButtons()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            List<Button> remainingButtons = new List<Button>();
            foreach (var child in grid.Children)
            {
                if (child is Button b && !matchedButtons.Contains(b))
                {
                    b.IsEnabled = false;
                    remainingButtons.Add(b);
                }
            }
            timer.Tick += (s, args) =>
            {
                firstCardButton.Content = new Image() { Source = reverseCard };
                secondCardButton.Content = new Image() { Source = reverseCard };
                numCardsFaceUp = 0;
                timer.Stop();
                foreach (var b in remainingButtons)
                {
                    b.IsEnabled = true;
                }
            };
            timer.Start();
        }

        private void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, args) =>
            {
                firstCardButton.Content = new Image() { Source = reverseCard };
                secondCardButton.Content = new Image() { Source = reverseCard };
                numCardsFaceUp = 0;
                timer.Stop();
            };
            timer.Start();
        }


        private static BitmapImage ResizeImage(BitmapImage originalImage)
        {
            double scaleX = 100.0 / originalImage.PixelWidth;
            double scaleY = 100.0 / originalImage.PixelHeight;

            var resizedImage = new TransformedBitmap(originalImage, new ScaleTransform(scaleX, scaleY));

            BitmapImage bitmapImage = null;

            using (var memoryStream = new MemoryStream())
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(resizedImage));
                encoder.Save(memoryStream);
                memoryStream.Position = 0;

                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.UriSource = originalImage.UriSource;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }
        public void SaveGameToFile()
        {
            string filePath = user.username + ".txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the number of buttons per row and column
                writer.WriteLine(numButtonsPerRow);
                writer.WriteLine(numButtonsPerColumn);

                // Write the current game number
                writer.WriteLine(currentGame);
                for (int i = 0; i < numButtonsPerRow; ++i)
                {
                    for (int j = 0; j < numButtonsPerColumn; ++j)
                    {
                        writer.Write(((BitmapImage)originalImages[buttons[i * numButtonsPerColumn + j]]).UriSource.ToString() + ",");
                    }
                }
                writer.WriteLine();
                for (int i = 0; i < numButtonsPerRow; ++i)
                {
                    for (int j = 0; j < numButtonsPerColumn; ++j)
                    {
                        if (((BitmapImage)((Image)buttons[i * numButtonsPerColumn + j].Content).Source).UriSource.ToString() == "reverseCard.jpg")
                        {
                            writer.Write("0");
                        }
                        else
                        {
                            writer.Write("1");
                        }
                        writer.Write(",");
                    }
                }
            }
        }
    }
}
