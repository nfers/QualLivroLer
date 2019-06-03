using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualLivroLer.Models
{
    public class Livros
    {
        public ObjectId _id { get; set; }

        //[BsonElement("titulo")]
        public string titulo { get; set; }      

        //[BsonElement("autor")]
        public string autor { get; set; }
       
        //[BsonElement("genero")]
        public string genero { get; set; }
        
        //[BsonElement("DataCriacao")]
        public DateTime dtCriacao { get; set; }
        
        public Int32 __v { get; set; }
    }
}