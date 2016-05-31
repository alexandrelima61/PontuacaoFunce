using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Domain.Entities
{
    public class Ub3Sintetico
    {
        public string EMP { get; set; }
        public string GRUPO { get; set; }
        public string DESCRIC { get; set; }
        public Nullable<double> UB3_ADVMES { get; set; }
        public Nullable<double> UB3_SUSMES { get; set; }
        public Nullable<double> UB3_ATMES { get; set; }
        public Nullable<double> UB3_FALMES { get; set; }
        public Nullable<double> UB3_REEMES { get; set; }
        public Nullable<double> UB3_MULTAS { get; set; }
        public Nullable<double> UB3_ACID { get; set; }
        public Nullable<double> UB3_TOTAL { get; set; }
    }
}
