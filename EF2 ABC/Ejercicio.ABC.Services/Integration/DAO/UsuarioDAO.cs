using Ejercicio.ABC.Data.Helpers;
using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    //Se obtienen todos los usuarios activos.
                    usuario = session.Query<Usuario>().Where(x => x.Estatus == true).ToList();
                }

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
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(usuario);
                        transaction.Commit();
                    }
                }
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
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    usuario = session.Query<Usuario>().Where(b => b.UsuarioID == id).FirstOrDefault();
                }

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
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(usuario);
                        transaction.Commit();
                    }
                }
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
            try
            {
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    Usuario usuario = session.Get<Usuario>(id);

                    //Borrado logico.
                    usuario.Estatus = false;

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(usuario);
                        trans.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }
    }
}