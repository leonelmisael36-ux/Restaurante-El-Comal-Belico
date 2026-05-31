using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    internal class CV_Tipo_Platillo
    {
        private CL_Tipo_Platillo datos = new CL_Tipo_Platillo();

        public List<Tipo_Platillo> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Tipo_Platillo obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Platillo <= 0)
                mensaje += "El platillo es obligatorio\n";
            else if (!datos.ExistePlatillo(obj.Id_Platillo))
                mensaje += "El platillo no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Tamaño))
                mensaje += "El tamaño es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.TipoPreparacion))
                mensaje += "El tipo de preparación es obligatorio\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Tipo_Platillo obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Tipo <= 0)
                mensaje += "ID inválido\n";
            else if (!datos.ExisteTipo(obj.Id_Tipo))
                mensaje += "El tipo de platillo no existe\n";

            if (obj.Id_Platillo <= 0)
                mensaje += "El platillo es obligatorio\n";
            else if (!datos.ExistePlatillo(obj.Id_Platillo))
                mensaje += "El platillo no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Tamaño))
                mensaje += "El tamaño es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.TipoPreparacion))
                mensaje += "El tipo de preparación es obligatorio\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idTipo, out string mensaje)
        {
            mensaje = "";

            if (idTipo <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            if (!datos.ExisteTipo(idTipo))
            {
                mensaje = "El tipo de platillo no existe";
                return false;
            }

            return datos.Eliminar(idTipo);
        }
    }
}
