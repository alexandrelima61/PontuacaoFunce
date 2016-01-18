using Ecourbis.PontuacaoFuncionario.Application;
using System;

namespace Ecourbis.PontuacaoFuncionario.Web.Erros
{
    public partial class Erro404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Subiu para memória pegamos algumas
            //Informações para o Suporte

            //Pegamos o nome do Usuário
            lblUsuario.Text += " " + Utilitario.GetUser();
            //Pegamos o IP
            lblIp.Text += " " + Utilitario.GetIp();

            //Pegamos o valor da variavel
            lblPagina.Text += " " + Request.RawUrl;
        }
    }
}