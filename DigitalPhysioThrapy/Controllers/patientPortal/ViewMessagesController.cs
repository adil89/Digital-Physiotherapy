using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalPhysioThrapy.Models;

namespace DigitalPhysioThrapy.Controllers.patientPortal
{
    public class ViewMessagesController : Controller
    {
        //
        // GET: /ViewMessages/

        public ActionResult Index(int id)
        {

            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                string pName = (from n in db.tbl_Patients where n.id == id select n.Name).Single().ToString();

                ViewBag.pName = pName;
                ViewBag.PatientId = id;
                return View();
            }
            
        }

        public ActionResult GetMessages(int id)
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {


                List<tbl_Messages> rec = (from n in db.tbl_Messages where n.PatientsIDFK == id select n).ToList(); 

                return Json(new { rec }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
