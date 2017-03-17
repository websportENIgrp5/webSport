using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WUI.Controllers
{
    public class DifficulteController : Controller
    {
        private MgtDifficulte serviceDifficulte;

        /// <summary>
        /// Constructeur
        /// </summary>
        public DifficulteController()
        {
            serviceDifficulte = MgtDifficulte.GetInstance();
        }
    }
}