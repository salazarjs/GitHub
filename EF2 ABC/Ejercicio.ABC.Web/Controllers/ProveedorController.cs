using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using Ejercicio.ABC.Services.Services.DomainObject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ejercicio.ABC.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener una lista de proveedores.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<Proveedor> proveedor;
            var proveedorDo = new ProveedorDomainObject();

            try
            {
                proveedor = proveedorDo.ObtenerProveedores();
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "read");
            }

            return View(proveedor);
        }

        public ActionResult Crear()
        {
            return View("CrearProveedor");
        }

        /// <summary>
        /// Método para guardar un proveedor.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guardar(FormCollection collection)
        {
            var proveedorDo = new ProveedorDomainObject();
            var proveedor = new Proveedor();

            try
            {
                if (ModelState.IsValid)
                {
                    proveedor.RFC = collection["RFC"].ToString();
                    proveedor.Nombre = collection["Nombre"].ToString();
                    proveedor.Estatus = true;

                    proveedorDo.GuardarProveedor(proveedor);
                }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "read");
            }
        }

        public ActionResult Actualizar(int id)
        {
            var proveedorDo = new ProveedorDomainObject();
            var proveedor = new Proveedor();

            try
            {
                proveedor = proveedorDo.ObtenerProveedorPorId(id);
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "read");
            }

            ViewBag.SubmitAction = "Actualizar";
            return View("ActualizarProveedor", proveedor);
        }

        /// <summary>
        /// Método para actualizar un proveedor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Actualizar(int id, FormCollection collection)
        {
            var proveedorDo = new ProveedorDomainObject();
            var proveedor = new Proveedor();

            try
            {
                if (ModelState.IsValid)
                {
                    proveedor.ProveedorID = id;
                    proveedor.RFC = collection["RFC"].ToString();
                    proveedor.Nombre = collection["Nombre"].ToString();
                    proveedor.Estatus = true;

                    proveedorDo.ActualizarProveedor(proveedor);
                }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "read");
            }
        }

        /// <summary>
        /// Método para eliminar un proveedor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EliminarProveedor(int id)
        {
            var proveedorDo = new ProveedorDomainObject();

            try
            {
                proveedorDo.EliminarProveedor(id);
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "read");
            }

            return RedirectToAction("Index");
        }
    }
}