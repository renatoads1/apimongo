using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Controllers.Inputs
{
    public class RestauranteInclusao
    {
        public string Nome { get; set; }
        public int Cozinha { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }

        public RestauranteInclusao(string nome, int cozinha, string logradouro, string numero, string cidade, string uF, string cep)
        {
            Nome = nome;
            Cozinha = cozinha;
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            UF = uF;
            Cep = cep;
        }
    }


}
