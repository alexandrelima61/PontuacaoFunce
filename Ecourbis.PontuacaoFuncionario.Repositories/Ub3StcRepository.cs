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

                while (reader.Read())
                {
                    Ub3Sintetico ub3S = new Ub3Sintetico();
                    ub3S.DESCRIC = reader.GetString(reader.GetOrdinal("DESCRI"));
                    ub3S.UB3_ADVMES = reader.GetDouble(reader.GetOrdinal("UB3_ADVMES"));
                    ub3S.UB3_SUSMES = reader.GetDouble(reader.GetOrdinal("UB3_SUSMES"));
                    ub3S.UB3_ATMES = reader.GetDouble(reader.GetOrdinal("UB3_ATMES"));
                    ub3S.UB3_FALMES = reader.GetDouble(reader.GetOrdinal("UB3_FALMES"));
                    ub3S.UB3_REEMES = reader.GetDouble(reader.GetOrdinal("UB3_REEMES"));
                    ub3S.UB3_MULTAS = reader.GetDouble(reader.GetOrdinal("UB3_MULTAS"));
                    ub3S.UB3_ACID = reader.GetDouble(reader.GetOrdinal("UB3_ACID"));
                    ub3S.UB3_TOTAL = reader.GetDouble(reader.GetOrdinal("UB3_TOTAL"));

                    lstUb3StcPrd.Add(ub3S);
                }
            }
            catch (Exception) { throw; }

            _Context.FechaConexao();
            return lstUb3StcPrd;
        }
        
    }
}
