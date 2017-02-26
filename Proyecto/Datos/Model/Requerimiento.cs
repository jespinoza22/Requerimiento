namespace Datos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Requerimiento")]
    public partial class Requerimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requerimiento()
        {
            Horas = new HashSet<Horas>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdRequerimiento { get; set; }

        [StringLength(512)]
        [Required]
        public string Descripcion { get; set; }

        [StringLength(512)]
        [Required]
        public string Detalle { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [StringLength(512)]
        [Required]
        public string Prioridad { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }

        [StringLength(512)]
        [DisplayName("Tipo")]
        [Required]
        public string TipoRequerimiento { get; set; }

        [StringLength(512)]
        [DisplayName("Archivo")]
        public string ArchivoAdjunto { get; set; }

        [StringLength(512)]
        public string AliasArchivo { get; set; }

        [StringLength(512)]
        [DisplayName("Estado")]
        [Required]
        public string Estado { get; set; }

        [DisplayName("Entrega")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntrega { get; set; }

        public decimal? Avance { get; set; }

        [DisplayName("Estimado")]
        [Required]
        public decimal? TiempoEstimado { get; set; }

        [StringLength(512)]
        public string Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horas> Horas { get; set; }

        public virtual Usuario Usuario { get; set; }

        public ResponseModel GuardarRequerimiento()
        {
            var rm = new ResponseModel();
            try
            {
                using (var cnx = new Context())
                {
                    this.FechaCreacion = DateTime.Now;
                    if (this.IdRequerimiento > 0) cnx.Entry(this).State = EntityState.Modified;
                    else cnx.Entry(this).State = EntityState.Added;
                    cnx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return rm;
        }

        public List<Requerimiento> ListarRequerimiento()
        {
            var reque = new List<Requerimiento>();
            using (var cnx = new Context())
            {
                reque = cnx.Requerimiento.OrderBy(x => x.IdRequerimiento)
                                         .Include("Usuario")
                                         .ToList();                         
            }
            return reque;
        }

        public Requerimiento ObtenerRequerimiento(int id)
        {
            var requerimiento = new Requerimiento();
            using (var cnx = new Context())
            {
                requerimiento = cnx.Requerimiento.OrderBy(x => x.IdRequerimiento)
                                               .Where(x => x.IdRequerimiento == id)
                                               .Include("Usuario")
                                               .FirstOrDefault();
            }
            return requerimiento;
        }

        public List<Requerimiento> ListaHorasRequerimiento()
        {
            var reque = new List<Requerimiento>();
            using (var cnx = new Context())
            {
                reque = cnx.Requerimiento.OrderBy(x => x.IdRequerimiento)
                                       .Include("Usuario")
                                       .ToList();
            }
            return reque;
        }
    }
}
