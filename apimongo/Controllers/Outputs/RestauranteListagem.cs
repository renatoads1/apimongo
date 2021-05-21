using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Controllers.Outputs
{
    public class RestauranteListagem
    {
        public string  Id { get; set; }
        public string  Nome { get; set; }
        public int Cozinha { get; set; }
        public string Cidade { get; set; }


    }
}
