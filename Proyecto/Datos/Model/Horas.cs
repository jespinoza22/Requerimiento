namespace Datos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Horas
    {
        [Key]
        public int IdRegistroHora { get; set; }

        [StringLength(512)]
        public string Detalle { get; set; }

        [Column("Horas")]
        public decimal? Horas1 { get; set; }

        public int? IdRequerimiento { get; set; }

        public int? IdUsuario { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Requerimiento Requerimiento { get; set; }


        public ResponseModel GuardarHoras()
        {
            var rm = new ResponseModel();
            try
            {
                using (var cnx = new Context())
                {
                    if (this.IdRegistroHora > 0) cnx.Entry(this).State = EntityState.Modified;
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
        public List<Horas> ListarHoras()
        {
            var horas = new List<Horas>();
            using (var cnx = new Context())
            {
                horas = cnx.Horas.OrderBy(x => x.IdRegistroHora)
                                       .ToList();
            }
            return horas;
        }

        public List<Horas> ObtenerHorasRequerimiento(int id)
        {
            var horas = new List<Horas>();
            using (var cnx = new Context())
            {
                horas = cnx.Horas.OrderBy(x => x.IdRegistroHora)
                                               .Where(x => x.IdRequerimiento == id)
                                               .ToList();
            }
            return horas;
        }
    }
}
