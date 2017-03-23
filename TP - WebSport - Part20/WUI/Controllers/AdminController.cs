using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using WUI.Helper;
using BO;
using DAL.Extensions;
using Repository;

namespace WUI.Controllers
{
    [Authorize (Roles="Administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult ListInscris(int idCourse, int page)
        {
            MgtInscription serviceinscription = MgtInscription.Instance;

            int numberInscription = serviceinscription.GetNumberInscription(idCourse);
            Pager pager = new Pager(numberInscription, page, 50);

            var viewModel = new IndexViewModel
            {
                Items = serviceinscription.GetInscription(idCourse, (pager.CurrentPage - 1 ) * pager.PageSize, pager.PageSize),
                Pager = pager,
                IdCourse = idCourse,
            };

            return View(viewModel);
        }
        public void Generate(int idCourse)
        {
            List<Competitor> competitors = new List<Competitor>();
            List<int> idCompetitor = new List<int>();
            UnitOfWork _uow = new UnitOfWork();

            for (int i=1; i<=50000; i++)
            {
                Competitor competitor = new Competitor();
                competitor.IsCompetitor = true;
                competitor.Prenom = i.ToString();
                competitor.Nom = (i-1).ToString();
            }
            foreach(Competitor comp in competitors)
            {
               idCompetitor.Add(_uow.ContributorRepo.Add(comp.ToDataEntity()).PersonId);
            }
        }


    }
}
