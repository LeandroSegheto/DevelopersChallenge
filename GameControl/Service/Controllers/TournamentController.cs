using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using Repository.Persistence;
using Service.Models.Tournament;

namespace Service.Controllers
{
    [RoutePrefix("api/tournament")]
    public class TournamentController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(TournamentModelAdd model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Tournament t = new Tournament();
                    t.Name = model.Name;
                    t.NumberOfTeams = model.NumberOfTeams;
                    t.Start = model.Start;

                    TournamentRepository rep = new TournamentRepository();
                    rep.Insert(t);

                    return Request.CreateResponse(HttpStatusCode.OK, "");
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("edit")]
        public HttpResponseMessage Edit(TournamentModelEdit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Tournament t = new Tournament();
                    t.Tournament_ID = model.Tournament_ID;
                    t.Name = model.Name;
                    t.NumberOfTeams = model.NumberOfTeams;
                    t.Start = model.Start;

                    TournamentRepository rep = new TournamentRepository();
                    rep.Update(t);

                    return Request.CreateResponse(HttpStatusCode.OK, "");
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                List<string> erros = new List<string>();
                foreach (var m in ModelState)
                {
                    foreach (var e in m.Value.Errors)
                    {
                        erros.Add(e.ErrorMessage);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, erros.Distinct());
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                TournamentRepository rep = new TournamentRepository();
                Tournament t = rep.GetByID(id);

                rep.Delete(t);

                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            catch(Exception e)
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
                List<TournamentModelGet> list = new List<TournamentModelGet>();

                TournamentRepository rep = new TournamentRepository();
                foreach (Tournament t in rep.ListAll())
                {
                    TournamentModelGet model = new TournamentModelGet();
                    model.Tournament_ID = t.Tournament_ID;
                    model.Name = t.Name;
                    model.NumberOfTeams = t.NumberOfTeams;
                    model.Start = t.Start;

                    list.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch(Exception e)
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
                TournamentRepository rep = new TournamentRepository();
                Tournament t = rep.GetByID(id);

                TournamentModelGet model = new TournamentModelGet();
                model.Tournament_ID = t.Tournament_ID;
                model.Name = t.Name;
                model.NumberOfTeams = t.NumberOfTeams;
                model.Start = t.Start;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }                
    }
}
