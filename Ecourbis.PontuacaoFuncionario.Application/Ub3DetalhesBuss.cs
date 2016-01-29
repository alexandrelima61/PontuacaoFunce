using Ecourbis.PontuacaoFuncionario.Repositories;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Ub3DetalhesBuss
    {
        private static Ub3DetalhesBuss instance;

        public static Ub3DetalhesBuss getInstance()
        {
            if (instance == null)
                instance = new Ub3DetalhesBuss();

            return instance;
        }

        public DataView getDadosFunce(string matricula)
        {
            return Ub3DetalhesRepository.getNewInstance().getDadosFunce(matricula);
        }

        public DataView getDetalheFunce(string matricula)
        {
            return Ub3DetalhesRepository.getNewInstance().getDetalherFunce(matricula);
        }

    }
}
