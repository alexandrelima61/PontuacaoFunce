using Ecourbis.PontuacaoFuncionario.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecourbis.PontuacaoFuncionario.Web
{
    public partial class DetalhesFunce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mat = Request.QueryString["mat"];
            setDetalhesFunce(mat);
        }

        private void setDetalhesFunce(string mat)
        {
            relatorio.InnerHtml = string.Empty;
            string html = string.Empty;
            DataView dvDadosFunc = Ub3DetalhesBuss.getInstance().getDadosFunce(mat);
            DataView dvDetalhes = Ub3DetalhesBuss.getInstance().getDetalheFunce(mat);

            if (dvDadosFunc.Count > 0)
            {
                html = Utilitario.setHeaderDdFunce();

                foreach (DataRowView item in dvDadosFunc)
                    html += Utilitario.setDadosDdFunce(item);

                html += Utilitario.setFooterDdFunce();
            }

            if(dvDetalhes.Count > 0)
            {
                html += Utilitario.setHeaderDetFunce();

                foreach (DataRowView item in dvDetalhes)
                    html += Utilitario.setDadosDetFunce(item);

                html += Utilitario.setFooterDetFunce();
            }

            relatorio.InnerHtml += html;

        }
    }
}