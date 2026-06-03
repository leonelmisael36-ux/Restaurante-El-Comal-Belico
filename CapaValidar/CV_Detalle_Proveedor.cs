using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Detalle_Proveedor
    {
        private CL_Detalle_Proveedor datos = new CL_Detalle_Proveedor();
        private CL_Inventario datosInventario = new CL_Inventario();

        public List<Detalle_Proveedor> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Detalle_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (obj.Id_Ingrediente <= 0)
                mensaje += "El ingrediente es obligatorio\n";
            else if (!datos.ExisteIngrediente(obj.Id_Ingrediente))
                mensaje += "El ingrediente no existe\n";

            if (obj.Cantidad <= 0)
                mensaje += "La cantidad debe ser mayor a 0\n";

            if (!datosInventario.ExisteIngredienteInventario(obj.Id_Ingrediente))
            {
                mensaje = "Debes registrar este ingrediente en inventario primero";
                return false;
            }

            if (obj.Fecha == default)
                mensaje += "La fecha no es válida\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Detalle_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_DetalleProveedor <= 0)
                mensaje += "ID de detalle inválido\n";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (obj.Id_Ingrediente <= 0)
                mensaje += "El ingrediente es obligatorio\n";
            else if (!datos.ExisteIngrediente(obj.Id_Ingrediente))
                mensaje += "El ingrediente no existe\n";

            if (obj.Cantidad <= 0)
                mensaje += "La cantidad debe ser mayor a 0\n";

            if (obj.Fecha == default)
                mensaje += "La fecha no es válida\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idDetalleProveedor, out string mensaje)
        {
            mensaje = "";

            if (idDetalleProveedor <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idDetalleProveedor);
        }
    }
}
