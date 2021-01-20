using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySqlCRUD.Models.ViewModels
{
    public class HijosModels
    {
        public int Idhijos { get; set; }
        public string Nombre { get; set; }
        public string  Apellidos { get; set; }
        public DateTime Fechanac { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        public int Idmitabla { get; set; }

    }
}