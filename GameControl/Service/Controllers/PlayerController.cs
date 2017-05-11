using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity;
using Repository.Persistence;
using Service.Models.Player;

namespace Service.Controllers
{
    [RoutePrefix("api/player")]
    public class PlayerController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(PlayerModelAdd model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Player p = new Player();
                    p.Name = model.Name;
                    p.Team_ID = model.Team_ID;

                    PlayerRepository rep = new PlayerRepository();
                    rep.Insert(p);

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
        public HttpResponseMessage Edit(PlayerModelEdit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Player p = new Player();
                    p.Player_ID = model.Player_ID;
                    p.Name = model.Name;
                    p.Team_ID = model.Team_ID;

                    PlayerRepository rep = new PlayerRepository();
                    rep.Update(p);

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
                PlayerRepository rep = new PlayerRepository();
                Player p = rep.GetByID(id);

                rep.Delete(p);

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
                List<PlayerModelGet> list = new List<PlayerModelGet>();

                PlayerRepository rep = new PlayerRepository();
                foreach (Player p in rep.ListAll())
                {
                    PlayerModelGet model = new PlayerModelGet();
                    model.Player_ID = p.Player_ID;
                    model.Name = p.Name;
                    model.Team_ID = p.Team_ID;
                    model.Team_Name = p.Team.Name;

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
                PlayerRepository rep = new PlayerRepository();
                Player p = rep.GetByID(id);

                PlayerModelGet model = new PlayerModelGet();
                model.Player_ID = p.Player_ID;
                model.Name = p.Name;
                model.Team_ID = p.Team_ID;
                model.Team_Name = p.Team.Name;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
