using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealEntity.Masterpage.MasterClass;

namespace RealERPLIB.ControllersRepository.MasterpageControllerRepository
{
    public interface IMasterpageRepository
    {
        Task<List<Interfaces>> GetInterface();
        Task<List<Modules>> GetModule();
    }
}
