using Registro.BLL.Contracts;
using Registro.BLL.Core;
using Registro.BLL.Dtos;
using Registro.BLL.Models;
using Registro.BLL.Responses.UsuarioResponses;
using Registro.DAL.Interfaces;
using Registro.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarios _usuarios;
        public UsuarioService(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }
        public UsuarioRemoveReponse Remove(UsuarioDto usuarioDto)
        {
            UsuarioRemoveReponse result = new UsuarioRemoveReponse();
            try
            {
                Registro.DAL.Entities.Usuarios usuarios = new Registro.DAL.Entities.Usuarios
                {
                    Admin = usuarioDto.Admin,
                    Contraseña = usuarioDto.Contraseña,
                    Id = usuarioDto.Id,
                    Nombre = usuarioDto.Nombre,

                }; _usuarios.Remove(usuarios);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Usuario al intentar Borrarlo {ex}";
            }
            return result;

        }

        public UsuarioSaveResponse Save(UsuarioDto usuarioDto)
        {
            UsuarioSaveResponse result = new UsuarioSaveResponse();
            try
            {
                Registro.DAL.Entities.Usuarios usuarios = new Registro.DAL.Entities.Usuarios
                {
                    Admin = usuarioDto.Admin,
                    Contraseña = usuarioDto.Contraseña,
                    Id = usuarioDto.Id,
                    Nombre = usuarioDto.Nombre,

                }; _usuarios.Save(usuarios);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Usuario al intentar Borrarlo {ex}";
            }
            return result;


        }

        public UsuarioUpdateResponse Update(UsuarioDto usuarioDto)
        {
           UsuarioUpdateResponse result = new UsuarioUpdateResponse();
            try
            {
                Registro.DAL.Entities.Usuarios usuarios = new Registro.DAL.Entities.Usuarios
                {
                    Admin = usuarioDto.Admin,
                    Contraseña = usuarioDto.Contraseña,
                    Id = usuarioDto.Id,
                    Nombre = usuarioDto.Nombre,

                }; _usuarios.Update(usuarios);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error en Usuario al intentar Borrarlo {ex}";
            }
            return result;
        }

        public ServiceResult GetAll()
        {
           ServiceResult result = new ServiceResult();
            try
            {
                var query = (from usuario in this._usuarios.GetEntities()
                             select new UsuarioModel
                             {
                                 Admin = usuario.Admin,
                                 Contraseña = usuario.Contraseña,
                                 ID = usuario.Id,
                                 Nombre = usuario.Nombre,
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo los Usuarios{ex} ";
                
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Usuarios usuarios = _usuarios.GetEntity(Id);
                UsuarioModel usuarioModel = new UsuarioModel {

                    Admin = usuarios.Admin,
                    Contraseña = usuarios.Contraseña,
                    ID = usuarios.Id,
                    Nombre = usuarios.Nombre
                };
                result.Data = usuarioModel;
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio un error obteniendo en usuario {ex}";
            }
            return result;
        }


    }
}
