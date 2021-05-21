using apimongo.Domain.Entities;
using apimongo.Domain.Enums;
using apimongo.Domain.ValueObject;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Data.Schemas
{
    public class RestauranteSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public ECozinha Cozinha { get; set; }
        public EnderecoSchema Endereco { get; set; }
    
    }

    public static class RestauranteSchemaExtensao {
        public static Restaurante ConverterParaDomain(this RestauranteSchema document)
        {
            var restaurante = new Restaurante(document.Id.ToString(), document.Nome, document.Cozinha);
            var endereco = new Endereco(document.Endereco.Logradouro,
                document.Endereco.Numero,
                document.Endereco.Cidade,
                document.Endereco.Uf,
                document.Endereco.Cep);
            restaurante.AtribuirEndereco(endereco);
            return restaurante;
        }
    }
    


}
