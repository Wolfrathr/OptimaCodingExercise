using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreBoard.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public TeamGame HomeTeam { get; set; }
        public TeamGame AwayTeam { get; set; }
        public DateTime StartDate { get; set; }
    }
}
