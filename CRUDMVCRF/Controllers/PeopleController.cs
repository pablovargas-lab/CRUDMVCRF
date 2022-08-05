using CRUDMVCRF.Models;
using CRUDMVCRF.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVCRF.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<ListPeopleViewModel> lst = new List<ListPeopleViewModel>();
            using (CrudMvcRFEntities db =
                new CrudMvcRFEntities())
            {
                //List<ListPeopleViewModel>
                lst =
                   (from d in db.people
                    orderby d.id descending
                    select new ListPeopleViewModel
                    {
                        Id = d.id,
                        Name = d.name,
                        Age = d.age
                    }).ToList();



            }


            return View(lst);

        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Save(PeopleViewModel model)
        {
            try
            {
                using (CrudMvcRFEntities db = new CrudMvcRFEntities())
                {
                    var oPeople = new people();
                    oPeople.name= model.Name;
                    oPeople.age= model.Age;
                    db.people.Add(oPeople);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);


            }

        }
    }
} 