using Ecourbis.PontuacaoFuncionario.Web.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ecourbis.PontuacaoFuncionario.Web.service.auth {
    public class LoadingUser {

        private static LoadingUser instance;

        private string JSON;
        private string JSON_FILE = "user_auth.json";
        private string ROOT_PATH = AppDomain.CurrentDomain.BaseDirectory;
        private string PATH_DIR = @"service\auth\";

        public LoadingUser() {
            LoadJson();
        }

        public static LoadingUser GetNewInstance() {

            if (instance == null) {
                instance = new LoadingUser();
            }

            return instance;
        }

        public void SetJson(string json) {
            this.JSON = json;
        }

        public string GetJson() {
            return this.JSON;
        }

        public void LoadJson() {
            string file = ROOT_PATH + PATH_DIR + JSON_FILE;

            using (StreamReader r = new StreamReader(file)) {
                SetJson(r.ReadToEnd());
            }
        }

        public UserAuth FindUserAuthByFileJson(string login) {
            UserAuth us = new UserAuth();
            var users = JsonConvert.DeserializeObject<List<UserAuth>>(GetJson());

            foreach (var user in users) {
                if (user.user.Equals(login)) {
                    us = user;
                    break;
                }
            }

            return us;
        }
    }
}