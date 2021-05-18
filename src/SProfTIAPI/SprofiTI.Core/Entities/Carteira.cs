using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SProfTIAPI.Entities
{ 
    public partial class Carteira
    { 
        public int? Idcarteira { get; set; }
        public string Titulo { get; set; }
        public string Descrcricao { get; set; }
        public DateTime? Dataatualizaco { get; set; }
    }
}
