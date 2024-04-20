using Microsoft.Extensions.Logging;
using Registro.DAL.Context;
using Registro.DAL.Entities;
using Registro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Registro.DAL.Repositories
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly VisitantesContext _context;
      

        public UsuariosRepository(VisitantesContext context, ILogger<Usuarios> logger)
        {
            _context = context;
        
        }

        public bool Exists(Expression<Func<Usuarios, bool>> filter)
        {
            return _context.Usuarios.Any(filter);
        }

        public IEnumerable<Usuarios> GetEntities()
        {
            return _context.Usuarios.ToList();
        }

        public Usuarios GetEntity(int entityid)
        {
            return _context.Usuarios.Find(entityid);
        }

        public void Remove(Usuarios entity)
        {
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Usuarios entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Usuarios entity)
        {
            try
            {
                Usuarios usuarioModificar = GetEntity(entity.Id);
                usuarioModificar.Nombre = entity.Nombre;
                usuarioModificar.Contraseña = entity.Contraseña;
                usuarioModificar.Admin = entity.Admin;

                _context.Update(usuarioModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
       
            }


        }
    }
}
