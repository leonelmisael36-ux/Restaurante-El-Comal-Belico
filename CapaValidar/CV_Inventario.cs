using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Inventario
    {
        private CL_Inventario datos = new CL_Inventario();

        public List<Inventario> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Inventario obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Ingrediente <= 0)
                mensaje += "El ingrediente es obligatorio\n";
            else if (!datos.ExisteIngrediente(obj.Id_Ingrediente))
                mensaje += "El ingrediente no existe\n";

            if (obj.Stock < 0)
                mensaje += "El stock no puede ser negativo\n";

            if (obj.StockMinimo < 0)
                mensaje += "El stock mínimo no puede ser negativo\n";

            if (obj.FechaRegistro == default)
                mensaje += "La fecha no es válida\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Inventario obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Inventario <= 0)
                mensaje += "ID de inventario inválido\n";

            if (obj.Id_Ingrediente <= 0)
                mensaje += "El ingrediente es obligatorio\n";
            else if (!datos.ExisteIngrediente(obj.Id_Ingrediente))
                mensaje += "El ingrediente no existe\n";

            if (obj.FechaRegistro == default)
                mensaje += "La fecha no es válida\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idInventario, out string mensaje)
        {
            mensaje = "";

            if (idInventario <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idInventario);
        }
    }
}
