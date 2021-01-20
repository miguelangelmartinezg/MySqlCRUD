using MySqlCRUD.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySqlCRUD.Models.ViewModels
{
    public class HijosModels
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        
        public int Idhijos { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} No Puede Tener Más de {1} Caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} No Puede Tener Más de {1} Caracteres.")]
        public string  Apellidos { get; set; }

        [Display(Name = "Fecha Cumpleaño")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        
        public DateTime Fechanac { get; set; }

        [Display(Name = "Dirccion")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} No Puede Tener Más de {1} Caracteres.")]
        public string Direccion { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El Campo {0} Es Obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} No Puede Tener Más de {1} Caracteres.")]
        public int Edad { get; set; }
        public EnumSexo Sexo { get; set; }

        public int Idmitabla { get; set; }

        

    }
}