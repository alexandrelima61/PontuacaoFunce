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
        /// <param name="periodo"></param>
        /// <returns></returns>
        public List<Ub3Analitico> getListUb3Analitico(string grupo, string periodo)
        {
            List<Ub3Analitico> lstUb3AntPrd = new List<Ub3Analitico>();
            _Context = new Connection(this.ConnectionString);
            _Context.AbrirConexao();
            qryConsulta = string.Empty;
            qryConsulta = SQLCommand.getQryUb3Analitico(periodo, grupo);

            try
            {
                IDataReader reader = _Context.RetornaDados(qryConsulta);

                int idxUnd = reader.GetOrdinal("UNIDADE");
                int idxCdc = reader.GetOrdinal("CC");
                int idxDes = reader.GetOrdinal("DESC_CC");
                int idxMat = reader.GetOrdinal("UB3_MAT");
                int idxDms = reader.GetOrdinal("UB3_DEMIS");
                int idxAdv = reader.GetOrdinal("UB3_ADVMES");
                int idxSsp = reader.GetOrdinal("UB3_SUSMES");
                int idxAts = reader.GetOrdinal("UB3_ATMES");
                int idxFlt = reader.GetOrdinal("UB3_FALMES");
                int idxRee = reader.GetOrdinal("UB3_REEMES");
                int idxTtl = reader.GetOrdinal("UB3_TOTAL");

                while (reader.Read())
                {
                    Ub3Analitico ub3a = new Ub3Analitico();

                    ub3a.UNIDADE = reader.GetString(idxUnd);
                    ub3a.CC = reader.GetString(idxCdc);
                    ub3a.DESC_CC = reader.GetString(idxDes);
                    ub3a.UB3_MAT = reader.GetString(idxMat);
                    ub3a.UB3_DEMIS = reader.GetString(idxDms);
                    ub3a.UB3_ADVMES = reader.GetDouble(idxAdv);
                    ub3a.UB3_SUSMES = reader.GetDouble(idxSsp);
                    ub3a.UB3_ATMES = reader.GetDouble(idxAts);
                    ub3a.UB3_FALMES = reader.GetDouble(idxFlt);
                    ub3a.UB3_REEMES = reader.GetDouble(idxRee);
                    ub3a.UB3_TOTAL = reader.GetDouble(idxTtl);

                    lstUb3AntPrd.Add(ub3a);
                }
            }
            catch (Exception e) { }

            _Context.FechaConexao();
            return lstUb3AntPrd;
        }
    }
}
