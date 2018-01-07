using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio.ABC.Web.Helper
{
    public static class CloneHelper
    {
        public static object CloneObject(object obj)
        {
            if (obj != null)
            {
                Type type = obj.GetType();
                System.Reflection.MethodInfo info = type.GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (info != null)
                {
                    return info.Invoke(obj, null);
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}