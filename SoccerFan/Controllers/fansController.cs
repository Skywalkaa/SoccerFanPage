using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamainFootball.Models;

namespace ExamainFootball.Controllers
{
    public class fansController : Controller
    {
        // GET: fans
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(fan f)

        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            var res = (from x in data.fans
                       where x.username == f.username && x.password == f.password
                       select x.IdFan).SingleOrDefault();
            if (res == 0)
            {
                ViewBag.message = "ppw incorrect";

            }
            else
            {
                user.Id = res;
                return RedirectToAction("Acceuil");
            }
            return View();
        }
        public ActionResult Acceuil()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            var res = (from s in data.fans
                       where s.IdFan == user.Id
                       select s.username).SingleOrDefault();


            ViewBag.message = res.ToString();

            var res1 = (from t in data.players
                        select t).ToList<player>();



            return View(res1);
        }

        public ActionResult logout()
        {
            user.Id = 0;
            return RedirectToAction("login");
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(fan s)
        {

            DataClasses1DataContext data = new DataClasses1DataContext();

            fan f = new fan
            {
                nom = s.nom,
                prenom = s.prenom,
                username = s.username,
                password = s.password,


            };

            data.fans.InsertOnSubmit(f);
            data.SubmitChanges();


            ViewBag.message = "submited succesfyly";






            return RedirectToAction("login");
        }



        public ActionResult addone(string id)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            var res = (from s in data.players
                       where s.nbrVote == Convert.ToInt32(id)
                       select s).SingleOrDefault();



            if(res != null)
            {
                res.nbrVote++;

                
                data.SubmitChanges();
            }
            









            return RedirectToAction("Acceuil");
        }






    }
}