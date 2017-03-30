using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalPhysioThrapy.Models;

namespace DigitalPhysioThrapy.Controllers.trainerPortal
{
    public class trainerLoginController : Controller
    {
        //
        // GET: /trainerLogin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginTrainer(string userName, string password)
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                object obj = 0;
                
                string pswd = (from n in db.tbl_trainers where n.userName == userName select n.password).Single();

                if (pswd == password)
                { obj = 1; }


                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
