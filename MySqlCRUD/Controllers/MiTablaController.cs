using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MySqlCRUD.Models;
using MySqlCRUD.Models.ViewModels;

namespace MySqlCRUD.Controllers
{
   
    public class MiTablaController : Controller
    {
        private readonly int _RegistrosPorPagina = 10;
        private List<mitabla> _Datos;
        private PaginadorGenerico<mitabla> _PaginadorDatos;
        // GET: MiTabla


        public ActionResult IndexBusqueda(string buscar, int pagina = 1)
        {
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            // FILTRO DE BÚSQUEDA
            using (crudEntities1 DB = new crudEntities1())
            {
                // Recuperamos el 'DbSet' completo
                _Datos = DB.mitabla.ToList();

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar))
                {
                    foreach (var item in buscar.Split(new char[] { ' ' },
                             StringSplitOptions.RemoveEmptyEntries))
                    {
                        _Datos = _Datos.Where(x => x.nombre.Contains(item) ||
                                                      x.correo.Contains(item))
                                                      .ToList();
                    }
                }
            }
            // SISTEMA DE PAGINACIÓN
            using (crudEntities1 DB = new crudEntities1())
            {
                // Número total de registros de la tabla Customers
                _TotalRegistros = _Datos.Count();
                // Obtenemos la 'página de registros' de la tabla Customers
                _Datos = _Datos.OrderBy(x => x.nombre)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
                // Número total de páginas de la tabla Customers
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorDatos = new PaginadorGenerico<mitabla>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaActual = buscar,
                    Resultado = _Datos
                };
            }

            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorDatos);

        }
        public ActionResult Index()
        {
            
            List<ListMitablaViewModel> oLst;
            using (crudEntities1 db = new crudEntities1())
            {
                        oLst = (from d in db.mitabla
                                 select new ListMitablaViewModel
                                 {
                                     Id = d.id,
                                     Nombre = d.nombre,
                                     Correo = d.correo,
                                 }).ToList();
            }
            return View(oLst);

            

        
        }
        public ActionResult Nuevo()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(MitablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crudEntities1 db = new crudEntities1())
                    {
                        var oTobla = new mitabla();
                        oTobla.correo = model.Correo;
                        oTobla.fecha_nacimiento = model.Fecha_Nacimiento;
                        oTobla.nombre = model.Nombre;

                        db.mitabla.Add(oTobla);
                        db.SaveChanges();

                        return Redirect("~/MiTabla/IndexBusqueda");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            MitablaViewModel model = new MitablaViewModel();
            if (Id == 0)
            {
                return HttpNotFound();
            }
            using (crudEntities1 db = new crudEntities1())
            {
                var oDatos = db.mitabla.Find(Id);
                if (oDatos == null)
                {
                    return Redirect("~/MiTabla/IndexBusqueda");
                }
                model.Correo = oDatos.correo;
                model.Nombre = oDatos.nombre;
                //model.Fecha_Nacimiento = Convert.ToDateTime(oDatos.fecha_nacimiento.ToString("yyyy-mm-dd"));
                model.Id = oDatos.id;

                

            }
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MitablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crudEntities1 db = new crudEntities1())
                    {
                        var oTobla = db.mitabla.Find(model.Id);
                        oTobla.correo = model.Correo;
                        oTobla.fecha_nacimiento = model.Fecha_Nacimiento;
                        oTobla.nombre = model.Nombre;

                        db.Entry(oTobla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return Redirect("~/MiTabla/IndexBusqueda");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return View(model);
        }

        [HttpGet]
        public ActionResult Borrar(int Id)
        {
            if (Id == 0)
            {

            }
            //MitablaViewModel modelo = new MitablaViewModel();
            //List<ListMitablaViewModel> oLst;
            using (crudEntities1 db = new crudEntities1())
            {
                var oDatos = db.mitabla.Find(Id);

                db.mitabla.Remove(oDatos);
                db.SaveChanges();

                //if (oDatos != null)
                //{
                //    db.mitabla.Remove(oDatos);
                //    db.SaveChanges();
                    
                //}


                //oLst = (from d in db.mitabla
                //        select new ListMitablaViewModel
                //        {
                //            Id = d.id,
                //            Nombre = d.nombre,
                //            Correo = d.correo,
                //        }).ToList();


                //modelo.Correo = oDatos.correo;
                //modelo.Fecha_Nacimiento = oDatos.fecha_nacimiento;
                //modelo.Nombre = oDatos.nombre;
                //modelo.Id = oDatos.id;
            }


            return Redirect("~/MiTabla/IndexBusqueda");
            //return View(oLst);
        }
        
    }
}