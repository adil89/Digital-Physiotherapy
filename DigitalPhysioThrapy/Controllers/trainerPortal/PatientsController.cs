using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalPhysioThrapy.Models;


namespace DigitalPhysioThrapy.Controllers
{
    public class PatientsController : Controller
    {
        //
        // GET: /Patients/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData()
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                List<tbl_Patients> data = db.tbl_Patients.ToList();
                return Json(new { data }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SendMessage(int id, string message)
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                tbl_Messages msg = new tbl_Messages();
                msg.PatientsIDFK = id;
                msg.message = message;
                msg.IsVideo = false;
                db.tbl_Messages.Add(msg);
                db.SaveChanges();

                return null;
            }
        }

        public ActionResult SendVideo(int id, string videoId)
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                tbl_Messages msg = new tbl_Messages();
                msg.PatientsIDFK = id;
                msg.message = videoId;
                msg.IsVideo = true;
                db.tbl_Messages.Add(msg);
                db.SaveChanges();

                return null;
            }
        }

        public ActionResult addPatients()
        {
            return View();
        }

        public ActionResult getVideos()
        {
            return View();
        }

        public ActionResult SavePatient(string name, string t_name, string user_name, string password)
        {
            using (dTharapyDBEntities db = new dTharapyDBEntities())
            {
                tbl_Patients tbP = new tbl_Patients();
                tbP.Name = name;
                tbP.t_Name = t_name;
                tbP.p_Completed = "0%";
                tbP.user_name = user_name;
                tbP.password = password;
                db.tbl_Patients.Add(tbP);
                db.SaveChanges();

                return null;
            } 
        }

    }
}
