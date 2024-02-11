﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NFLTeams.Models
{
    public class NFLSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";
        private const string UsernameKey = "username";

        private ISession session { get; set; }
        public NFLSession(ISession session) {
            this.session = session;
        }

        public void SetUsername(string username)
        {
            if (username == null)
            {
                session.Remove(UsernameKey);
            }
            else
            {
                session.SetString(UsernameKey, username);
            }
        }


        public string GetUsername() => session.GetString(UsernameKey);
        
        public void SetMyTeams(List<Team> teams) {
            session.SetObject(TeamsKey, teams);
            session.SetInt32(CountKey, teams.Count);
        }
        public List<Team> GetMyTeams() =>
            session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();
        public int? GetMyTeamCount() => session.GetInt32(CountKey);

        public void SetActiveConf(string conference) =>
            session.SetString(ConfKey, conference);
        public string GetActiveConf() => session.GetString(ConfKey);

        public void SetActiveDiv(string division) =>
            session.SetString(DivKey, division);
        public string GetActiveDiv() => session.GetString(DivKey);

        public void RemoveMyTeams() {
            session.Remove(TeamsKey);
            session.Remove(CountKey);
        }
    }
}
