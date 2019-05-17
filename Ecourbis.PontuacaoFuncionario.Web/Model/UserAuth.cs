/// <summary>
/// 
/// </summary>
namespace Ecourbis.PontuacaoFuncionario.Web.Model {
    public class UserAuth {
        public string user { get; set; }
        public string nome { get; set; }
        public Auth auths { get; set; }

        public UserAuth() {
            auths = new Auth();
        }
    }

    public class Auth {
        public string auth { get; set; }
        public string status { get; set; }

        public Auth() {
            this.auth = string.Empty;
            this.status = string.Empty;
        }
    }
}