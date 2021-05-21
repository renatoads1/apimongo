using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Controllers.Outputs
{
    public class RestauranteExibicao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cozinha { get; set; }
        public EnderecoExibicao Endereco { get; set; }

    }
}
