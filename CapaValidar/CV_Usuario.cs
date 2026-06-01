using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaMo;
using CapaLogica;

namespace CapaValidar
{
    public class CV_Usuario
    {
        private CL_Usuario datos = new CL_Usuario();

        public List<Usuario> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Usuario obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.Nombre_usuario))
                mensaje += "El nombre de usuario es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.APaterno))
                mensaje += "El apellido paterno es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.AMaterno))
                mensaje += "El apellido materno es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";
            else
            {
                obj.Correo = obj.Correo.Trim();

                if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                    mensaje += "Formato de correo inválido\n";
                else if (datos.ExisteCorreo(obj.Correo))
                    mensaje += "Este correo ya está registrado\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Contraseña))
                mensaje += "La contraseña es obligatoria\n";

            if (string.IsNullOrWhiteSpace(obj.Rol))
                mensaje += "El rol es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.EstadoUsuario))
                mensaje += "El estado del usuario es obligatorio\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Usuario <= 0)
                mensaje += "ID inválido\n";

            if (string.IsNullOrWhiteSpace(obj.Nombre_usuario))
                mensaje += "El nombre de usuario es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.APaterno))
                mensaje += "El apellido paterno es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.AMaterno))
                mensaje += "El apellido materno es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";
            else
            {
                obj.Correo = obj.Correo.Trim();

                if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                    mensaje += "Formato de correo inválido\n";
                else if (datos.ExisteCorreo(obj.Correo))
                    mensaje += "Este correo ya está registrado\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Contraseña))
                mensaje += "La contraseña es obligatoria\n";

            if (string.IsNullOrWhiteSpace(obj.Rol))
                mensaje += "El rol es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.EstadoUsuario))
                mensaje += "El estado del usuario es obligatorio\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idUsuario, out string mensaje)
        {
            mensaje = "";

            if (idUsuario <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            if (!datos.ExisteUsuario(idUsuario))
            {
                mensaje = "El usuario no existe";
                return false;
            }

            return datos.Eliminar(idUsuario);
        }
    }
}
