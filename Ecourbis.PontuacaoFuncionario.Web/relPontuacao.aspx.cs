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
    public partial class relPontuacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrRel_Click(object sender, EventArgs e)
        {
            relatorio.InnerHtml = string.Empty;
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            string fechamentoPonto = ub3PRD.getClosePonto();                                    //cria a variavel com o ultimo fechameto do ponto
            string htmlPage = string.Empty;
            List<string> anomes = Utilitario.getAnoMes(fechamentoPonto);                        //cria uma lista apartir do ultimo fechament
            anomes.Sort();
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(anomes);

            if (dvUltPrdClose.Count > 0)
            {
                htmlPage += Utilitario.setHeadeDadosPRDClose(anomes);

                foreach (DataRowView item in dvUltPrdClose)
                {
                    htmlPage += Utilitario.setItensPRDClose(item, anomes);
                }

                htmlPage += Utilitario.setFootDadosPRDClose(anomes);

                relatorio.InnerHtml = htmlPage;
            }

        }
    }
}