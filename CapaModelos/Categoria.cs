using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Categoria
    {
        public int Id_Categoria { get; set; }

        public string Id_Descripcion { get; set; } = "";

        public bool Disponible { get; set; } = true;
    }
}
