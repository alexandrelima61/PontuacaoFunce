using Ecourbis.PontuacaoFuncionario.Application;
using Ecourbis.PontuacaoFuncionario.Domain.Entities;
using System;
using System.Data;

namespace Ecourbis.PontuacaoFuncionario.Web {
    public partial class DetalhesFunce : System.Web.UI.Page {

        private string mat = string.Empty;
        private string pd = string.Empty;
        private string pa = string.Empty;
        private bool isAtivo;


        protected void Page_Load(object sender, EventArgs e) {

            if (!string.IsNullOrEmpty(Request.QueryString["mat"]) &&
                !string.IsNullOrEmpty(Request.QueryString["pd"]) &&
                !string.IsNullOrEmpty(Request.QueryString["pa"]) &&
                !string.IsNullOrEmpty(Request.QueryString["atv"])) {
                mat = Request.QueryString["mat"];
                pd = Request.QueryString["pd"];
                pa = Request.QueryString["pa"];

                if (string.IsNullOrEmpty(Request.QueryString["vld"]))
                    validaPeriodo();

                isAtivo = Boolean.Parse(Request.QueryString["atv"]);
                setDetalhesFunce();
            }


        }

        private void setDetalhesFunce() {
            setPeriodoLable();
            relatorio.InnerHtml = string.Empty;
            Totalizador nTtPrd = new Totalizador();
            Totalizador nTotal = new Totalizador();
            string html = string.Empty;
            DataView dvDadosFunc = Ub3DetalhesBuss.getInstance().getDadosFunce(mat);
            DataView dvDetalhes = Ub3DetalhesBuss.getInstance().getDetalheFunce(mat, isAtivo);

            if (dvDadosFunc.Count > 0) {
                html = Utilitario.setHeaderDdFunce();

                foreach (DataRowView item in dvDadosFunc)
                    html += Utilitario.setDadosDdFunce(item);

                html += Utilitario.setFooterDdFunce();
            }

            if (dvDetalhes.Count > 0) {
                html += Utilitario.setHeaderDetFunce();

                foreach (DataRowView item in dvDetalhes) {
                    html += Utilitario.setDadosDetFunce(item, pd, pa);
                    Utilitario.setTotalizador(item, nTotal, nTtPrd, pd, pa);
                }
                html += Utilitario.setTotalizadorInTable(nTotal, nTtPrd);
                html += Utilitario.setFooterDetFunce();
            }

            relatorio.InnerHtml += html;
        }

        private void setPeriodoLable() {
            _pd.Text = pd.Substring(4, 2) + "/" + pd.Substring(0, 4);
            _pa.Text = pa.Substring(4, 2) + "/" + pa.Substring(0, 4);
        }

        private void validaPeriodo() {
            if (pd != pa) {
                var atv = Request.QueryString["atv"].ToString();
                pd = (int.Parse(pd.Substring(0, 4)) - 1).ToString() + pd.Substring(4, 2);

                Response.Redirect("/DetalhesFunce.aspx?mat=" + mat + "&pd=" + pd + "&pa=" + pa + "&atv=" + atv + "&vld=True");
            }
        }
    }
}