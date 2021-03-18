using ScoreBoard.Services.Interfaces;
using ScoreBoard.Services;
using System;
using System.Collections.Generic;

namespace OptimaCodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;

            Console.WriteLine("*****************************************");
            Console.WriteLine("   Live Football World Cup Score Board   ");
            Console.WriteLine("*****************************************");
            Console.WriteLine("\t1 - Get summary of games");
            Console.WriteLine("\t2 - Start a game");
            Console.WriteLine("\t3 - Finish game");
            Console.WriteLine("\t4 - Update score");
            Console.WriteLine("\t5 - Exit");

            IScoreBoardService scoreBoard = new ScoreBoardService();

            while (!exitApp)
            {
                switch (Console.ReadLine())
                {
                    case "1":

                        var games = scoreBoard.GetAllGames();
                        if (games.Count > 0)
                        {
                            Console.WriteLine("-----");
                            foreach (var game in games)
                            {
                                Console.WriteLine($"{ game.HomeTeam.Team.TeamName } { game.HomeTeam.Score } - { game.AwayTeam.Score } { game.AwayTeam.Team.TeamName }");
                            }
                            Console.WriteLine("-----");
                        }
                        else
                        {
                            Console.WriteLine("-----");
                            Console.WriteLine($"No games live");
                            Console.WriteLine("-----");
                        }

                        break;
                    case "2":

                        Console.WriteLine($"Write home team");
                        var homeTeam = Console.ReadLine();
                        Console.WriteLine($"Write away team");
                        var awayTeam = Console.ReadLine();

                        var resultCreate = scoreBoard.StartGame(homeTeam, awayTeam);
                        var resultTextCreate = resultCreate == true ? "Game create" : "One of the teams is already playing";

                        Console.WriteLine(resultTextCreate);

                        break;
                    case "3":
                        Console.WriteLine($"Select a game to finish (write the number)");

                        var gamesFinish = scoreBoard.GetAllGames();
                        if (gamesFinish.Count > 0)
                        {
                            Console.WriteLine("-----");
                            foreach (var game in gamesFinish)
                            {
                                Console.WriteLine($"{ game.Id } --> { game.HomeTeam.Team.TeamName } { game.HomeTeam.Score } - { game.AwayTeam.Score } { game.AwayTeam.Team.TeamName }");
                            }
                            Console.WriteLine("-----");

                            var gameToDelete = Console.ReadLine();

                            int gameToDeleteInt;
                            string resultTextFinish = "Data introduced not valid";

                            if (Int32.TryParse(gameToDelete, out gameToDeleteInt))
                            {
                                var resultFinish = scoreBoard.FinishGame(gameToDeleteInt);

                                resultTextFinish = resultFinish == true ? "Game finished" : "The number introduced is not in the list of games";
                            }

                            Console.WriteLine(resultTextFinish);
                        }
                        else
                        {
                            Console.WriteLine("-----");
                            Console.WriteLine($"No games live");
                            Console.WriteLine("-----");
                        }

                        break;
                    case "4":
                        Console.WriteLine($"Select a game to update (write the number)");

                        var gamesUpdate = scoreBoard.GetAllGames();
                        if (gamesUpdate.Count > 0)
                        {
                            Console.WriteLine("-----");
                            foreach (var game in gamesUpdate)
                            {
                                Console.WriteLine($"{ game.Id } --> { game.HomeTeam.Team.TeamName } { game.HomeTeam.Score } - { game.AwayTeam.Score } { game.AwayTeam.Team.TeamName }");
                            }
                            Console.WriteLine("-----");

                            var gameToUpdate = Console.ReadLine();

                            Console.WriteLine($"Write home team score");
                            var homeTeamScore = Console.ReadLine();
                            Console.WriteLine($"Write away team score");
                            var awayTeamScore = Console.ReadLine();

                            int gametoUpdateInt, homeTeamScoreInt, awayTeamScoreInt;
                            string resultTextUpdate = "Data introduced not valid";

                            if (Int32.TryParse(gameToUpdate, out gametoUpdateInt) &&
                                Int32.TryParse(homeTeamScore, out homeTeamScoreInt) &&
                                Int32.TryParse(awayTeamScore, out awayTeamScoreInt))
                            {
                                var resultUpdate = scoreBoard.UpdateScore(gametoUpdateInt, homeTeamScoreInt, awayTeamScoreInt);
                                resultTextUpdate = resultUpdate == true ? "Game update" : "The number introduced is not in the list of games";
                            }

                            Console.WriteLine(resultTextUpdate);
                        }
                        else
                        {
                            Console.WriteLine("-----");
                            Console.WriteLine($"No games live");
                            Console.WriteLine("-----");
                        }

                        break;
                    case "5":
                        exitApp = true;
                        break;
                    default:
                        Console.WriteLine($"The command is incorrect, please select a valid command");
                        break;

                }

            }

        }

    }
}
