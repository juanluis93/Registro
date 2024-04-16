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
    public class VisitanteRepository : IVisitante
    {
        private readonly VisitantesContext _context;
        private readonly ILogger<Visitante> _logger;

        public VisitanteRepository(VisitantesContext context, ILogger<Visitante> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Visitante, bool>> filter)
        {
            return _context.Visitantes.Any(filter);
        }

        public IEnumerable<Visitante> GetEntities()
        {
            return _context.Visitantes.ToList();
        }

        public Visitante GetEntity(int entityid)
        {
            return _context.Visitantes.Find(entityid);
        }

        public void Save(Visitante entity)
        {
            _context.Visitantes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Visitante entity)
        {
            try
            {
                Visitante visitanteModificar = GetEntity(entity.ID);
                visitanteModificar.Nombre = entity.Nombre;
                visitanteModificar.Apellido = entity.Apellido;
                visitanteModificar.Carrera = entity.Carrera;
                visitanteModificar.Correo = entity.Correo;
                visitanteModificar.Edificio = entity.Edificio;
                visitanteModificar.HoraEntrada = entity.HoraEntrada;
                visitanteModificar.HoraSalida = entity.HoraSalida;
                visitanteModificar.MotivoVisita = entity.MotivoVisita;
                visitanteModificar.Aula = entity.Aula;
                visitanteModificar.Edad = entity.Edad;

                _context.Update(visitanteModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
