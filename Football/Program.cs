using System;
using System.Xml.Linq;

public abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public abstract class FootballPlayer : Person
{
    public int Number { get; set; }
    public double Height { get; set; }
}

public class Goalkeeper : FootballPlayer { }
public class Defender : FootballPlayer { }
public class Midfielder : FootballPlayer { }
public class Striker : FootballPlayer { }

public class Coach : Person { }

public class Referee : Person { }

public class Team
{
    public string Name { get; set; }
    public Coach Coach { get; set; }
    private FootballPlayer[] players;

    public FootballPlayer[] Players
    {
        get { return players; }
        set
        {
            if (value.Length >= 11 && value.Length <= 22)
                players = value;
            else
                throw new ArgumentException("The number of players must be between 11 and 22.");
        }
    }

    public double GetAveragePlayerAge()
    {
        int totalAge = 0;
        foreach (var player in Players)
            totalAge += player.Age;

        return totalAge / Players.Length;
    }
}

public class Goal
{
    public int Minute { get; set; }
    public FootballPlayer Player { get; set; }
}

public class Game
{
    private Team team1 { get; set; }

    public Team Team1
    {
        get { return team1; }
        set
        {
            if (value.Players.Length == 11)
                team1 = value;
            else
                throw new ArgumentException("The number of players in a game must be 11.");
        }
    }

    private Team team2 { get; set; }

    public Team Team2
    {
        get { return team2; }
        set
        {
            if (value.Players.Length == 11)
                team2 = value;
            else
                throw new ArgumentException("The number of team players in a game must be 11.");
        }
    }

    public Referee Referee { get; set; }

    private Referee[] assistantReferees;

    public Referee[] AssistantReferees
    {
        get { return assistantReferees; }
        set
        {
            if (value.Length == 2)
                assistantReferees = value;
            else
                throw new ArgumentException("The number of team  assistant referees must be between 2.");
        }
    }

    public Goal[] Goals { get; set; }
    public string Result { get; set; }
    public Team Winner { get; set; }

    public Game()
    {
        Result = "0-0";
        Winner = null;
    }

    public void CalculateResult()
    {
        int team1Goals = 0;
        int team2Goals = 0;

        foreach (var goal in Goals)
        {
            if (Team1.Players.Contains(goal.Player))
                team1Goals++;
            else if (Team2.Players.Contains(goal.Player))
                team2Goals++;
        }

        Result = $"{team1Goals}-{team2Goals}";

        if (team1Goals > team2Goals)
            Winner = Team1;
        else if (team2Goals > team1Goals)
            Winner = Team2;
        else
            Winner = null;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var teamA = new Team
            {
                Name = "CSKA",
                Coach = new Coach { Name = "Coach A", Age = 49 },
                Players = new FootballPlayer[]
                {
                    new Goalkeeper { Name = "Player 1", Number = 1, Age = 25, Height = 1.9 },
                    new Defender { Name = "Player 2", Number = 2, Age = 23, Height = 1.8 },
                    new Midfielder { Name = "Player 3", Number = 3, Age = 27, Height = 1.75 },
                    new Striker { Name = "Player 4", Number = 4, Age = 22, Height = 1.85 },
                    new Striker { Name = "Player 5", Number = 5, Age = 31, Height = 1.85 },
                    new Striker { Name = "Player 6", Number = 6, Age = 19, Height = 1.89 },
                    new Striker { Name = "Player 7", Number = 7, Age = 24, Height = 1.95 },
                    new Striker { Name = "Player 8", Number = 8, Age = 25, Height = 1.69 },
                    new Striker { Name = "Player 9", Number = 9, Age = 26, Height = 1.8 },
                    new Striker { Name = "Player 10", Number = 10, Age = 22, Height = 1.9 },
                    new Striker { Name = "Player 11", Number = 11, Age = 29, Height = 1.91 },
                    new Striker { Name = "Player 11", Number = 11, Age = 29, Height = 1.91 },
                }
            };

            var teamB = new Team
            {
                Name = "Levski",
                Coach = new Coach { Name = "Coach B", Age = 40 },
                Players = new FootballPlayer[]
                {
                    new Goalkeeper { Name = "Player 1", Number = 1, Age = 25, Height = 1.9 },
                    new Defender { Name = "Player 2", Number = 2, Age = 23, Height = 1.8 },
                    new Midfielder { Name = "Player 3", Number = 3, Age = 27, Height = 1.75 },
                    new Striker { Name = "Player 4", Number = 4, Age = 22, Height = 1.85 },
                    new Striker { Name = "Player 5", Number = 5, Age = 31, Height = 1.85 },
                    new Striker { Name = "Player 6", Number = 6, Age = 19, Height = 1.89 },
                    new Striker { Name = "Player 7", Number = 7, Age = 24, Height = 1.95 },
                    new Striker { Name = "Player 8", Number = 8, Age = 25, Height = 1.69 },
                    new Striker { Name = "Player 9", Number = 9, Age = 26, Height = 1.8 },
                    new Striker { Name = "Player 10", Number = 10, Age = 22, Height = 1.9 },
                    new Striker { Name = "Player 11", Number = 11, Age = 29, Height = 1.91 },
                }
            };

            var game = new Game
            {
                Team1 = new Team
                {
                    Name = teamA.Name,
                    Coach = teamA.Coach,
                    Players = new FootballPlayer[]
                    {
                        teamA.Players[0],
                        teamA.Players[1],
                        teamA.Players[2],
                        teamA.Players[3],
                        teamA.Players[4],
                        teamA.Players[5],
                        teamA.Players[6],
                        teamA.Players[7],
                        teamA.Players[8],
                        teamA.Players[9],
                        teamA.Players[10],
                    }
                },
                Team2 = new Team
                {
                    Name = teamB.Name,
                    Coach = teamB.Coach,
                    Players = new FootballPlayer[]
                    {
                        teamB.Players[0],
                        teamB.Players[1],
                        teamB.Players[2],
                        teamB.Players[3],
                        teamB.Players[4],
                        teamB.Players[5],
                        teamB.Players[6],
                        teamB.Players[7],
                        teamB.Players[8],
                        teamB.Players[9],
                        teamB.Players[10],
                    }
                },
                Referee = new Referee { Name = "Referee", Age = 35 },
                AssistantReferees = new Referee[] {
                     new Referee { Name = "Assistant Referee 1", Age = 28 },
                     new Referee { Name = "Assistant Referee 2", Age = 29 },
                },
                Goals = new Goal[] {
                    new Goal { Minute = 10, Player = teamA.Players[0] },
                    new Goal { Minute = 14, Player = teamB.Players[0] },
                    new Goal { Minute = 23, Player = teamA.Players[0] },
                },
            };

            Console.WriteLine($"{teamA.Name} average player age: {teamA.GetAveragePlayerAge()}");

            game.CalculateResult();

            Console.WriteLine($"{game.Team1.Name} vs {game.Team2.Name}");
            Console.WriteLine($"Game result: {game.Result}");
            Console.WriteLine($"Winner: {game.Winner.Name}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}