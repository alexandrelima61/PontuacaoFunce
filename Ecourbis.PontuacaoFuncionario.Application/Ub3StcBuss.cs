using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using Ecourbis.PontuacaoFuncionario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Ub3StcBuss
    {
        private static Ub3StcBuss instance;
        private static Ub3StcRepository ub3STCRepo;

        public static Ub3StcBuss getNewInstance()
        {
            if (instance == null)
                instance = new Ub3StcBuss();

            return instance;
        }

        public List<Ub3Sintetico> getListUb3Stc(bool isAtivo, string prdDE, string prdATE, string grupo)
        {
            ub3STCRepo = Ub3StcRepository.getNewInstance();
            return ub3STCRepo.getListUb3Sintetico(isAtivo, prdDE, prdATE, grupo);
        }
    }
}
