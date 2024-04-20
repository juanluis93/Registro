using Microsoft.Identity.Client;
using Registro.BLL.Contracts;
using Registro.BLL.Core;
using Registro.BLL.Dtos;
using Registro.BLL.Models;
using Registro.DAL.Context;
using Registro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Services
{
   public class AulaService :IAulaService
    {
        private readonly IAulas _aulaRepository;
       
        public AulaService(IAulas aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public ServiceResult GetAll()
        {
           ServiceResult result = new ServiceResult();
            try
            {
                var query = (from Aula in this._aulaRepository.GetEntities()
                             select new AulaModel
                             {
                                 ID = Aula.ID,
                                 EdificioId = Aula.EdificioId,
                                 Nombre = Aula.Nombre,

                             }
                ).ToList();
                result.Data = query;
            }
            catch(System.Exception ex) 
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Aula {ex}";
            
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Registro.DAL.Entities.Aula aula = _aulaRepository.GetEntity(Id);
                AulaModel aulaModel = new AulaModel
                {
                    ID = aula.ID,
                    EdificioId = aula.EdificioId,
                    Nombre = aula.Nombre
                };
                result.Data = aulaModel;
               }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Aula {ex}"; 
            }
            return result;
        }

        public void Save(AulaDto aulaSave)
        {
            throw new NotImplementedException();
        }

        public void Update(AulaDto aulaUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
