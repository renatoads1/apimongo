using apimongo.Data.Schemas;
using apimongo.Domain.Entities;
using MongoDB.Driver;

namespace apimongo.Data.Repositories
{
    public class RestauranteRepository
    {
        IMongoCollection<RestauranteSchema> _restaurante;

        public RestauranteRepository(MongoDB mongoDB)
        {
            _restaurante = mongoDB.DB.GetCollection<RestauranteSchema>("Restaurante");
        }

        public void Inserir(Restaurante restaurante) {

            var document = new RestauranteSchema
            {
                Nome = restaurante.Nome,
                Cozinha = restaurante.Cozinha,

                Endereco = new EnderecoSchema
                {
                    Logradouro = restaurante.Endereco.Logradouro,
                    Numero = restaurante.Endereco.Numero,
                    Cidade = restaurante.Endereco.Cidade,
                    Cep = restaurante.Endereco.Cep,
                    Uf = restaurante.Endereco.Uf
                }
            };
            _restaurante.InsertOne(document); 
        }
    }
}
