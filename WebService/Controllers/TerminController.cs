using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class TerminController : ApiController
    {
        private ProjekcijaDAO pDAO;
        public TerminController()
        {
            this.pDAO = new ProjekcijaDAO();
        }
        // GET api/termin
        public HttpResponseMessage Get()
        {
            try
            {
                List<Projekcija> projekcije = pDAO.getAll();
                return Request.CreateResponse<List<Projekcija>>(HttpStatusCode.OK, projekcije);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/termin/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Projekcija p = pDAO.getById(id);
                return Request.CreateResponse<Projekcija>(HttpStatusCode.OK, p);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/termin
        public HttpResponseMessage Post([FromBody]Projekcija projekcija)
        {
            try
            {
                long a = pDAO.create(projekcija);
                if (a != 0)
                    return Request.CreateResponse(HttpStatusCode.Created);
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        // PUT api/termin/5
        public HttpResponseMessage Put(int id, [FromBody]Projekcija projekcija)
        {
            try
            {
                pDAO.update(projekcija);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/termin/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Projekcija toDelete = pDAO.getById(id);
                if (toDelete != null)
                {
                    pDAO.delete(toDelete);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
