using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Categoria
    {
        private CL_Categoria datos = new CL_Categoria();

        public List<Categoria> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Categoria obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (mensaje != "")
                return false;

            obj.Disponible = true;
            obj.FechaRegistro = DateTime.Now;

            return datos.Registrar(obj);
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Categoria == 0)
                mensaje += "ID inválido\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            mensaje = "";

            if (id == 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(id);
        }
    }
}
