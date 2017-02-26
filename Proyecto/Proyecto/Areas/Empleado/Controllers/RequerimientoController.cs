using Datos;
using Datos.Model;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Areas.Empleado.Controllers
{
    public class RequerimientoController : Controller
    {
        // GET: Empleado/Requerimiento
        private General general = new General();
        private Requerimiento requerimiento = new Requerimiento();
        private Horas horas = new Horas();

        public ActionResult Index()
        {
            List<Requerimiento> lista = new List<Requerimiento>();
            lista = requerimiento.ListarRequerimiento();
            ViewBag.listaReq = lista;
            //var variables =Requerimient
            //var json = Json(lista);

            //return View();
            return View();
        }

        private void mLlenarLsitas()
        {
            ViewBag.PrioridadList = general.Listar("001");
            ViewBag.TipoList = general.Listar("002");
            ViewBag.ProyectoList = general.Listar("003");
            ViewBag.EstadoList = general.Listar("004");
            ViewBag.UsuarioList = (new Usuario()).ListarUsuario();        
        }

        public ActionResult Crud(int id=0)
        {
            mLlenarLsitas();
            if (id > 0) { requerimiento = (new Requerimiento()).ObtenerRequerimiento(id); }
            return View(requerimiento);
        }

        public JsonResult GuardarRequerimiento(Requerimiento req)
        {
            var rm = new ResponseModel();
            rm = req.GuardarRequerimiento();
            if (rm.response) rm.href = Url.Content("~/Empleado/Requerimiento/Index");
            //if (ModelState.IsValid)
            //{
            //    var valor = "";
            //}
            //else mLlenarLsitas();
            return Json(rm);
        }

        public ActionResult Horas(int id,string name)
        {
            Horas horas = new Horas() {
                    IdRequerimiento=id
            };
            ViewBag.id = id;
            ViewBag.name = name;
            return PartialView("_Horas", horas);
        }

        public JsonResult GuardarHoras(Horas horas)
        {
            var rm = new ResponseModel();
            horas.IdUsuario = SessionHelper.GetUser();
            rm = horas.GuardarHoras();
            if (rm.response) rm.function = "OcultarModal()";//rm.href = Url.Content("~/Empleado/Index");
            return Json(rm);
        }

        public ActionResult ListarReqHoras()
        {
            List<Requerimiento> lista = new List<Requerimiento>();
            lista = requerimiento.ListarRequerimiento();
            
            ViewBag.listaReq = lista;
            return View();
        }

        public ActionResult DetalleHoras(int id)
        {
            requerimiento = requerimiento.ObtenerRequerimiento(id);
            List<Horas> hora = new List<Horas>();
            hora= horas.ObtenerHorasRequerimiento(id);
            ViewBag.Requerimiento = requerimiento;
            ViewBag.horas = hora;
            return View();
        }
    }
}