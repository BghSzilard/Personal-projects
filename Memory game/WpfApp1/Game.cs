using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;

public class Game
{
    public int rows { get; set;}
    public int cols { get; set;}
    public int level { get; set;}
    public List<string> cards { get; set;}
    public List<bool> isFlipped { get; set;}
}