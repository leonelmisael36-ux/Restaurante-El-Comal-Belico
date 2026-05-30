using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLo;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Ingredientes
    {
        private CL_Ingredientes datos = new CL_Ingredientes();

        public List<Ingredientes> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Ingredientes obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.Nombre))
                mensaje += "El nombre del ingrediente es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Unidad))
                mensaje += "La unidad es obligatoria\n";

            if (mensaje != "")
                return false;

            obj.Nombre = obj.Nombre.Trim();

            if (datos.ExisteIngrediente(obj.Nombre))
                mensaje += "Ya existe un ingrediente con ese nombre\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Ingredientes obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Ingrediente <= 0)
                mensaje += "ID de ingrediente inválido\n";

            if (string.IsNullOrWhiteSpace(obj.Nombre))
                mensaje += "El nombre del ingrediente es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Unidad))
                mensaje += "La unidad es obligatoria\n";

            if (mensaje != "")
                return false;

            obj.Nombre = obj.Nombre.Trim();

            if (datos.ExisteIngredienteEditar(obj.Id_Ingrediente, obj.Nombre))
                mensaje += "Ya existe otro ingrediente con ese nombre\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idIngrediente, out string mensaje)
        {
            mensaje = "";

            if (idIngrediente <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idIngrediente);
        }
    }
}
