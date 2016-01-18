using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Domain.Entities
{
    public class Ub3Analitico
    {
        public string EMP { get; set; }
        public string GRUPO { get; set; }
        public string UNIDADE { get; set; }
        public string CC { get; set; }
        public string DESC_CC { get; set; }
        public string UB3_MAT { get; set; }
        public string UB3_DEMIS { get; set; }
        public Nullable<double> UB3_ADVMES { get; set; }
        public Nullable<double> UB3_SUSMES { get; set; }
        public Nullable<double> UB3_ATMES { get; set; }
        public Nullable<double> UB3_FALMES { get; set; }
        public Nullable<double> UB3_REEMES { get; set; }
        public Nullable<double> UB3_TOTAL { get; set; }
    }
}
