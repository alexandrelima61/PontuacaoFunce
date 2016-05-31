using Ecourbis.PontuacaoFuncionario.Domain.Connexao;
using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using Ecourbis.PontuacaoFuncionario.Domain.SQLCommand;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Repositories
{
    public class Ub3AntRepository
    {
        private string qryConsulta;
        private static Ub3AntRepository instance;
        private Connection _Context;
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DADOSADVEntitiesSul"].ConnectionString;

        public static Ub3AntRepository getNewInstance()
        {
            if (instance == null)
                instance = new Ub3AntRepository();

            return instance;
        }

        /// <summary>
        /// Method responsável por cria lista referente ao ano/mes correspondente a consulta, por grupo, deforma analitica.
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="prdDe"></param>
        /// <returns></returns>
        public List<Ub3Analitico> getListUb3Analitico(bool isAtivo, string grupo, string prdDe, string prdAte)
        {
            List<Ub3Analitico> lstUb3AntPrd = new List<Ub3Analitico>();
            _Context = new Connection(this.ConnectionString);
            _Context.AbrirConexao();
            qryConsulta = string.Empty;
            qryConsulta = SQLCommand.getQryUb3Analitico(isAtivo, prdDe, prdAte, grupo);

            try
            {
                IDataReader reader = _Context.RetornaDados(qryConsulta);
                                
                while (reader.Read())
                {
                    Ub3Analitico ub3a = new Ub3Analitico();

                    ub3a.UNIDADE = reader.GetString(reader.GetOrdinal("UNIDADE"));
                    ub3a.CC = reader.GetString(reader.GetOrdinal("CC"));
                    ub3a.DESC_CC = reader.GetString(reader.GetOrdinal("DESC_CC"));
                    ub3a.UB3_MAT = reader.GetString(reader.GetOrdinal("UB3_MAT"));
                    ub3a.UB3_DEMIS = reader.GetString(reader.GetOrdinal("UB3_DEMIS"));
                    ub3a.UB3_ADVMES = reader.GetDouble(reader.GetOrdinal("UB3_ADVMES"));
                    ub3a.UB3_SUSMES = reader.GetDouble(reader.GetOrdinal("UB3_SUSMES"));
                    ub3a.UB3_ATMES = reader.GetDouble(reader.GetOrdinal("UB3_ATMES"));
                    ub3a.UB3_FALMES = reader.GetDouble(reader.GetOrdinal("UB3_FALMES"));
                    ub3a.UB3_REEMES = reader.GetDouble(reader.GetOrdinal("UB3_REEMES"));
                    ub3a.UB3_MULTAS = reader.GetDouble(reader.GetOrdinal("UB3_MULTAS"));
                    ub3a.UB3_ACID = reader.GetDouble(reader.GetOrdinal("UB3_ACID"));
                    ub3a.UB3_TOTAL = reader.GetDouble(reader.GetOrdinal("UB3_TOTAL"));

                    lstUb3AntPrd.Add(ub3a);
                }
            }
            catch (Exception) { }

            _Context.FechaConexao();
            return lstUb3AntPrd;
        }

    }
}
