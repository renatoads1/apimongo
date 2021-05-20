using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Domain.Enums
{
    public enum ECozinha
    {
        Brazileira =1,
        Italiana =2,
        Francesa =3,
        Grega =4,
        Shinesa =5
    }

    public static class ECozinhaHelper {

        public static ECozinha ConverterDeInteiro(int valor) {
            if (Enum.TryParse(valor.ToString(), out ECozinha cozinha))
            {
                return cozinha;
            }
            else {
                throw new ArgumentOutOfRangeException("cozinha");
            }
        }

    }

}
