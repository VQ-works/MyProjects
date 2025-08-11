using static System.Console;

namespace RockPaperScisers;
enum Tools {
    rock,
    paper,
    scissors
}
class Game
{
    int i,num;
    string? text;
    public string[]? arr;
    public string Result(string playerTool)
    {
        if (playerTool == arr[0] || (Program.x == true && Program.playerScore < Program.botScore))
        {
            Program.botScore++;
            text = "You lost";

        }
        else if (playerTool == arr[arr.Length - 1] || (Program.x == true && Program.playerScore > Program.botScore))
        {

            Program.playerScore++;
            text = "You won";

        }
        else if (Program.botScore == Program.playerScore && Program.x == true)
        {
            text = "It's a draw.";

        }
        return text;
    }
    public string GameResult(string player,int bot)
    {
        num = bot;
        bot--;
        while (true)
        {
            if (i == Program.tools.Length)
            {
                Result(player);
                i = 0;
                break;
            }
            else
            {  
               arr.SetValue($"{(Tools)((bot == -1) ?  Program.tools.Length - 1 : (bot == Program.tools.Length) ?  0 : bot)}", i);
               bot++;
               i++;
            }
        }
        return $"Player:{player} vs Bot:{(Tools)num}";
    }
}
class Program
{
    string? myChoice;
    Random random = new Random();
    public static bool x;
    public static int playerScore, botScore;
    public static Tools[] tools = (Tools[])Enum.GetValues(typeof(Tools));
    static void Main(string[] args)
    {
        Write($"Let's play \"Rock, Paper, Scissors.\" How many rounds would you like to play? -> ");
        int.TryParse(ReadLine(), out int result);
      
        Game game = new Game() { arr = new string[tools.Length] };
        Program p = new Program();
        for (int i = 1; i <= result;)
        {
            Write($"\nRound{i}: Which do you choose — <rock, paper, or scissors>? -> ");
            p.myChoice = ReadLine().ToLower();
            if (tools.Any(t=>$"{t}" == p.myChoice)) {
                WriteLine(game.GameResult(p.myChoice, p.random.Next(tools.Length)));
                WriteLine($"{playerScore} - {botScore}");
                if (i == result)
                {
                    x = true;
                    WriteLine(game.Result(default));
                }
                i++;
            }
        }
    }
}
