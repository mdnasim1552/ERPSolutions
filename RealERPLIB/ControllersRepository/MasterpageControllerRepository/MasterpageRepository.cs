using Dapper;
using RealERPLIB.DapperRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealEntity.Masterpage.MasterClass;

namespace RealERPLIB.ControllersRepository.MasterpageControllerRepository
{
    public class MasterpageRepository:IMasterpageRepository
    {
        private readonly IDapperService _dapperService;
        public MasterpageRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<Interfaces>> GetInterface()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETINTERFACE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            List<Interfaces> listOfInterface = await _dapperService.GetListAsync<Interfaces>(procedureName, parameters);
            return listOfInterface;
        }
        public async Task<List<Modules>> GetModule()
        {
            string procedureName = "SP_UTILITY_LOGIN_MGT";
            string Calltype = "GETCOMMODULE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Calltype", Calltype);
            List<Modules> listOfModule = await _dapperService.GetListAsync<Modules>(procedureName, parameters);
            return listOfModule;
        }
    }
}
