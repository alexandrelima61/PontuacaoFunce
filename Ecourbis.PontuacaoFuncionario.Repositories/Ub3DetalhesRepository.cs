using Ecourbis.PontuacaoFuncionario.Domain.Connexao;
using Ecourbis.PontuacaoFuncionario.Domain.SQLCommand;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ecourbis.PontuacaoFuncionario.Repositories
{
    public class Ub3DetalhesRepository
    {
        private string qryConsulta;
        private static Ub3DetalhesRepository instance;
        private Connection _Context;
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DADOSADVEntitiesSul"].ConnectionString;

        public static Ub3DetalhesRepository getNewInstance()
        {
            if (instance == null)
                instance = new Ub3DetalhesRepository();

            return instance;
        }

        /// <summary>
        /// retorna uma dataview com os dados do funcionário informado
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>DataView</returns>
        public DataView getDadosFunce(string matricula)
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection())
            {
                try
                {
                    qryConsulta = SQLCommand.getDadosFunce(matricula);
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

        /// <summary>
        /// retorna uma data DataView com o a pontuação do funcionário durante todo o periodo
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>DataView</returns>
        public DataView getDetalherFunce(string matricula)
        {
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection())
            {
                try
                {
                    qryConsulta = SQLCommand.getDetalhesFunce(matricula);
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
