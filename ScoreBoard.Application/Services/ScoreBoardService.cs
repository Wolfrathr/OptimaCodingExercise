using ScoreBoard.Core.Entities;
using ScoreBoard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ScoreBoard.Services
{
    public class ScoreBoardService : IScoreBoardService
    {

        private List<Game> _games = new List<Game>();
        private int _idGame = 1;

        public ScoreBoardService([Optional]List<Game> games)
        {
            if (games != null)
                _games = games;
        }

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <param name="homeTeam">Name of the home team</param>
        /// <param name="awayTeam">Name of the away team</param>
        /// <returns>Returns true/false if the game is created or not</returns>
        public bool StartGame(string homeTeam, string awayTeam)
        {
            TeamGame homeTeamGame = new TeamGame
            {
                Team = new Team
                {
                    TeamName = homeTeam
                },
                Score = 0
            };

            TeamGame awayTeamGame = new TeamGame
            {
                Team = new Team
                {
                    TeamName = awayTeam
                },
                Score = 0
            };

            //Check if a team is already playing a game, if is already playing one, we dont add the new game
            var teamPlaying = GetAllGames().Where(x => x.HomeTeam.Team.TeamName == homeTeamGame.Team.TeamName || x.AwayTeam.Team.TeamName == awayTeamGame.Team.TeamName);

            if (teamPlaying.Count() == 0)
            {
                _games.Add(new Game
                {
                    Id = _idGame,
                    HomeTeam = homeTeamGame,
                    AwayTeam = awayTeamGame,
                    StartDate = DateTime.Now
                });

                _idGame++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete a game from the list of games
        /// </summary>
        /// <param name="idGame">The id of the game</param>
        /// <returns>true/false if the game was deleted</returns>
        public bool FinishGame(int idGame)
        {
            var game = GetAllGames().Where(x => x.Id == idGame).FirstOrDefault();
            if (game != null)
            {
                _games.Remove(game);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update a score of a game
        /// </summary>
        /// <param name="idGame">The id of the game to update</param>
        /// <param name="homeTeamScore">Score that will have the home team</param>
        /// <param name="awayTeamScore">Score that will have the away team</param>
        /// <returns>true/false if the game was updated</returns>
        public bool UpdateScore(int idGame, int homeTeamScore, int awayTeamScore)
        {
            var game = GetAllGames().Where(x => x.Id == idGame).FirstOrDefault();
            if (game != null)
            {
                game.HomeTeam.Score = homeTeamScore;
                game.AwayTeam.Score = awayTeamScore;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get all the games that are being played ordered by total score. If any game have the same total score, then ordered by StartDate desc.
        /// </summary>
        /// <returns>List of Game</returns>
        public List<Game> GetAllGames()
        {
            return _games.OrderByDescending(x => x.HomeTeam.Score + x.AwayTeam.Score)
                        .ThenByDescending(x => x.StartDate).ToList();
        }

    }
}
