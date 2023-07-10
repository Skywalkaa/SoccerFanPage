using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamainFootball.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(player pl)
        {

            DataClasses1DataContext data = new DataClasses1DataContext();

            player player = new player
            {
                nom = pl.nom,
                prenom = pl.prenom,
                paye = pl.paye,
                nbrVote = pl.nbrVote,


            };

            data.players.InsertOnSubmit(player);
            data.SubmitChanges();


            ViewBag.message = "submited succesfyly";






            return View("");
        }

    }
}
