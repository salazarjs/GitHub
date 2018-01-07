using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using Ejercicio.ABC.Services.Services.DomainObject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ejercicio.ABC.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener una lista de usuarios.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<Usuario> usuario;
            var usuarioDo = new UsuarioDomainObject();

            try
            {
                usuario = usuarioDo.ObtenerUsuarios();
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(100, "read");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(100, "read");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(100, "read");
            }

            return View(usuario);
        }

        public ActionResult Crear()
        {
            return View("CrearUsuario");
        }

        /// <summary>
        /// Método para guardar un usuario.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Guardar(FormCollection collection)
        {
            var usuarioDo = new UsuarioDomainObject();
            var usuario = new Usuario();

            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Clave = collection["Clave"].ToString();
                    usuario.Nombre = collection["Nombre"].ToString();
                    usuario.Apellido = collection["Apellido"].ToString();
                    usuario.FechaNacimiento = Convert.ToDateTime(collection["FechaNacimiento"]);
                    usuario.Estatus = true;

                    usuarioDo.GuardarUsuario(usuario);
                }
                return RedirectToAction("Index");
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(200, "save");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(200, "save");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(200, "save");
            }
        }

        public ActionResult Actualizar(int id)
        {
            var usuarioDo = new UsuarioDomainObject();
            var usuario = new Usuario();

            try
            {
                usuario = usuarioDo.ObtenerUsuarioPorId(id);
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(300, "update");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(300, "update");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(300, "update");
            }

            ViewBag.SubmitAction = "Guardar";
            return View("ActualizarUsuario", usuario);
        }

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Actualizar(int id, FormCollection collection)
        {
            var usuarioDo = new UsuarioDomainObject();
            var usuario = new Usuario();

            try
            {
                if (ModelState.IsValid)
                {
                    usuario.UsuarioID = id;
                    usuario.Clave = collection["Clave"].ToString();
                    usuario.Nombre = collection["Nombre"].ToString();
                    usuario.Apellido = collection["Apellido"].ToString();
                    usuario.FechaNacimiento = Convert.ToDateTime(collection["FechaNacimiento"]);
                    usuario.Estatus = true;

                    usuarioDo.ActualizarUsuario(usuario);
                }
                return RedirectToAction("Index");
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(400, "update");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(400, "update");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(400, "update");
            }
        }

        /// <summary>
        /// Método para eliminar un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EliminarUsuario(int id)
        {
            var usuarioDo = new UsuarioDomainObject();

            try
            {
                usuarioDo.EliminarUsuario(id);
            }
            catch (DataAccessException)
            {
                return new HttpStatusCodeResult(500, "delete");
            }
            catch (BusinessLogicException)
            {
                return new HttpStatusCodeResult(500, "delete");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return new HttpStatusCodeResult(500, "delete");
            }

            return RedirectToAction("Index");
        }
    }
}