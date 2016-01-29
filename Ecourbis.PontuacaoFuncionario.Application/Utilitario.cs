using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using Ecourbis.PontuacaoFuncionario.Domain.SQLCommand;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;

namespace Ecourbis.PontuacaoFuncionario.Application
{
    public class Utilitario
    {
        private static StringBuilder html;

        /// <summary>
        /// Retorna a relação dos ultimos 12 meses para criação da chave de pesquisa no sql.
        /// </summary>
        /// <param name="closeP">ultimo fechamento do ponto</param>
        /// <returns>List<string></returns>
        public static List<string> getAnoMes(string closeP)
        {
            List<string> anomes = new List<string>();
            DateTime anomeCurrent = DateTime.Parse(closeP);

            for (int i = 0; i < 12; i++)
            {
                if (i == 0)
                    anomes.Add(anomeCurrent.ToString("yyyyMM"));
                else
                    anomes.Add(anomeCurrent.AddMonths(-i).ToString("yyyyMM"));
            }

            return anomes;
        }

        /// <summary>
        /// Captura o usuário corrente
        /// </summary>
        /// <returns></returns>
        public static string GetUser()//Usuário logado + domínio
        {
            //string UsName = WindowsIdentity.GetCurrent().Name;//Domínio + Login
            var x = new System.Web.UI.Page();
            string usName = x.Page.User.Identity.Name.ToString();

            return usName.Replace(@"ECOURBIS\", "").ToLower();
        }

        public static string setTitulo(bool isfuncAtivos)
        {
            html = new StringBuilder();
            if (isfuncAtivos)
            {
                html.Append("       <div class='container'>");
                html.Append("           <h3>FUNCIONÁRIOS ATIVOS</h3>");
            }
            else
            {
                html.Append("       <div class='container'>");
                html.Append("           <h3>FUNCIONÁRIOS DEMITIDOS</h3>");
            }
            return html.ToString();
        }

        /// <summary>
        /// Captura o ip da maquina do usuário corrente
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string Host = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(Host);

            return ip[1].ToString();
        }

        /// <summary>
        /// Method responsável por formata a data para padrao protheus
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string setDatePrd(string data)
        {
            return (data.Substring(4, 2) + "/" + data.Substring(0, 4));
        }

        /**Sintetico**/
        /// <summary>
        /// Method responsável por seta o inicio da tabela sintetica
        /// </summary>
        /// <returns></returns>
        public static string setHeaderTable(string numNo)
        {
            html = new StringBuilder();

            html.Append("           <table class='table table-responsive tree' style='width:100%;'>\n");
            html.Append("                    <tr class='treegrid-" + numNo + "'>\n");
            html.Append("                        <td><b>DESCRIÇÃO</b></td>\n");
            html.Append("                        <td class='text-right'><b>ADVERTENCIA</b></td>\n");
            html.Append("                        <td class='text-right'><b>SUSPENÇÃO</b></td>\n");
            html.Append("                        <td class='text-right'><b>ATESTADO</b></td>\n");
            html.Append("                        <td class='text-right'><b>FALTA</b></td>\n");
            html.Append("                        <td class='text-right'><b>REEMBOLSO</b></td>\n");
            html.Append("                        <td class='text-right'><b>TOTAL</b></td>\n");
            html.Append("                    </tr>\n");

            return html.ToString();
        }

        /// <summary>
        /// Method responsável por fecha a tabela sintetica de exibição na tela do usuário.
        /// </summary>
        /// <returns></returns>
        public static string setEndTable()
        {
            html = new StringBuilder();

            /*html.Append("               <tfoot>\n");
            html.Append("                    <tr>\n");
            html.Append("                        <td><b>DESCRIÇÃO</b></td>\n");
            html.Append("                        <td class='text-right'><b>ADVERTENCIA</b></td>\n");
            html.Append("                        <td class='text-right'><b>SUSPENÇÃO</b></td>\n");
            html.Append("                        <td class='text-right'><b>ATESTADO</b></td>\n");
            html.Append("                        <td class='text-right'><b>FALTA</b></td>\n");
            html.Append("                        <td class='text-right'><b>REEMBOLSO</b></td>\n");
            html.Append("                        <td class='text-right'><b>TOTAL</b></td>\n");
            html.Append("                    </tr>\n");
            html.Append("               </tfoot>\n");*/
            html.Append("            </table>\n");

            return html.ToString();
        }

        /// <summary>
        /// Method responsável por set itens da tabela sintecico.
        /// </summary>
        /// <param name="ub3a"></param>
        /// <returns></returns>
        public static string setDadosTableStc(Ub3Sintetico ub3s, string numNo)
        {
            html = new StringBuilder();

            html.Append("                  <tr class='treegrid-" + numNo + "'>\n");
            html.Append("                        <td>" + ub3s.DESCRIC + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_ADVMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_SUSMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_ATMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_FALMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_REEMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3s.UB3_TOTAL + "</td>\n");
            html.Append("                    </tr>\n");

            return html.ToString();
        }

        /**Analitico**/
        /// <summary>
        /// Method responsável por set cabeçalho da tabela analitica, por grupo.
        /// </summary>
        /// <returns></returns>
        public static string setHeaderTableAnalitico(string numNoPai, string numNoFilho)
        {
            html = new StringBuilder();

            html.Append("           <tr class='treegrid-" + numNoFilho + " treegrid-parent-" + numNoPai + "'><td colspan='9'> <table class='table table-responsive tablefilter display' style='width:100%;'>\n");
            html.Append("                 <thead>");
            html.Append("                    <tr class='table_filha_cabecalho'>\n");
            html.Append("                        <th>CC</th>\n");
            html.Append("                        <th>DESCRIÇÃO</th>\n");
            html.Append("                        <th>MATRICULA</th>\n");
            html.Append("                        <th>DT DEMIS.</th>\n");
            html.Append("                        <th>ADVERT.</th>\n");
            html.Append("                        <th>SUSP.</th>\n");
            html.Append("                        <th>ATESTADO</th>\n");
            html.Append("                        <th>FALTA</th>\n");
            html.Append("                        <th>REEMBOLSO</th>\n");
            html.Append("                        <th>TOTAL</th>\n");
            html.Append("                        <th></th>\n");
            html.Append("                    </tr>\n");
            html.Append("                 </thead>");

            return html.ToString();
        }
                
        /// <summary>
        /// Method responsável por fecha a tabela analitica de exibição na tela do usuário.
        /// </summary>
        /// <returns></returns>
        public static string setEndTableAnalitico()
        {
            html = new StringBuilder();

            /*html.Append("               <tfoot>\n");
            html.Append("                    <tr class='table_filha_cabecalho'>\n");
            html.Append("                        <th>CC</th>\n");
            html.Append("                        <th>DESCRIÇÃO</th>\n");
            html.Append("                        <th>MATRICULA</th>\n");
            html.Append("                        <th>DT DEMIS.</th>\n");
            html.Append("                        <th>ADVERT.</th>\n");
            html.Append("                        <th>SUSP.</th>\n");
            html.Append("                        <th>ATESTADO</th>\n");
            html.Append("                        <th>FALTA</th>\n");
            html.Append("                        <th>REEMBOLSO</th>\n");
            html.Append("                        <th>TOTAL</th>\n");
            html.Append("                    </tr>\n");
            html.Append("               </tfoot>\n");*/

            html.Append("            </table>\n");
            html.Append("       <td>\n");
            html.Append("   <tr>\n");

            return html.ToString();
        }

        /// <summary>
        /// Method responsável por set itens da tabela sintecico.
        /// </summary>
        /// <param name="ub3a"></param>
        /// <returns></returns>
        public static string setDadosTableAnlt(Ub3Analitico ub3a)
        {
            html = new StringBuilder();

            html.Append("                  <tr class='table_filha_item'>\n");
            html.Append("                        <td>" + ub3a.CC + "</td>\n");
            html.Append("                        <td>" + ub3a.DESC_CC + "</td>\n");
            html.Append("                        <td>" + ub3a.UB3_MAT + "</td>\n");
            html.Append("                        <td>" + ub3a.UB3_DEMIS + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_ADVMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_SUSMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_ATMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_FALMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_REEMES + "</td>\n");
            html.Append("                        <td class='text-right'>" + ub3a.UB3_TOTAL + "</td>\n");
            html.Append("                        <td class='text-right'><a href='#' class='btn btn-link  link-painel'><img src='img/print.png' style='width:15px; height:15px;'/></a></td>\n");
            html.Append("                    </tr>\n");

            return html.ToString();
        }

        //primeiro relatório 
        public static string setHeadeDadosPRDClose(List<string> anomes)
        {
            html = new StringBuilder();            
            html.Append("            <table class='table table-responsive config-table'>\n");
            html.Append("                <tr>\n");
            html.Append("                    <td><b>GRUPO</b></td>\n");
            html.Append("                    <td><b>DESCRIÇÃO</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[0]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[1]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[2]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[3]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[4]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[5]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[6]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[7]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[8]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[9]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[10]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>" + SQLCommand.getM(anomes[11]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                    <td class='text-right'><b>TOTAL</b></td>\n");
            html.Append("                </tr>\n");
            return html.ToString();
        }

        public static string setFootDadosPRDClose(List<string> anomes)
        {
            html = new StringBuilder();
           /* html.Append("               <tfoot>\n");
            html.Append("                   <tr>\n");
            html.Append("                       <td><b>GRUPO</b></td>\n");
            html.Append("                       <td><b>DESCRIÇÃO</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[0]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[1]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[2]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[3]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[4]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[5]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[6]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[7]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[8]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[9]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[10]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>" + SQLCommand.getM(anomes[11]).Replace("[", "").Replace("]", "") + "</b></td>\n");
            html.Append("                       <td class='text-right'><b>TOTAL</b></td>\n");
            html.Append("                   </tr>\n");
            html.Append("               </tfoot>\n");*/
            html.Append("            </table>\n");
            html.Append("       </div>");
            html.Append("       <br />");
            html.Append("       <br />");

            return html.ToString();
        }

        public static string setItensPRDClose(DataRowView item, List<string> anomes,bool isAtivo)
        {
            html = new StringBuilder();

            html.Append("                   <tr>\n");
            html.Append("                       <td>" + item[0] + "</td>\n");
            html.Append("                       <td>" + item[1] + "</td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[0] + "&pa=" + anomes[0] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[2] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[1] + "&pa=" + anomes[1] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[3] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[2] + "&pa=" + anomes[2] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[4] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[3] + "&pa=" + anomes[3] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox ' data-fancybox-type='iframe'>" + item[5] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[4] + "&pa=" + anomes[4] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[6] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[5] + "&pa=" + anomes[5] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[7] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[6] + "&pa=" + anomes[6] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[8] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[7] + "&pa=" + anomes[7] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[9] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[8] + "&pa=" + anomes[8] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[10] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[9] + "&pa=" + anomes[9] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox' data-fancybox-type='iframe'>" + item[11] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[10] + "&pa=" + anomes[10] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox fancybox.iframe' data-fancybox-type='iframe'>" + item[12] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[11] + "&pa=" + anomes[11] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox fancybox.iframe' data-fancybox-type='iframe'>" + item[13] + "</a></td>\n");
            html.Append("                       <td class='text-right'><a href='relPontuacaoFunc.aspx?pd=" + anomes[0] + "&pa=" + anomes[11] + "&g=" + item[0] + "&atv=" + isAtivo + "' class='alert-link fancybox fancybox.iframe' data-fancybox-type='iframe'>" + item[14] + "</a></td>\n");
            html.Append("                   </tr>\n");

            return html.ToString();
        }
    }
}
