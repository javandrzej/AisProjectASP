using AisProjectASP.Models;
using AisProjectASP.Utils;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AisProjectASP.Controllers
{
    public class MessageController : Controller
    {
        private IMessagesManager cacheHelper = new MessagesManager();

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: Message/GetMessages
        public JsonResult GetMessages()
        {
            return Json(cacheHelper.GetMessages().OrderByDescending(i => i.Date).Take(10), JsonRequestBehavior.AllowGet);
        }

        // GET: Message/GetOlderMessages
        public JsonResult GetOlderMessages()
        {
            return Json(cacheHelper.GetMessages().OrderByDescending(i => i.Date).Skip(10), JsonRequestBehavior.AllowGet);
        }

        // GET: Message/Details/id
        public JsonResult Details(Guid id)
        {
            return Json(cacheHelper.GetMessages().Where(i => i.Id == id), JsonRequestBehavior.AllowGet);
        }

        // POST: Message/Create
        public HttpResponseMessage Create([FromBody]Message msg)
        {
            if (msg.Body != null && msg.Id.ToString() != string.Empty)
            {
                msg.Id = Guid.NewGuid();
                cacheHelper.SaveMessage(msg);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST: Message/Update/
        public HttpResponseMessage Update([FromBody] Message msg)
        {
            cacheHelper.UpdateMessage(msg); if (msg.Body != null && msg.Id.ToString() != string.Empty)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            cacheHelper.UpdateMessage(msg);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // GET: Message/Delete/id
        public HttpResponseMessage Delete(Guid id)
        {
            if (id.ToString() == string.Empty)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            cacheHelper.DeleteMessage(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}