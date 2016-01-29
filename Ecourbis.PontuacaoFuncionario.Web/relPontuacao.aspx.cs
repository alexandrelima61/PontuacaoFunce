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
            //System.Threading.Thread.Sleep(1000);
            relatorio.InnerHtml = string.Empty;
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            string fechamentoPonto = ub3PRD.getClosePonto();                                    //cria a variavel com o ultimo fechameto do ponto            
            List<string> anomes = Utilitario.getAnoMes(fechamentoPonto);                        //cria uma lista apartir do ultimo fechament
            anomes.Sort();
            setDadosFuncAtivos(anomes);
            setDadosFuncDemit(anomes);

        }

        private void setDadosFuncAtivos(List<string> anomes)
        {
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(true, anomes);
            string htmlPage = string.Empty;

            if (dvUltPrdClose.Count > 0)
            {
                htmlPage += Utilitario.setTitulo(true);

                htmlPage += Utilitario.setHeadeDadosPRDClose(anomes);

                foreach (DataRowView item in dvUltPrdClose)
                {
                    htmlPage += Utilitario.setItensPRDClose(item, anomes, true);
                }

                htmlPage += Utilitario.setFootDadosPRDClose(anomes);

                relatorio.InnerHtml = htmlPage;
            }
        }

        private void setDadosFuncDemit(List<string> anomes)
        {
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(false, anomes);
            string htmlPage = string.Empty;

            if (dvUltPrdClose.Count > 0)
            {
                htmlPage += Utilitario.setTitulo(false);
                htmlPage += Utilitario.setHeadeDadosPRDClose(anomes);

                foreach (DataRowView item in dvUltPrdClose)
                {
                    htmlPage += Utilitario.setItensPRDClose(item, anomes, false);
                }

                htmlPage += Utilitario.setFootDadosPRDClose(anomes);

                relatorio.InnerHtml += htmlPage;
            }
        }
    }
}