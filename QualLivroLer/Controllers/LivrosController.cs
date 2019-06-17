using MongoDB.Bson;
using QualLivroLer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QualLivroLer.Controllers.API
{
    [EnableCors(origins: "http://localhost:65208/api/livros", headers: "*", methods: "*")]
    public class LivrosController : ApiController
    {
        private Data _data;
        public LivrosController()
        {
            _data = new Data();
        }
        public async Task<IEnumerable<Livros>> Get()
        {
            return await _data.GetLivrosAsync();
        }

        public Livros Get(string _id)
        {
            var livros = _data.GetLivros(new ObjectId(_id));
            return livros;
        }

        public Livros Post([FromBody]Livros livro)
         {
             _data.Create(livro);
             return livro;
         }

        public void Put(string _id, Livros livro)
         {
            _ = _data.AtualizaLivro(_id, livro);
         }

        public void Delete(ObjectId id)
         {
            _ = _data.Remove(id);
         }

    }

}
