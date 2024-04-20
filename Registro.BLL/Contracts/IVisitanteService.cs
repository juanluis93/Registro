using Registro.BLL.Dtos;
using Registro.BLL.Responses.VisitanteResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Contracts
{
    public interface IVisitanteService :IBaseService
    {
        VisitantesRemoveResponse Remove(VisitanteDto visitanteDto);
        VisitantesSaveResponse Save (VisitanteDto visitanteDto);
        VisitantesUpdateResponse Update (VisitanteDto visitanteDto);

    }
}
