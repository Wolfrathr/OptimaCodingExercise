using ScoreBoard.Core.Entities;
using ScoreBoard.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreBoard.Services
{
    public class ScoreBoardService : IScoreBoardService
    {

        private List<Game> _games = new List<Game>();

        public ScoreBoardService(List<Game> games)
        {
            _games = games;
        }

        public bool FinishGame(int idGame)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public bool StartGame(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public bool UpdateScore(int idGame, int homeTeamScore, int awayTeamScore)
        {
            throw new NotImplementedException();
        }
    }
}
