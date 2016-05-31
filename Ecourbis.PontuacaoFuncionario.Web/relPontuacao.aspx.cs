using Ecourbis.PontuacaoFuncionario.Application;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Web
{
    public partial class relPontuacao : System.Web.UI.Page
    {
        private string __User;
        private string[] isAuthorizer;

        protected void Page_Load(object sender, EventArgs e)
        {
            __User = Utilitario.GetUser();
            isAuthorizer = Utilitario.GetAuthorize(__User);
            btnGrRel.Enabled = "OK".Equals(isAuthorizer[1]);


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
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(isAuthorizer[0], true, anomes);
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
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(isAuthorizer[0], false, anomes);
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