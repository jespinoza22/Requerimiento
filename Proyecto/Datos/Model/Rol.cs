namespace Datos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdRol { get; set; }

        [StringLength(512)]
        public string NombreRol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<Rol> Listar()
        {
            var listar_ = new List<Rol>();
            using (var cnx = new Context())
            {
                listar_ = cnx.Rol.OrderBy(x => x.IdRol)
                                .ToList();
            }
            return listar_;
        }
    }

 
}
