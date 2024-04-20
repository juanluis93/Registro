using Registro.BLL.Contracts;
using Registro.BLL.Core;
using Registro.BLL.Models;
using Registro.DAL.Entities;
using Registro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Services
{
    public class EdificioService : IEdificioService
    {
        private readonly IEdificios _edificios;
        public EdificioService (IEdificios edificios)
        {
            _edificios = edificios;
        }
        public ServiceResult GetAll()
        {
         ServiceResult result = new ServiceResult();
            try
            {
                var query = (from edificio in this._edificios.GetEntities()
                             select new EdificioModel
                             {
                                 Nombre = edificio.Nombre,
                                 ID = edificio.ID

                             }
                             ).ToList();
                result.Data = query;
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error En Edificio {ex}";
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
         ServiceResult result= new ServiceResult();
            try
            {
                Registro.DAL.Entities.Edificio edificio = _edificios.GetEntity(Id);
                EdificioModel edificioModel = new EdificioModel
                {
                    Nombre = edificio.Nombre,
                    ID = edificio.ID
                };
                result.Data = edificioModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error Edificio {ex}";
            }
            return result;
        }
    }
}
