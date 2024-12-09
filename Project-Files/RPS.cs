//problem with list, doesnt sort highest at the top and then going down and writes every win into file and doesnt replace just the score


namespace RockPaperScissors
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string user;
            string com;
            bool Game = true;
            string userInput;

            Console.WriteLine("Welcome to the one and only fun game, rock, paper, scissors!!!!!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1] Play Game");
            Console.WriteLine("[2] View Leaderboard");
            Console.WriteLine("[3] Exit");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your name: ");
                        Board.userName = Console.ReadLine();

                        while (Game)
                        {
                            user = "";
                            com = "";

                            while (user != "rock" && user != "paper" && user != "scissors")
                            {
                                Console.WriteLine("Welcome to the Rock Paper Scissors Game");
                                Console.WriteLine("Enter your Rock, Paper or Scissors: ");
                                user = Console.ReadLine();
                                user = user.ToLower();
                            }

                            switch (random.Next(1, 4))
                            {
                                case 1:
                                    com = "rock";
                                    break;
                                case 2:
                                    com = "paper";
                                    break;
                                case 3:
                                    com = "scissors";
                                    break;
                                default:
                                    break;
                            }

                            Console.WriteLine("Player: " + user);
                            Console.WriteLine("Computer: " + com);

                            switch (user)
                            {
                                case "rock":
                                    if (com == "rock")
                                    {
                                        Console.WriteLine("Its a Draw!");
                                    }
                                    else if (com == "paper")
                                    {
                                        Console.WriteLine(Board.userName + " Loses...");
                                    }
                                    else if (com == "scissors")
                                    {
                                        Console.WriteLine(Board.userName + " Wins!!!");
                                        Board.playerScore++;
                                    }

                                    break;
                                case "paper":
                                    if (com == "rock")
                                    {
                                        Console.WriteLine(Board.userName + " Wins!!!");
                                        Board.playerScore++;
                                    }
                                    else if (com == "paper")
                                    {
                                        Console.WriteLine("Its a Draw!");
                                    }
                                    else if (com == "scissors")
                                    {
                                        Console.WriteLine(Board.userName + " Loses...");
                                    }

                                    break;
                                case "scissors":
                                    if (com == "rock")
                                    {
                                        Console.WriteLine(Board.userName + " Loses...");
                                    }
                                    else if (com == "paper")
                                    {
                                        Console.WriteLine(Board.userName + " Wins!!!");
                                        Board.playerScore++;
                                    }
                                    else if (com == "scissors")
                                    {
                                        Console.WriteLine("Its a Draw!");
                                    }

                                    break;
                                default:
                                    break;
                            }

                            Board.WriteLeaderboard();
                            Console.WriteLine("Do you want to play again? (y/n)");
                            userInput = Console.ReadLine();
                            if (userInput.ToLower() == "n")
                            {
                                Game = false;
                            }
                        }
                    }

                    break;
                case "2":
                    if (input == "2")
                    {
                        Console.Clear();
                        Board.ViewLeaderboard();
                        Console.ReadKey();
                    }

                    break;
            }
        }
    }

    public class Board
    {
        static List<Board> leaderboard = new List<Board>();
        public static string userName;
        public static int playerScore;
        static string content;

        public static void WriteLeaderboard()
        {
            string filepath = "Leaderboard.txt";
            leaderboard.OrderBy(Board => Board.playerScore);
            content = (userName + " " + Board.playerScore + Environment.NewLine);
            File.AppendAllText(filepath, content);
        }

        public static void ViewLeaderboard()
        {
            string fileContent = File.ReadAllText("Leaderboard.txt");
            Console.WriteLine(fileContent);
        }
    }
}
    
