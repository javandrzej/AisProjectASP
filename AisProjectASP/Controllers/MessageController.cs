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
        private IMessagesManager massagesManager = new MessagesManager();

        // GET: Message/GetMessages
        public JsonResult GetMessages()
        {
            return Json(massagesManager.GetMessages().OrderByDescending(i => i.Date).Take(10), JsonRequestBehavior.AllowGet);
        }

        // GET: Message/GetOlderMessages
        public JsonResult GetOlderMessages()
        {
            return Json(massagesManager.GetMessages().OrderByDescending(i => i.Date).Skip(10), JsonRequestBehavior.AllowGet);
        }

        //GET: Message/GetOlderMessages?startIndex=12&count=2
        public JsonResult GetOlderMessagesWithParameters([FromUri] int startIndex, [FromUri] int count)
        {
            return Json(massagesManager.GetMessages().OrderByDescending(i => i.Date).Skip(startIndex).Take(count), JsonRequestBehavior.AllowGet);
        }

        // GET: Message/Details/id
        public JsonResult Details(Guid id)
        {
            return Json(massagesManager.GetMessages().Where(i => i.Id == id), JsonRequestBehavior.AllowGet);
        }

        // POST: Message/Create
        public JsonResult Create([FromBody]Message msg)
        {
            msg.Id = Guid.NewGuid();
            massagesManager.SaveMessage(msg);
            return Json(msg);
        }

        // POST: Message/Update/
        public JsonResult Update([FromBody] Message msg)
        {
            massagesManager.UpdateMessage(msg);
            return Json(msg);
        }
        // GET: Message/Delete/id
        public HttpResponseMessage Delete(Guid id)
        {
            if (id.ToString() == string.Empty)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            massagesManager.DeleteMessage(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}