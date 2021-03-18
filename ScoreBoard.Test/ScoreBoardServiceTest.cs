using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreBoard.Core.Entities;
using ScoreBoard.Services;
using ScoreBoard.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardServiceTest
    {

        private IScoreBoardService _scoreBoard; 

        [TestInitialize]
        public void Initialize()
        {
            List<Game> games = new List<Game>();
            games.Add(new Game
            {
                Id = 1,
                HomeTeam = new TeamGame { Team = new Team { TeamName = "Spain" }, Score = 0 },
                AwayTeam = new TeamGame { Team = new Team { TeamName = "Netherlands" }, Score = 0 },
                StartDate = DateTime.Now
            });
            games.Add(new Game
            {
                Id = 2,
                HomeTeam = new TeamGame { Team = new Team { TeamName = "Brazil" }, Score = 0 },
                AwayTeam = new TeamGame { Team = new Team { TeamName = "Germany" }, Score = 0 },
                StartDate = DateTime.Now
            });
            games.Add(new Game
            {
                Id = 3,
                HomeTeam = new TeamGame { Team = new Team { TeamName = "Argentina" }, Score = 0 },
                AwayTeam = new TeamGame { Team = new Team { TeamName = "Italy" }, Score = 0 },
                StartDate = DateTime.Now
            });

            _scoreBoard = new ScoreBoardService(games);
        }

        [TestMethod]
        public void GetAllGames()
        {
            Assert.IsInstanceOfType(_scoreBoard.GetAllGames(), typeof(List<Game>));
            Assert.IsNotNull(_scoreBoard.GetAllGames());
        }

        [TestMethod]
        public void StartGame()
        {
            Assert.IsFalse(_scoreBoard.StartGame("Spain", "Germany"));
            Assert.IsFalse(_scoreBoard.StartGame("Brazil", "Mexico"));
            Assert.IsTrue(_scoreBoard.StartGame("Mexico", "Peru"));
            Assert.IsFalse(_scoreBoard.StartGame("Spain", "England"));
            Assert.IsTrue(_scoreBoard.StartGame("Ireland", "Finland"));
            Assert.IsTrue(_scoreBoard.StartGame("Portugal", "France"));
        }

        [TestMethod]
        public void FinishGame()
        {
            Assert.IsTrue(_scoreBoard.FinishGame(1));
            Assert.IsTrue(_scoreBoard.FinishGame(2));
            Assert.IsTrue(_scoreBoard.FinishGame(3));
            Assert.IsFalse(_scoreBoard.FinishGame(1));
            Assert.IsFalse(_scoreBoard.FinishGame(4));
        }

        [TestMethod]
        public void UpdateScore()
        {
            Assert.IsTrue(_scoreBoard.UpdateScore(1, 2, 0));
            Assert.IsTrue(_scoreBoard.UpdateScore(1, 3, 1));
            Assert.IsTrue(_scoreBoard.UpdateScore(2, 1, 0));
            Assert.IsTrue(_scoreBoard.UpdateScore(3, 1, 1));
            Assert.IsFalse(_scoreBoard.UpdateScore(4, 2, 0));
        }
    }
}
