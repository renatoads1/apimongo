using apimongo.Data.Schemas;
using apimongo.Domain.Entities;
using apimongo.Domain.Enums;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;

namespace apimongo.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("não foi possivel se conectar ao mongo",ex);
            }
        }

        private void MapClasses() {
            if (!BsonClassMap.IsClassMapRegistered(typeof(RestauranteSchema)))
            {
                BsonClassMap.RegisterClassMap<RestauranteSchema>(i => {
                    i.AutoMap();
                    i.MapIdMember(_ => _.Id);
                    i.MapMember(_ => _.Cozinha).SetSerializer(new EnumSerializer<ECozinha>(BsonType.Int32));
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
