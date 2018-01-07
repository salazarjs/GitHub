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
            var proveedorDao = new ProveedorDAO();

            var proveedoresActivos = new List<Proveedor>();

            try
            {
                var proveedores = proveedorDao.ObtenerProveedores();

                foreach (var proveedor in proveedores)
                {
                    if (proveedor.Estatus)
                    {
                        proveedoresActivos.Add(proveedor);
                    }
                }

                return proveedoresActivos;
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
        /// <param name="proveedor"></param>
        public void GuardarProveedor(Proveedor proveedor)
        {
            var proveedorDao = new ProveedorDAO();

            try
            {
                proveedorDao.GuardarProveedor(proveedor);
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
            var proveedorDao = new ProveedorDAO();

            try
            {
                return proveedorDao.ObtenerProveedorPorId(id);
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
        /// <param name="proveedor"></param>
        public void ActualizarProveedor(Proveedor proveedor)
        {
            var proveedorDao = new ProveedorDAO();

            try
            {
                proveedorDao.ActualizarProveedor(proveedor);
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
            var proveedorDao = new ProveedorDAO();

            try
            {
                proveedorDao.EliminarProveedor(id);
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