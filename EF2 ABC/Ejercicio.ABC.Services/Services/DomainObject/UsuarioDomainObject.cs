using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using Ejercicio.ABC.Services.Integration.DAO;
using System;
using System.Collections.Generic;

namespace Ejercicio.ABC.Services.Services.DomainObject
{
    public class UsuarioDomainObject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener una lista de usuarios.
        /// </summary>
        /// <returns></returns>
        public IList<Usuario> ObtenerUsuarios()
        {
            var usuarioDao = new UsuarioDAO();
            try
            {
                return usuarioDao.ObtenerUsuarios();
            }
            catch (DataAccessException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw new BusinessLogicException(BusinessLogicException.EXCEPTION, ex);
            }
        }

        /// <summary>
        /// Método para guardar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        public void GuardarUsuario(Usuario usuario)
        {
            var usuarioDao = new UsuarioDAO();
            try
            {
                usuarioDao.GuardarUsuario(usuario);
            }
            catch (DataAccessException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw new BusinessLogicException(BusinessLogicException.EXCEPTION, ex);
            }
        }

        /// <summary>
        /// Método para obtener un usuario por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioPorId(int id)
        {
            var usuarioDao = new UsuarioDAO();
            try
            {
                return usuarioDao.ObtenerUsuarioPorId(id);
            }
            catch (DataAccessException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw new BusinessLogicException(BusinessLogicException.EXCEPTION, ex);
            }
        }

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        public void ActualizarUsuario(Usuario usuario)
        {
            var usuarioDao = new UsuarioDAO();
            try
            {
                usuarioDao.ActualizarUsuario(usuario);
            }
            catch (DataAccessException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw new BusinessLogicException(BusinessLogicException.EXCEPTION, ex);
            }
        }

        /// <summary>
        /// Método para eliminar un usuario.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarUsuario(int id)
        {
            var usuarioDao = new UsuarioDAO();
            try
            {
               usuarioDao.EliminarUsuario(id);
            }
            catch (DataAccessException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw new BusinessLogicException(BusinessLogicException.EXCEPTION, ex);
            }
        }
    }
}