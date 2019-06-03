using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace QualLivroLer.Models
{
    public class Data
    {
        string conexao = "mongodb://localhost:27017";

        private MongoClient _cliente;
        private IMongoDatabase _banco;
        private IMongoCollection<Livros> _collection;

        public Data()
        {
            _cliente = new MongoClient(conexao);
            _banco = _cliente.GetDatabase("bd_biblioteca");
            _collection = _banco.GetCollection<Livros>("livros");
        }

        public async Task<List<Livros>> GetLivrosAsync()
        {
            var lista = await _collection.Find(new BsonDocument()).ToListAsync();
            return lista;

        }

        public Livros GetLivros(ObjectId _id)
        {
            var filter = Builders<Livros>.Filter.Eq("_id", _id);
            var livroUnico = _collection.Find(filter).FirstOrDefault();
            return livroUnico;
        }

        public Livros Create(Livros Livros)
        {
            var adiciona = _collection.InsertOneAsync(Livros);
            return Livros;
        }

        public async Task<ReplaceOneResult> AtualizaLivro(string _id, Livros livro)
         {
             var codigo = new ObjectId(_id);
             return await _collection.ReplaceOneAsync
                (a => a._id == codigo, livro, new UpdateOptions { IsUpsert = true });
         }
         public async Task<DeleteResult> Remove(ObjectId id)
         {
             var query = Builders<Livros>.Filter.Eq(f => f._id, id);
             return await _collection.DeleteOneAsync(query);
        }

    }

}