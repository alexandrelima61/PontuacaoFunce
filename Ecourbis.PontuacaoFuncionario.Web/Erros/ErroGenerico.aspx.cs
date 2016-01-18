using Ecourbis.PontuacaoFuncionario.Application;
using System;

namespace Ecourbis.PontuacaoFuncionario.Web.Erros
{
    public partial class ErroGenerico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Pegamos o nome do Usuário
            lblUsuario.Text += " " + Utilitario.GetUser();
            //Pegamos o IP
            lblIp.Text += " " + Utilitario.GetIp();

            //Pegamos o valor da variavel
            //de URl(aspxerrorpath)
            //lblPagina.Text += " " + Request.QueryString["aspxerrorpath"];
            lblPagina.Text += " " + Request.RawUrl;

            //Pegamos a mensagem de erro
            lblErro.Text = Server.GetLastError().InnerException.Message;
        }
    }
}