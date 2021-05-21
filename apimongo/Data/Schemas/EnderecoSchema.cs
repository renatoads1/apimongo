using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Data.Schemas
{
    public class EnderecoSchema
    {
        public string Logradouro { get;  set; }
        public string Numero { get;  set; }
        public string Cidade { get;  set; }
        public string Uf { get;  set; }
        public string Cep { get;  set; }

    }
}
