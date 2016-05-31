using Ecourbis.PontuacaoFuncionario.Domain.Connexao;
using Ecourbis.PontuacaoFuncionario.Domain.SQLCommand;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ecourbis.PontuacaoFuncionario.Repositories
{
    public class Ub3PrdRepository
    {
        private string qryConsulta;
        private static Ub3PrdRepository instance;
        private Connection _Context;
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DADOSADVEntitiesSul"].ConnectionString;

        public static Ub3PrdRepository getNewInstance()
        {
            if (instance == null)
                instance = new Ub3PrdRepository();

            return instance;
        }

        /// <summary>
        /// retorna o ultimo fechamento do ponto no Protheus
        /// </summary>
        /// <returns></returns>
        public string getClosePonto()
        {
            string fechamentoPonto = string.Empty;
            string qry = SQLCommand.getQryFechamentoPonto();
            _Context = new Connection(this.ConnectionString);
            _Context.AbrirConexao();

            try
            {
                IDataReader reader = _Context.RetornaDados(qry);
                if (reader.Read())
                    fechamentoPonto = reader.GetString(0);
            }
            catch (Exception) { }

            _Context.FechaConexao();
            return fechamentoPonto;
        }

        public DataView getDadosPrd(string grupo, bool isAtivo, List<string> anomes)
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection())
            {
                try
                {
                    qryConsulta = SQLCommand.getQryPrdClose(grupo, isAtivo, anomes);
                    conn.ConnectionString = ConnectionString;
                    conn.Open();

                    using (var da = new SqlDataAdapter(qryConsulta, conn))
                    {
                        da.Fill(ds);
                        dv = new DataView(ds.Tables[0]);
                    }

                    conn.Close();
                }
                catch (Exception) { }
            }
            return dv;
        }

    }
}
