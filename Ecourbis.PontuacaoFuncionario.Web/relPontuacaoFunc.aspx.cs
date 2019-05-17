using Ecourbis.PontuacaoFuncionario.Application;
using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ecourbis.PontuacaoFuncionario.Web {
    public partial class relPontuacaoFunc : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string prdDe = Request.QueryString["pd"];
                string prdAte = Request.QueryString["pa"];
                string grp = Request.QueryString["g"];
                bool isAtivo = Boolean.Parse(Request.QueryString["atv"]);
                if (!string.IsNullOrEmpty(prdDe))
                    setDadosTela(isAtivo, prdDe, prdAte, grp);
            }
        }

        protected void setDadosTela(bool isAtivo, string prdDe, string prdAte, string grp) {

            int numPai = 1;
            string htmlResult = string.Empty;                                           //html da tablea
            Ub3StcBuss ub3STC = Ub3StcBuss.getNewInstance();                            //cria uma instancia para a class Ub3StcBuss
            Ub3AntBuss ub3ANT = Ub3AntBuss.getNewInstance();                            //cria uma instancia para a class Ub3AntBuss                
            string prdde = Utilitario.setDatePrd(prdDe);                                //cria e valoriza variavel de data padrao protheus
            string prdate = Utilitario.setDatePrd(prdAte);                              //cria e valoriza variavel de data padrao protheus

            List<Ub3Sintetico> lstUb3Stc = ub3STC.getListUb3Stc(isAtivo, prdDe, prdAte, grp);    //carrega a lista de Ub3Sintetico
            List<Ub3Analitico> lstUb3Ant;                                               //carrega a lista de Ub3Analitico

            result.InnerHtml = htmlResult;                                              //limpa a div resultado
            if (lstUb3Stc.Count > 0) {
                htmlResult += Utilitario.setHeaderTable(numPai.ToString());             //valoriza cabeçalho da tabela
                numPai = numPai + 1;
                foreach (var ub3s in lstUb3Stc) {
                    htmlResult += Utilitario.setDadosTableStc(ub3s, numPai.ToString()); //set registro na tabela
                    lstUb3Ant = ub3ANT.getDadosTableAnt(isAtivo, grp, prdDe, prdAte);    //set os registros na lista Ub3Analitico

                    if (lstUb3Ant.Count > 0) {
                        int nofilho = numPai + 1;                                       //valoriza a varivel filho para vincula-lo ao pai
                        htmlResult += Utilitario.setHeaderTableAnalitico(
                                            numPai.ToString(), nofilho.ToString());     //cria cabeçalho da tabela filho

                        foreach (var item in lstUb3Ant) {
                            htmlResult += Utilitario
                                    .setDadosTableAnlt(item, prdDe, prdAte, isAtivo);   //seta os itens da tabela filho
                        }
                        htmlResult += Utilitario.setEndTableAnalitico();                //valoriza string de impressão na tela
                    }
                    numPai = numPai + 2;                                                //corrigi valor da numPai
                }

                htmlResult += Utilitario.setEndTable();                                 //valoriza fechamento da tabela 

                result.InnerHtml += htmlResult;                                         //set registro na tela
                lblRel.Text += "de " + prdde + " ate " + prdate;

            }
        }
    }
}