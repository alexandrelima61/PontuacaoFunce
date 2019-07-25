using Ecourbis.PontuacaoFuncionario.Application;
using Ecourbis.PontuacaoFuncionario.Web.Model;
using Ecourbis.PontuacaoFuncionario.Web.service.auth;
using System;
using System.Collections.Generic;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Web {
    public partial class relPontuacao : System.Web.UI.Page {

        private string ENABLED_OK = "OK";
        private string __User;
        //private string[] isAuthorizer;
        private UserAuth __userAuth;
        private LoadingUser loadingUser;

        protected void Page_Load(object sender, EventArgs e) {
            __User = Utilitario.GetUser();
            //__User = __User.Equals("") ? "jalima" : __User;
            //isAuthorizer = Utilitario.GetAuthorize(__User);
            //btnGrRel.Enabled = "OK".Equals(isAuthorizer[1]);
            loadingUser = LoadingUser.GetNewInstance();
            __userAuth = loadingUser.FindUserAuthByFileJson(__User);
            btnGrRel.Enabled = ENABLED_OK.Equals(__userAuth.auths.status);

        }

        protected void btnGrRel_Click(object sender, EventArgs e) {
            //System.Threading.Thread.Sleep(1000);
            relatorio.InnerHtml = string.Empty;
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            string fechamentoPonto = ub3PRD.getClosePonto();                                    //cria a variavel com o ultimo fechameto do ponto            
            List<string> anomes = Utilitario.getAnoMes(fechamentoPonto);                        //cria uma lista apartir do ultimo fechament
            anomes.Sort();
            setDadosFuncAtivos(anomes);
            setDadosFuncDemit(anomes);

        }

        private void setDadosFuncAtivos(List<string> anomes) {
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss            
            //DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(isAuthorizer[0], true, anomes);
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(__userAuth.auths.auth, true, anomes);
            string htmlPage = string.Empty;

            if (dvUltPrdClose.Count > 0) {
                htmlPage += Utilitario.setTitulo(true);

                htmlPage += Utilitario.setHeadeDadosPRDClose(anomes, "tableToExcelA");

                foreach (DataRowView item in dvUltPrdClose)
                    htmlPage += Utilitario.setItensPRDClose(item, anomes, true);

                htmlPage += Utilitario.setFootDadosPRDClose(anomes);

                relatorio.InnerHtml = htmlPage;
            }
        }

        private void setDadosFuncDemit(List<string> anomes) {
            Ub3PeriodoBuss ub3PRD = Ub3PeriodoBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss
            //DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(isAuthorizer[0], false, anomes);
            DataView dvUltPrdClose = ub3PRD.getDtvPrdClose(__userAuth.auths.auth, false, anomes);
            string htmlPage = string.Empty;

            if (dvUltPrdClose.Count > 0) {
                htmlPage += Utilitario.setTitulo(false);
                htmlPage += Utilitario.setHeadeDadosPRDClose(anomes, "tableToExcelD");

                foreach (DataRowView item in dvUltPrdClose) {
                    htmlPage += Utilitario.setItensPRDClose(item, anomes, false);
                }

                htmlPage += Utilitario.setFootDadosPRDClose(anomes);

                relatorio.InnerHtml += htmlPage;
            }
        }
    }
}