using Registro.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.BLL.Contracts
{
    public interface IAulaService : IBaseService
    {
        void Save(AulaDto aulaSave);
        void Update(AulaDto aulaUpdate);
    }
}
