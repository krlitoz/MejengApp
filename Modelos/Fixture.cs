using System;
using System.Collections.Generic;

namespace MejengApp.Models
{
    public class Fixture
    {
        public int matchday { get; set; }
        public string homeTeamName { get; set; }
        public string awayTeamName { get; set; }
        //public List<Result> result {get; set;}
        public string date { get; set; }
        public Dictionary<string, Object> result { get; set; }
        public string goalsHomeTeam { get; set; }
        public string goalsAwayTeam { get; set; }


        public Fixture ()
        {
            
        }

        public Fixture(int matchday, string homeTeamName, string awayTeamName, string date, string goalsHomeTeam, string goalsAwayTeam)
        {
            this.matchday = matchday;
            this.homeTeamName = homeTeamName;
            this.awayTeamName = awayTeamName;
            this.date = date;
            this.result = result;
            this.goalsHomeTeam = goalsHomeTeam;
            this.goalsAwayTeam = goalsAwayTeam;
        }

        public string ToString()
        {
            return date.Substring(0, 8) + homeTeamName;
        }
    }
}
