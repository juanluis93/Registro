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
    public class EdificioRepository : IEdificios
    {
        private readonly VisitantesContext _context;
        private readonly ILogger<Edificio> _logger;

        public EdificioRepository(VisitantesContext context, ILogger<Edificio> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Edificio, bool>> filter)
        {
            return _context.Edificios.Any(filter);
        }

        public IEnumerable<Edificio> GetEntities()
        {
            return _context.Edificios.ToList();
        }

        public Edificio GetEntity(int entityid)
        {
            return _context.Edificios.Find(entityid);
        }

        public void Save(Edificio entity)
        {
            _context.Edificios.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Edificio entity)
        {
            try
            {
                Edificio edificioModificar = GetEntity(entity.ID);
                edificioModificar.ID = entity.ID;
                edificioModificar.Direccion = entity.Direccion;
            
                _context.Update(edificioModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
