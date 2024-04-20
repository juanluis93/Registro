using Registro.BLL.Dtos;
using Registro.BLL.Responses.UsuarioResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Contracts
{
   public interface IUsuarioService : IBaseService
    {
        UsuarioRemoveReponse Remove(UsuarioDto usuarioDto);
        UsuarioSaveResponse Save(UsuarioDto usuarioDto);
        UsuarioUpdateResponse Update(UsuarioDto usuarioDto);
        
    }
}
