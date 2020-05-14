using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace examen.Models{
    public class Aerolinea{
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id{get; private set;}
        
        public int Isd {get; set;}
        public string Nombre {get; set;}
        public string PaisOrigen {get; set;}
        public int Calificacion {get; set;}
    }
}
