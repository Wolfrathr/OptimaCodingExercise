using ScoreBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Services.Interfaces
{
    public interface IScoreBoardService
    {
        bool StartGame(string homeTeam, string awayTeam);

        bool FinishGame(int idGame);

        bool UpdateScore(int idGame, int homeTeamScore, int awayTeamScore);

        List<Game> GetAllGames();
    }
}
