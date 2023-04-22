using System.Runtime.CompilerServices;

public class User
{
    private const string defaultImageName = "default.jpg";
    public string username { get; private set; }
    public string password { get; private set; }
    public int gamesPlayed { get; set; }
    public string imageName { get; private set; }
    public int gamesWon { get; set; }
    public User(string username, string password, int gamesPlayed, int gamesWon, string imageName = defaultImageName)
    {
        this.username = username;
        this.password = password;
        this.gamesPlayed = gamesPlayed;
        this.gamesWon = gamesWon;
        this.imageName = imageName;
    }

    public void addGame(bool victory)
    {
        gamesPlayed++;
        if (victory)
        {
            gamesWon++;
        }
    }
}