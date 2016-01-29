using Ecourbis.PontuacaoFuncionario.Domain.Connexao;
using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using Ecourbis.PontuacaoFuncionario.Domain.SQLCommand;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Repositories
{
    public class Ub3StcRepository
    {
        private string qryConsulta;
        private static Ub3StcRepository instance;
        private Connection _Context;
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DADOSADVEntitiesSul"].ConnectionString;

        /// <summary>
        /// retorna uma instancia da classe
        /// </summary>
        /// <returns></returns>
        public static Ub3StcRepository getNewInstance()
        {
            if (instance == null)
                instance = new Ub3StcRepository();

            return instance;
        }

        public List<Ub3Sintetico> getListUb3Sintetico(bool isAtivo, string prdDe, string prdAte, string grupo)
        {
            List<Ub3Sintetico> lstUb3StcPrd = new List<Ub3Sintetico>();
            _Context = new Connection(this.ConnectionString);
            _Context.AbrirConexao();

            qryConsulta = SQLCommand.getQryUb3Sintetico(isAtivo, prdDe, prdAte, grupo);

            try
            {
                IDataReader reader = _Context.RetornaDados(qryConsulta);

                int idxDsc = reader.GetOrdinal("DESCRI");
                int idxAdm = reader.GetOrdinal("UB3_ADVMES");
                int idxSsn = reader.GetOrdinal("UB3_SUSMES");
                int idxAtm = reader.GetOrdinal("UB3_ATMES");
                int idxFlm = reader.GetOrdinal("UB3_FALMES");
                int idxRem = reader.GetOrdinal("UB3_REEMES");
                int idxTtl = reader.GetOrdinal("UB3_TOTAL");

                while (reader.Read())
                {
                    Ub3Sintetico ub3S = new Ub3Sintetico();
                    ub3S.DESCRIC = reader.GetString(idxDsc);
                    ub3S.UB3_ADVMES = reader.GetDouble(idxAdm);
                    ub3S.UB3_SUSMES = reader.GetDouble(idxSsn);
                    ub3S.UB3_ATMES = reader.GetDouble(idxAtm);
                    ub3S.UB3_FALMES = reader.GetDouble(idxFlm);
                    ub3S.UB3_REEMES = reader.GetDouble(idxRem);
                    ub3S.UB3_TOTAL = reader.GetDouble(idxTtl);

                    lstUb3StcPrd.Add(ub3S);
                }
            }
            catch (Exception) { throw; }

            _Context.FechaConexao();
            return lstUb3StcPrd;
        }


    }
}
