using Ejercicio.ABC.Data.Helpers;
using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Data.Repository;
using Ejercicio.ABC.Services.Exceptions;
using System;
using System.Collections.Generic;

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
            IList<Proveedor> proveedor;

            try
            {
                IRepository<Proveedor> pRepo = new NHibernateRepository<Proveedor>();
                proveedor = pRepo.GetAll();

                return proveedor;
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
        /// <param name="proveedor"></param>
        public void GuardarProveedor(Proveedor proveedor)
        {
            try
            {
                IRepository<Proveedor> pRepo = new NHibernateRepository<Proveedor>();
                pRepo.Save(proveedor);
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
            Proveedor proveedor;

            try
            {
                IRepository<Proveedor> pRepo = new NHibernateRepository<Proveedor>();
                proveedor = pRepo.Get(id);

                return proveedor;
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
        /// <param name="proveedor"></param>
        public void ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                IRepository<Proveedor> pRepo = new NHibernateRepository<Proveedor>();
                pRepo.Update(proveedor);
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
            Proveedor proveedor;

            try
            {
                IRepository<Proveedor> pRepo = new NHibernateRepository<Proveedor>();
                proveedor = pRepo.Get(id);

                proveedor.Estatus = false;

                pRepo.Update(proveedor);
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
                throw new DataAccessException(DataAccessException.EXCEPTION, e);
            }
        }
    }
}