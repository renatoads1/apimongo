using apimongo.Data.Schemas;
using apimongo.Domain.Entities;
using apimongo.Domain.ValueObject;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using apimongo.Domain.Enums;

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

        public async Task<IEnumerable<Restaurante>> ObterTodos(){
            var restaurantes = new List<Restaurante>();
            await _restaurante.AsQueryable().ForEachAsync(_=> {
                var r = new Restaurante(_.Id.ToString(), _.Nome, _.Cozinha);
                var e = new Endereco(_.Endereco.Logradouro,
                    _.Endereco.Numero,
                    _.Endereco.Cidade,
                    _.Endereco.Uf,
                    _.Endereco.Cep);
                r.AtribuirEndereco(e);
                restaurantes.Add(r);
            });


            return restaurantes;
        }

        public Restaurante ObterPorId(string id) {

            var document = _restaurante.AsQueryable().FirstOrDefault(_ => _.Id == id);
            if (document == null)
                return null;

            return document.ConverterParaDomain();

        }

        public bool AlterarCompleto(Restaurante restaurante) {

            var documento = new RestauranteSchema
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                Cozinha = restaurante.Cozinha,
                Endereco = new EnderecoSchema { 
                    Logradouro = restaurante.Endereco.Logradouro,
                    Numero = restaurante.Endereco.Numero,
                    Cidade = restaurante.Endereco.Cidade,
                    Cep = restaurante.Endereco.Cep,
                    Uf = restaurante.Endereco.Uf
                }
            };
            var resultado = _restaurante.ReplaceOne(_ => _.Id == documento.Id, documento);
            return resultado.ModifiedCount > 0;
        }

        public bool AlterarCozinha(string id, ECozinha cozinha) {
            var atualizacao = Builders<RestauranteSchema>.Update.Set(_ => _.Cozinha, cozinha);
            var resultado = _restaurante.UpdateOne(_ => _.Id == id, atualizacao);
            return resultado.ModifiedCount > 0;
        }

    }
}
