using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Areas.Empleado.Controllers
{
    public class IndexController : Controller
    {
        // GET: Empleado/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleado/Index/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleado/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CerrarSession()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }

        // POST: Empleado/Index/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleado/Index/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Index/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
