using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlCRUD.Models.ViewModels
{
    public class HijosViewModels: HijosModels
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Debes Seleccionar Un Registro")]
        [Display(Name = "Padre")]
        public int PadresId { get; set; }

        public IEnumerable<SelectListItem> Padres { get; set; }
    }
}