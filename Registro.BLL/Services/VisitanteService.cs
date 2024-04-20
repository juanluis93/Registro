using Registro.BLL.Contracts;
using Registro.BLL.Core;
using Registro.BLL.Dtos;
using Registro.BLL.Models;
using Registro.BLL.Responses.UsuarioResponses;
using Registro.BLL.Responses.VisitanteResponses;
using Registro.DAL.Interfaces;
using Registro.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Services
{
    public class VisitanteService : IVisitanteService
    {
        private readonly IVisitante _Visitanterepository;
        
        public VisitanteService (IVisitante VisitanteRepository)
        {
            _Visitanterepository = VisitanteRepository;
        }
        public ServiceResult GetAll()
        {
           ServiceResult result = new ServiceResult();
            try
            {
                var query = (from visitante in this._Visitanterepository.GetEntities()
                             select new VisitanteModel
                             {
                                 Apellido = visitante.Apellido,
                                 Aula = visitante.Aula,
                                 Carrera = visitante.Carrera,
                                 Correo = visitante.Correo,
                                 Edificio = visitante.Edificio,
                                 HoraEntrada = visitante.HoraEntrada,
                                 HoraSalida = visitante.HoraSalida,
                                 ID = visitante.ID,
                                 MotivoVisita = visitante.MotivoVisita,
                                 Nombre = visitante.Nombre,
                             }).ToList();
                result.Data = query;
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los  visitantes{ex}";
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Visitante visitante = _Visitanterepository.GetEntity(Id);
                VisitanteModel visitanemodel = new VisitanteModel()
                {
                    ID = visitante.ID,
                    Apellido = visitante.Apellido,
                    Aula = visitante.Aula,
                    Carrera = visitante.Carrera,
                    Correo = visitante.Correo,
                    Edificio = visitante.Edificio,
                    HoraEntrada = visitante.HoraEntrada,
                    HoraSalida = visitante.HoraSalida,
                    MotivoVisita = visitante.MotivoVisita,
                    Nombre = visitante.Nombre
                };
                result.Data = visitanemodel;
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message= $"Error al Obetner los datos del visitante {ex}";
            }
            return result;
        }

        public VisitantesRemoveResponse Remove(VisitanteDto visitanteDto)
        {
               VisitantesRemoveResponse result = new VisitantesRemoveResponse();
            try
            {
                Registro.DAL.Entities.Visitante visitante = new Registro.DAL.Entities.Visitante
                {
                    Apellido= visitanteDto.Apellido,
                    Aula= visitanteDto.Aula,
                    Correo= visitanteDto.Correo,
                    Carrera= visitanteDto.Carrera,
                     Edificio= visitanteDto.Edificio, 
                     HoraEntrada= visitanteDto.HoraEntrada,
                     HoraSalida= visitanteDto.HoraSalida,
                     ID= visitanteDto.ID,
                     MotivoVisita= visitanteDto.MotivoVisita,
                     Nombre= visitanteDto.Nombre
                     
                    

                };_Visitanterepository.Remove(visitante);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Usuario al intentar Borrarlo {ex}";
            }
            return result;
        }

        public VisitantesSaveResponse Save(VisitanteDto visitanteDto)
        {
         VisitantesSaveResponse result = new VisitantesSaveResponse();
            try
            {
                Registro.DAL.Entities.Visitante visitante = new Registro.DAL.Entities.Visitante
                {
                    Nombre = visitanteDto.Nombre,
                    Apellido = visitanteDto.Apellido,
                    Aula = visitanteDto.Aula,
                    Correo = visitanteDto.Correo,
                    Carrera = visitanteDto.Carrera,
                    Edificio = visitanteDto.Edificio,
                    HoraEntrada = visitanteDto.HoraEntrada,
                    HoraSalida = visitanteDto.HoraSalida,
                    ID = visitanteDto.ID,
                    MotivoVisita = visitanteDto.MotivoVisita

                };_Visitanterepository.Save(visitante);
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message= $"Error al Eliminar un Visitantes{ex}";
            }
            return result;
        }

        public VisitantesUpdateResponse Update(VisitanteDto visitanteDto)
        {
            VisitantesUpdateResponse result = new VisitantesUpdateResponse();
            try
            {
                Registro.DAL.Entities.Visitante visitante = new Registro.DAL.Entities.Visitante
                {   Nombre = visitanteDto.Nombre,
                    Apellido = visitanteDto.Apellido,
                    Aula = visitanteDto.Aula,
                    Correo = visitanteDto.Correo,
                    Carrera = visitanteDto.Carrera,
                    Edificio = visitanteDto.Edificio,
                    HoraEntrada = visitanteDto.HoraEntrada,
                    HoraSalida = visitanteDto.HoraSalida,
                    ID = visitanteDto.ID,
                    MotivoVisita = visitanteDto.MotivoVisita

                }; _Visitanterepository.Update(visitante);
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al Eliminar un Visitantes{ex}";
            }
            return result;
        }
    }
}
