using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySqlCRUD.Models.ViewModels;
using MySqlCRUD.Models;

namespace MySqlCRUD.Helpers
{
    public class Convert_Model_ViewModel
    {
        LlenaCombos oLlenaCombo = new LlenaCombos();
        public HijosModels ConvertToModel(HijosViewModels model)
        {
            int nIdPadre = 0;
            using (crudEntities1 db = new crudEntities1())
            {
                var oDato = db.hijos.Find(model.PadresId);
                nIdPadre = oDato.idmitabla;
            }
            return new HijosModels
            {
                Apellidos = model.Apellidos,
                Direccion = model.Direccion,
                Edad = model.Edad,
                Fechanac = model.Fechanac,
                Idhijos = model.Idhijos,               
                Idmitabla = nIdPadre,
                Nombre = model.Nombre,
                Sexo = model.Sexo
            };

            
        }

        public HijosViewModels ConvertToViewModel(HijosModels oHijos)
        {

            return new HijosViewModels
            {
                Padres = oLlenaCombo.GetComboPadres(),
                Apellidos = oHijos.Apellidos,
                Direccion = oHijos.Direccion,
                Edad = oHijos.Edad,
                Fechanac = oHijos.Fechanac,
                Idhijos = oHijos.Idhijos,
                Idmitabla = oHijos.Idmitabla,
                PadresId = oHijos.Idmitabla,
                Nombre = oHijos.Nombre,
                Sexo = oHijos.Sexo
            };
        }
    }
}