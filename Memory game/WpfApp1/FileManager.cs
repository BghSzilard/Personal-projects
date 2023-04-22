using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WpfApp1;

public static class FileManager
{
    public static Dictionary<string, User> ReadUsersFromFile(string filePath)
    {
        Dictionary<string, User> users = new Dictionary<string, User>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                // Parse the user information and add it to the dictionary
                string[] userInfo = line.Split(',');
                string username = userInfo[0];
                string password = userInfo[1];
                int gamesPlayed = Convert.ToInt32(userInfo[2]);
                int gamesWon = Convert.ToInt32(userInfo[3]);
                string imageName = userInfo[4];
                User newUser = new User(username, password, gamesPlayed, gamesWon, imageName);
                users.Add(username, newUser);
            }
        }

        return users;
    }

    public static void WriteUsers(string filePath, Dictionary<string, User> users)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (User user in users.Values)
            {
                string line = $"{user.username},{user.password},{user.gamesPlayed},{user.gamesWon},{user.imageName}";
                writer.WriteLine(line);
            }
        }
    }

    public static void deleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }else
        {
            MessageBox.Show("File does not exist");
        }
    }
    public static Game ReadGame(User user)
    {
        Game game = new Game();
        string fileName = user.username + ".txt";
        using (StreamReader reader = new StreamReader(fileName))
        {
            int numRows = int.Parse(reader.ReadLine());
            int numCols = int.Parse(reader.ReadLine());
            int level = int.Parse(reader.ReadLine());
            string[] cards = reader.ReadLine().Split(',');
            List<string> cardsList = new List<string>();
            cardsList.AddRange(cards);
            cardsList.RemoveAt(cardsList.Count - 1);
            List<bool> boolList = new List<bool>();
            string[] bools = reader.ReadLine().Split(',');
            for (int i = 0; i < bools.Length - 1; ++i)
            {
                boolList.Add(Convert.ToBoolean(int.Parse(bools[i])));
            }
            game.rows = numRows; 
            game.cols = numCols;
            game.cards = cardsList;
            game.level = level;
            game.isFlipped = boolList;
        }
        return game;
    }
}
