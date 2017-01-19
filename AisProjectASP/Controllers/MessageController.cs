using AisProjectASP.Models;
using AisProjectASP.Utils;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace AisProjectASP.Controllers
{
    public class MessageController : Controller
    {
        private ICacheHelper cacheHelper = new CacheHelper();

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
        public JsonResult Details(int id)
        {
            return Json(cacheHelper.GetMessages().Where(i => i.Id == id), JsonRequestBehavior.AllowGet);
        }

        // POST: Message/Create
        public void Create([FromBody]Message msg)
        {
            cacheHelper.SaveMessage(msg);
        }

        // POST: Message/Update/
        public void Update([FromBody] Message msg)
        {
            cacheHelper.UpdateMessage(msg);
        }

        // GET: Message/Delete/id
        public void Delete(int id)
        {
            cacheHelper.DeleteMessage(id);
        }
    }
}