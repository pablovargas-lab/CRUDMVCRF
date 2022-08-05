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
                    oPeople.name = model.Name;
                    oPeople.age = model.Age;
                    db.people.Add(oPeople);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);


            }

        }
        public ActionResult Edit(int Id)
        {
            PeopleViewModel model = new PeopleViewModel();
            using (CrudMvcRFEntities db = new CrudMvcRFEntities())
            {
                var oPeople = db.people.Find(Id);
                model.Name = oPeople.name;
                model.Age = oPeople.age;
                model.Id = oPeople.id;

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(PeopleViewModel model)
        {
            try
            {
                using (CrudMvcRFEntities db = new CrudMvcRFEntities())
                {
                    var oPeople = db.people.Find(model.Id);
                    oPeople.name = model.Name;
                    oPeople.age = model.Age;
                    db.Entry(oPeople).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);


            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (CrudMvcRFEntities db = new CrudMvcRFEntities())
                {
                    var oPeople = db.people.Find(Id);
                    db.people.Remove(oPeople);

                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);


            }
        }


    }
}