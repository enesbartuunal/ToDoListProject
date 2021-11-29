using _1_AppCore.Bases.IService;
using _1_AppCore.Bases.Repository;
using _3_DataAccess.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MZKWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationMAZAKA.Models;

namespace WebApplicationMAZAKA.Controllers
{
    public class DutyModelsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly RepositoryBase<DutyModel> repositoryBase;
        private readonly IService<DutyModel> service;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public DutyModelsController()
        {
            db = new ApplicationDbContext();
            repositoryBase = new Repository<DutyModel>(db);
            service = new DutyService(repositoryBase);
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }


        // GET: DutyModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var role = userManager.GetRoles(userId).FirstOrDefault(); 
            if (role == "Admin")
            {
                var gun = DateTime.Now.Date;
                return View(service.GenelSorgu(q => q.Bitis >= gun).ToList());
            }
            else
            {
                var gun = DateTime.Now.Date;
                return View(service.GenelSorgu(q => q.applicationUserId == userId && q.Bitis >= gun));
            }

        }

        public ActionResult Successful()
        {
            var userId = User.Identity.GetUserId();
            var role = userManager.GetRoles(userId).FirstOrDefault();
            if (role == "Admin")
            {

                return View(service.GenelSorgu(q => q.Tamamlandı == true).ToList());
            }
            else
            {

                return View(service.GenelSorgu(q => q.applicationUserId == userId && q.Tamamlandı == true).ToList());
            }
        }

        public ActionResult Unsuccessful()
        {
            var userId = User.Identity.GetUserId();
            var role = userManager.GetRoles(userId).FirstOrDefault();
            if (role == "Admin")
            {
                var gun = DateTime.Now.Date;
                return View(service.GenelSorgu(q => q.Tamamlandı == false && q.Bitis <= gun).ToList());
            }
            else
            {
                var gun = DateTime.Now.Date;
                return View(service.GenelSorgu(q => q.applicationUserId == userId && q.Tamamlandı == false && q.Bitis <= gun).ToList());
            }
        }

        // GET: DutyModels/Details/5
        public ActionResult Details(int id)
        {
            DutyModel dutyModel = service.TekilSorgu(id);
            if (dutyModel == null)
            {
                return HttpNotFound();
            }
            return View(dutyModel);
        }

        // GET: DutyModels/Create
       
        public ActionResult Create()
        {
            var list= userManager.Users.ToList();
            ViewBag.List = new SelectList(list, "Id", "UserName");
            return View();
        }

        // POST: DutyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Başlık,Acıklama,Başlangıc,Bitis,applicationUserId")] DutyModel dutyModel)
        {
            dutyModel.Tamamlandı = false;
            if (ModelState.IsValid)
            {
                service.Ekle(dutyModel);
                service.Kaydet();
                return RedirectToAction("Index");
            }

            return View(dutyModel);
        }

        // GET: DutyModels/Edit/5

        public ActionResult Edit(int id)
        {
            var list = userManager.Users.ToList();
            ViewBag.List = new SelectList(list, "Id", "UserName");
            DutyModel dutyModel = service.TekilSorgu(id);
            if (dutyModel == null)
            {
                return HttpNotFound();
            }
            return View(dutyModel);
        }

        // POST: DutyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Başlık,Acıklama,Başlangıc,Bitis,Tamamlandı,applicationUserId")] DutyModel dutyModel)
        {
            if (ModelState.IsValid)
            {
                service.Güncelle(dutyModel);
                service.Kaydet();
                return RedirectToAction("Index");
            }
            return View(dutyModel);
        }

        // GET: DutyModels/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            var dutyModel = service.TekilSorgu(id);
            if (dutyModel == null)
            {
                return HttpNotFound();
            }
            return View(dutyModel);
        }

        // POST: DutyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Sil(id);
            service.Kaydet();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
