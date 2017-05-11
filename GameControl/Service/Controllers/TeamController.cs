using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using Repository.Persistence;
using Service.Models.Team;

namespace Service.Controllers
{
    [RoutePrefix("api/team")]
    public class TeamController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(TeamModelAdd model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Team t = new Team();
                    t.Name = model.Name;
                    t.Tournament_ID = model.Tournament_ID;

                    TeamRepository rep = new TeamRepository();
                    rep.Insert(t);

                    return Request.CreateResponse(HttpStatusCode.OK, "");
                }
                catch (Exception e)
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
        public HttpResponseMessage Edit(TeamModelEdit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Team t = new Team();
                    t.Team_ID = model.Team_ID;
                    t.Name = model.Name;
                    t.Tournament_ID = model.Tournament_ID;

                    TeamRepository rep = new TeamRepository();
                    rep.Update(t);

                    return Request.CreateResponse(HttpStatusCode.OK, "");
                }
                catch (Exception e)
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
                TeamRepository rep = new TeamRepository();
                Team t = rep.GetByID(id);

                rep.Delete(t);

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
                List<TeamModelGet> list = new List<TeamModelGet>();

                TeamRepository rep = new TeamRepository();
                foreach (Team t in rep.ListAll())
                {
                    TeamModelGet model = new TeamModelGet();
                    model.Team_ID = t.Team_ID;
                    model.Name = t.Name;
                    model.Tournament_ID = t.Tournament_ID;
                    model.Tournament_Name = t.Tournament.Name;

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
                TeamRepository rep = new TeamRepository();
                Team t = rep.GetByID(id);

                TeamModelGet model = new TeamModelGet();
                model.Team_ID = t.Team_ID;
                model.Name = t.Name;
                model.Tournament_ID = t.Tournament_ID;
                model.Tournament_Name = t.Tournament.Name;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }        
    }
}
