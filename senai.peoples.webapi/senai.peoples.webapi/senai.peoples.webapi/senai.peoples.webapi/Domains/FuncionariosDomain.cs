using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.webapi.Domains
{
    public class FuncionariosDomain
    {
        public int IdFuncionario { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set;}

        public DateTime DtNascimento { get; set; }
    }
}
