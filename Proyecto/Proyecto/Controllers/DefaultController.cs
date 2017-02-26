using Datos;
using Datos.Model;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class DefaultController : Controller
    {
        private Usuario usuario =new Usuario();
        // GET: Default
        public ActionResult IndexInicio()
        {
           return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            var id = SessionHelper.GetUser();
            if (id > 0) return Redirect("~/Empleado/Index");
            return View();
        }

        public JsonResult IniciarSesion(string musuario, string password)
        {
            var rm = new ResponseModel();
            if (musuario != String.Empty && password != String.Empty)
            {
                rm = usuario.IniciarSesion(musuario, password);
                if (rm.response) rm.href = Url.Content("~/Empleado/Index");
                else rm.message = "usuario y/o contraseña invalidos";
            }
            else rm.message = "Debe ingresar usuario y contraseña";

            return Json(rm);
        }

        //[HttpPost]
        //public ActionResult IniciarSesion(string usuario,string password)
        //{

        //    return View();
        //}

        public ActionResult RegistrarCrud(int id = 0)
        {
            if (id != 0) { 
                usuario = usuario.mObtenerUser(id);
            }
            ViewBag.Roles = (new Rol()).Listar();
            return View(usuario);
        }

        //[HttpPost]
        public JsonResult Registrar(Usuario user, string repetirPass)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                if (user.Password != repetirPass && user.IdUsuario == 0)
                {
                    rm.message = "Las contraseñas deben ser iguales";
                }
                else { 
                    if (user.IdRol != 0)
                    {
                        if (user.mObtenerUsuarioResgitrado(user.Usuario1) == 0) { rm.message = "Ya existe el nombre de usuario: " + user.Usuario1; }
                        else
                        {
                            user.Password = HashHelper.MD5(user.Password);
                            user.FechaIngreso = DateTime.Now;
                            rm = user.GuardarUsuario();
                            if (rm.response)
                            {
                                rm.href = Url.Content("Index");
                            }
                        }
                    }
                    else rm.message = "Debe seleccionar un rol";
                }
            }
            else{ ViewBag.Roles = (new Rol()).Listar(); }
            return Json(rm);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
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

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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
