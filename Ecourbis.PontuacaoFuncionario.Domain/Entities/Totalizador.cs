using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecourbis.PontuacaoFuncionario.Domain.Entities
{
    public class Totalizador
    {
        public int nttAdvert { get; set; }
        public int nttSusp { get; set; }
        public int nttAtest { get; set; }
        public int nttFalta { get; set; }
        public int nttReem { get; set; }
        public int nttMultas { get; set; }
        public int nttAcidente { get; set; }
        public int nttTotal { get; set; }
    }
}
