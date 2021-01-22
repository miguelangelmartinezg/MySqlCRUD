using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySqlCRUD.Models;
using MySqlCRUD.Models.ViewModels;


namespace MySqlCRUD.Helpers
{
    public class LlenaCombos2
    {
        public IEnumerable<SelectListItem> GetComboPadres()
        {
            //List<SelectListItem> oList = null;
            List<PadresViewModel> oPadres = null;
            using (crudEntities1 DB = new crudEntities1())
            {


               
                oPadres = (from d in DB.mitabla
                           select new PadresViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre
                           }).ToList();

            }
            List<SelectListItem> oList = oPadres.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.Id.ToString(),

                };
               
            });
            oList.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Registro]",
                Value = "0"
            });
            return oList;
        }
    }
}