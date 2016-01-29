using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using Ecourbis.PontuacaoFuncionario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Ub3AntBuss
    {
        private static Ub3AntBuss instance;
        private static Ub3AntRepository ub3ANTRepo;

        public static Ub3AntBuss getNewInstance()
        {
            if (instance == null)
                instance = new Ub3AntBuss();

            return instance;
        }

        public List<Ub3Analitico> getDadosTableAnt(bool isAtivo, string grupo, string prdDE, string prdATE)
        {
            ub3ANTRepo = Ub3AntRepository.getNewInstance();
            return ub3ANTRepo.getListUb3Analitico(isAtivo, grupo, prdDE, prdATE);
        }
    }
}
