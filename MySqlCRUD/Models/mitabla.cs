//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySqlCRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mitabla
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mitabla()
        {
            this.hijos = new HashSet<hijos>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hijos> hijos { get; set; }
    }
}
