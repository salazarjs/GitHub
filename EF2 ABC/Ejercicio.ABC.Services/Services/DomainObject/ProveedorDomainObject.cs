using Ejercicio.ABC.Data.Models;
using Ejercicio.ABC.Services.Exceptions;
using Ejercicio.ABC.Services.Integration.DAO;
using System;
using System.Collections.Generic;

namespace Ejercicio.ABC.Services.Services.DomainObject
{
    public class ProveedorDomainObject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Método para obtener una lista de proveedores.
        /// </summary>
        /// <returns></returns>
        public IList<Proveedor> ObtenerProveedores()
        {
            var ProveedorDao = new ProveedorDAO();
            try
            {
                return ProveedorDao.ObtenerProveedores();
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
        /// Método para guardar un proveedor.
        /// </summary>
        /// <param name="Proveedor"></param>
        public void GuardarProveedor(Proveedor Proveedor)
        {
            var ProveedorDao = new ProveedorDAO();
            try
            {
                ProveedorDao.GuardarProveedor(Proveedor);
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
        /// Método para obtener un proveedor por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Proveedor ObtenerProveedorPorId(int id)
        {
            var ProveedorDao = new ProveedorDAO();
            try
            {
                return ProveedorDao.ObtenerProveedorPorId(id);
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
        /// Método para actualizar un proveedor.
        /// </summary>
        /// <param name="Proveedor"></param>
        public void ActualizarProveedor(Proveedor Proveedor)
        {
            var ProveedorDao = new ProveedorDAO();
            try
            {
                ProveedorDao.ActualizarProveedor(Proveedor);
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
        /// Método para eliminar un proveedor.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarProveedor(int id)
        {
            var ProveedorDao = new ProveedorDAO();
            try
            {
                ProveedorDao.EliminarProveedor(id);
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