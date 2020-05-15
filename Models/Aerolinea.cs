using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace examen.Models{
    public class Aerolinea{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id{get; set;}
        public int IDAerolinea {get; set;}
        public string Nombre {get; set;}
        public string PaisOrigen {get; set;}
        public int Calificacion {get; set;}
    }
}
