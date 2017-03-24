using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using WUI.Extensions;

namespace WUI.Controllers
{
    [Authorize]
    public class InscriptionController : Controller
    {
        private MgtRace serviceRace;


        public InscriptionController()
        {
            serviceRace = MgtRace.GetInstance();
        }

        [Authorize]
        public ActionResult Inscrire(int id)
        {
            var result = MgtRace.GetInstance().GetRace(id).ToModel();
            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        public ActionResult ConfirmInscription(int idCourse, string loginUser)
        {
            MgtInscription inscriptionManager = MgtInscription.Instance;

            if(inscriptionManager.WriteInscription(idCourse, loginUser))
            {
                TempData.Add("inscri", "valide");
            }
            else
            {
                TempData.Add("inscri", "alreadyInscri");
            }
            return View();
        }
    }
}
