using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySqlCRUD.Models;
using MySqlCRUD.Models.ViewModels;

namespace MySqlCRUD.Helpers
{
    public class LlenaCombos
    {
        /*
        public IEnumerable<SelectListItem> GetComboPadres()
        {
            List<SelectListItem> oList = null;
            using (crudEntities1 DB = new crudEntities1())
            {
                
                //oList = DB.mitabla.Select(d => new SelectListItem
                //{
                //    Text = d.nombre,
                //    Value = d.id.ToString()
                //}).OrderBy(d => d.Text)
                //    .ToList();

                //oList.Insert(0, new SelectListItem
                //{
                //    Text = "Seleccione un Registro",
                //    Value = "0"
                //});


                List <PadresViewModel> oPadres = null;
                oPadres = (from d in DB.mitabla
                         select new PadresViewModel
                         {
                             Id = d.id,
                             Nombre = d.nombre
                         }).ToList();
                oList = oPadres.ConvertAll(d =>
                {
                    new SelectListItem(
                    {
                        Text = d.Nombre.ToString(),
                        Value = d.Id.ToString(),

                        oList.Insert(0, new SelectListItem
                        {
                            Text = "Seleccione un Registro",
                            Value = "0"
                        })
                     })
                        

               
                });
                
            }

            return oList;
        }
    */
    }
}