using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using Repository.Persistence;
using Service.Models.Match;

namespace Service.Controllers
{
    [RoutePrefix("api/match")]
    public class MatchController : ApiController
    {
        [HttpPost]
        [Route("creatematch")]
        public HttpResponseMessage CreateMatch(int tournament_ID)
        {
            try
            {
                TournamentRepository repTournament = new TournamentRepository();
                Tournament t = repTournament.GetByID(tournament_ID);

                TeamRepository repTeam = new TeamRepository();
                List<Team> teams = repTeam.GetByTournamentID(tournament_ID);

                if (t.NumberOfTeams == teams.Count)
                {
                    MatchRepository rep = new MatchRepository();

                    Match m = new Match();
                    m.Tournament_ID = tournament_ID;

                    foreach (Team team in teams)
                    {
                        if (m.Team1 == null)
                        {
                            m.Team1 = team.Name;
                        }
                        else
                        {
                            m.Team2 = team.Name;
                            rep.Insert(m);

                            m = new Match();
                            m.Tournament_ID = tournament_ID;
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, "");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Number of teams error");
                }                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }            
        }

        [HttpPost]
        [Route("expandmatch")]
        public HttpResponseMessage ExpandMatch(int tournament_ID)
        {
            try
            {
                MatchRepository rep = new MatchRepository();
                List<Match> Matchs = rep.GetByTournamentID(tournament_ID);

                Boolean Expand = false;
                foreach (Match m in Matchs)
                    Expand = m.TeamVictory != null;

                if (Expand)
                {
                    Match match = new Match();
                    match.Tournament_ID = tournament_ID;

                    foreach (Match m in Matchs)
                    {
                        if (!m.Result)
                        {
                            m.Result = true;
                            rep.Update(m);

                            if (match.Team1 == null)
                            {
                                match.Team1 = m.TeamVictory;
                            }
                            else
                            {
                                match.Team2 = m.TeamVictory;
                                rep.Insert(match);

                                match = new Match();
                                match.Tournament_ID = tournament_ID;
                            }
                        }                        
                    }                    
                }

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("editmatch")]
        public HttpResponseMessage EditMatch(MatchModelEdit model)
        {   
            try
            {
                Match m = new Match();
                m.Match_ID = model.Match_ID;
                m.Tournament_ID = model.Tournament_ID;
                m.Team1 = model.Team1;
                m.Team2 = model.Team2;
                m.Score1 = model.Score1;
                m.Score2 = model.Score2;

                if (model.Score1 > model.Score2)
                    m.TeamVictory = model.Team1;
                else
                    m.TeamVictory = model.Team2;
                    
                MatchRepository rep = new MatchRepository();
                rep.Update(m);

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }            
        }

        [HttpDelete]
        [Route("deletematch")]
        public HttpResponseMessage DeleteMatch(int tournament_ID)
        {
            try
            {
                MatchRepository rep = new MatchRepository();
                foreach (Match m in rep.GetByTournamentID(tournament_ID))
                    rep.Delete(m);

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        [Route("list")]
        public HttpResponseMessage ListAll()
        {
            try
            {
                List<MatchModelGet> list = new List<MatchModelGet>();

                MatchRepository rep = new MatchRepository();
                foreach (Match m in rep.ListAll())
                {
                    MatchModelGet model = new MatchModelGet();
                    model.Match_ID = m.Match_ID;
                    model.Tournament_ID = m.Tournament_ID;
                    model.Team1 = m.Team1;
                    model.Team2 = m.Team2;
                    model.Score1 = m.Score1;
                    model.Score2 = m.Score2;
                    model.TeamVictory = m.TeamVictory;

                    list.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("getbytournamentid")]
        public HttpResponseMessage GetByTournamentID(int id)
        {
            try
            {
                List<MatchModelGet> list = new List<MatchModelGet>();

                MatchRepository rep = new MatchRepository();
                foreach (Match m in rep.GetByTournamentID(id))
                {
                    MatchModelGet model = new MatchModelGet();
                    model.Match_ID = m.Match_ID;
                    model.Tournament_ID = m.Tournament_ID;
                    model.Team1 = m.Team1;
                    model.Team2 = m.Team2;
                    model.Score1 = m.Score1;
                    model.Score2 = m.Score2;
                    model.TeamVictory = m.TeamVictory;

                    list.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("getbyid")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                MatchRepository rep = new MatchRepository();
                Match m = rep.GetByID(id);

                MatchModelGet model = new MatchModelGet();
                model.Match_ID = m.Match_ID;
                model.Tournament_ID = m.Tournament_ID;
                model.Team1 = m.Team1;
                model.Team2 = m.Team2;
                model.Score1 = m.Score1;
                model.Score2 = m.Score2;
                model.TeamVictory = m.TeamVictory;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
