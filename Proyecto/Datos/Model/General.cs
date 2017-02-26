namespace Datos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("General")]
    public partial class General
    {
        [Key]
        public int IdGeneral { get; set; }

        [StringLength(512)]
        public string Codigo { get; set; }

        [StringLength(512)]
        public string Descripcion { get; set; }

        [StringLength(512)]
        public string Valor { get; set; }

        public List<General> Listar(string codigo)
        {
            var listar = new List<General>();
            using (var cnx = new Context()) {
                listar = cnx.General.OrderBy(x => x.IdGeneral)
                                    .Where(x=>x.Codigo==codigo)
                                    .ToList();

            }
            return listar;
        }
    }
}
