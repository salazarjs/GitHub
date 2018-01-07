using Ejercicio.ABC.Data.Helpers;
using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Data.Repository;
using Ejercicio.ABC.Services.Exceptions;
using System;
using System.Collections.Generic;

namespace Ejercicio.ABC.Services.Integration.DAO
{
    public class UsuarioDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener un usuario.
        /// </summary>
        /// <returns></returns>
        public IList<Usuario> ObtenerUsuarios()
        {
            IList<Usuario> usuario;

            try
            {
                IRepository<Usuario> uRepo = new NHibernateRepository<Usuario>();
                usuario = uRepo.GetAll();

                return usuario;
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para guardar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        public void GuardarUsuario(Usuario usuario)
        {
            try
            {
                IRepository<Usuario> uRepo = new NHibernateRepository<Usuario>();
                uRepo.Save(usuario);
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para obtener un usuario por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario;

            try
            {
                IRepository<Usuario> uRepo = new NHibernateRepository<Usuario>();
                usuario = uRepo.Get(id);

                return usuario;
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        public void ActualizarUsuario(Usuario usuario)
        {
            try
            {
                IRepository<Usuario> uRepo = new NHibernateRepository<Usuario>();
                uRepo.Update(usuario);
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para eliminar un usuario.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarUsuario(int id)
        {
            Usuario usuario;

            try
            {
                IRepository<Usuario> uRepo = new NHibernateRepository<Usuario>();
                usuario = uRepo.Get(id);

                usuario.Estatus = false;

                uRepo.Update(usuario);
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }
    }
}