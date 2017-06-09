using Ecourbis.PontuacaoFuncionario.Repositories;
using System.Collections.Generic;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Ub3PeriodoBuss
    {
        private static Ub3PeriodoBuss instance;

        public static Ub3PeriodoBuss getNewInstance()
        {
            if (instance == null)
                instance = new Ub3PeriodoBuss();

            return instance;
        }

        public string getClosePonto()
        {
            return Ub3PrdRepository.getNewInstance().getClosePonto();
        }

        public DataView getDtvPrdClose(string grupo, bool isAtivo, List<string> anomes)
        {
            return Ub3PrdRepository.getNewInstance().getDadosPrd(grupo, isAtivo, anomes);
        }
    }
}
