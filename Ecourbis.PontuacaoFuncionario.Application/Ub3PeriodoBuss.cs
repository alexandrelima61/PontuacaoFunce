using Ecourbis.PontuacaoFuncionario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Ub3PeriodoBuss
    {
        private static Ub3PeriodoBuss instance;
        private static Ub3PrdRepository ub3PRDRepo;

        public static Ub3PeriodoBuss getNewInstance()
        {
            if (instance == null)
                instance = new Ub3PeriodoBuss();

            return instance;
        }

        public string getClosePonto()
        {
            ub3PRDRepo = Ub3PrdRepository.getNewInstance();
            return ub3PRDRepo.getClosePonto();
        }

        public System.Data.DataView getDtvPrdClose(string grupo, bool isAtivo, List<string> anomes)
        {
            ub3PRDRepo = Ub3PrdRepository.getNewInstance();
            return ub3PRDRepo.getDadosPrd(grupo, isAtivo, anomes);
        }
    }
}
