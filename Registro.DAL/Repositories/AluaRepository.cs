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
    public class AulaRepository : IAulas
    {
        private readonly VisitantesContext _context;
        private readonly ILogger<Aula> _logger;

        public AulaRepository(VisitantesContext context, ILogger<Aula> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Aula, bool>> filter)
        {
            return _context.Aulas.Any(filter);
        }

        public IEnumerable<Aula> GetEntities()
        {
            return _context.Aulas.ToList();
        }

        public Aula GetEntity(int entityid)
        {
            return _context.Aulas.Find(entityid);
        }

        public void Save(Aula entity)
        {
            _context.Aulas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Aula entity)
        {
            try
            {
                Aula aulaModificar = GetEntity(entity.ID);
                aulaModificar.ID= entity.ID;
                aulaModificar.Nombre = entity.Nombre;
                aulaModificar.EdificioId = entity.EdificioId;

                _context.Update(aulaModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
