using Ejercicio.ABC.Data.Helpers;
using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using NHibernate;
using NHibernate.Exceptions;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio.ABC.Services.Integration.DAO
{
    public class ProveedorDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener una lista de proveedores.
        /// </summary>
        /// <returns></returns>
        public IList<Proveedor> ObtenerProveedores()
        {
            IList<Proveedor> Proveedor;

            try
            {
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    Proveedor = session.Query<Proveedor>().Where(x => x.Estatus == true).ToList();
                }

                return Proveedor;
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para guardar un proveedor.
        /// </summary>
        /// <param name="Proveedor"></param>
        public void GuardarProveedor(Proveedor Proveedor)
        {
            try
            {
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Proveedor);
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
        /// Método para obtener un proveedor por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Proveedor ObtenerProveedorPorId(int id)
        {
            Proveedor Proveedor;

            try
            {
                ISession session = FluentNhibernateHelper.OpenSession();
                return Proveedor = session.Query<Proveedor>().Where(b => b.ProveedorID == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }

        /// <summary>
        /// Método para actualizar un proveedor.
        /// </summary>
        /// <param name="Proveedor"></param>
        public void ActualizarProveedor(Proveedor Proveedor)
        {
            try
            {
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Proveedor);
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
        /// Método para eliminar un proveedor.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarProveedor(int id)
        {
            try
            {
                using (var session = FluentNhibernateHelper.OpenSession())
                {
                    Proveedor Proveedor = session.Get<Proveedor>(id);

                    Proveedor.Estatus = false;

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Proveedor);
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