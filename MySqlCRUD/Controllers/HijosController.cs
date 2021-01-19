using MySqlCRUD.Models;
using MySqlCRUD.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlCRUD.Controllers
{
    public class HijosController : Controller
    {
        private readonly int _RegistrosPorPagina = 10;
        private List<hijos> _Datos;
        private PaginadorGenerico<hijos> _PaginadorDatos;
        // GET: Hijos
        public ActionResult Index(string buscar, int pagina = 1)
        {
            //List<MitablaViewModel> oList = null;
            //using (crudEntities1 DB = new crudEntities1())
            //{
            //    oList = (from d in DB.mitabla
            //             select new MitablaViewModel
            //             {
            //                 Id = DB.id,
            //                 Nombre = DB.nombre

            //             });


            //}
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            // FILTRO DE BÚSQUEDA
            using (crudEntities1 DB = new crudEntities1())
            {
                // Recuperamos el 'DbSet' completo
                _Datos = DB.hijos.ToList();

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar))
                {
                    foreach (var item in buscar.Split(new char[] { ' ' },
                             StringSplitOptions.RemoveEmptyEntries))
                    {
                        _Datos = _Datos.Where(x => x.nombre.Contains(item) ||
                                                      x.apellidos.Contains(item))
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
                _PaginadorDatos = new PaginadorGenerico<hijos>()
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

        public ActionResult Grabar()
        {
            return View();
        }
        public ActionResult Grabar(HijosModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
    }
}