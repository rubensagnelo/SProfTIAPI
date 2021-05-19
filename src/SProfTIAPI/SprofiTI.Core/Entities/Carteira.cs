using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SProfTIAPI.Entities
{ 
    public partial class Carteira
    { 
        [BsonId]
        public ObjectId _id  { get; set; }
        public int? Idcarteira { get; set; }
        public string Titulo { get; set; }
        public string Descrcricao { get; set; }
        public DateTime? Dataatualizao { get; set; }
    }
}
