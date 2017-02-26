namespace Datos.Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Requerimiento = new HashSet<Requerimiento>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [StringLength(512)]
        public string Nombres { get; set; }

        [StringLength(512)]
        public string Apellidos { get; set; }

        [StringLength(512)]
        public string Correo { get; set; }

        public int? Telefono { get; set; }

        [StringLength(512)]
        public string Direccion { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [StringLength(512)]
        public string Password { get; set; }

        [Column("Usuario")]
        [StringLength(512)]
        public string Usuario1 { get; set; }

        public int? IdRol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requerimiento> Requerimiento { get; set; }

        public virtual Rol Rol { get; set; }


        public ResponseModel GuardarUsuario()
        {
            var rm = new ResponseModel();
            using (var cnx = new Context())
            {
                if (this.IdUsuario > 0) cnx.Entry(this).State = EntityState.Modified;
                else cnx.Entry(this).State = EntityState.Added;
                cnx.SaveChanges();
                rm.SetResponse(true);
            }
            return rm;
        }

        public Usuario mObtenerUser(int id)
        {
            var user = new Usuario();
            using (var ctx = new Context())
            {
                user = ctx.Usuario.Include("Rol")
                                   .Where(x => x.IdUsuario == id)
                                   .SingleOrDefault();
            }
            return user;
        }

        public int mObtenerUsuarioResgitrado(string nombreUser)
        {
            int valor = 0;
            using (var ctx = new Context())
            {
                var user = new Usuario();
                user = ctx.Usuario.Where(x => x.Usuario1 == nombreUser)
                                  .SingleOrDefault();
                valor = user!=null ? 1 : 0;
            }
            return valor;
        }

        public ResponseModel IniciarSesion(string nusuario, string password)
        {
            var rm = new ResponseModel();
            using (var cnx = new Context())
            {
                var user = new Usuario();
                password = HashHelper.MD5(password);
                user = cnx.Usuario.Where(x => x.Usuario1 == nusuario)
                                  .Where(x=>x.Password==password)
                                .SingleOrDefault();
                rm.SetResponse(user != null ? true : false);

                if(rm.response) SessionHelper.AddUserToSession(user.IdUsuario.ToString());
            }
            return rm;
        }


        public List<Usuario> ListarUsuario()
        {
            var usuarios = new List<Usuario>();
            using (var cnx = new Context())
            {
                usuarios = cnx.Usuario.OrderBy(x => x.IdUsuario)
                                    .ToList();
            }
            return usuarios;
        }
    }
}
