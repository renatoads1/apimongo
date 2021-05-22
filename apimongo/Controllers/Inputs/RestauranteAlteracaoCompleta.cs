using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Controllers.Inputs
{
    public class RestauranteAlteracaoCompleta
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Cozinha { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
    }
}
