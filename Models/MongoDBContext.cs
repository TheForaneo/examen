using examen.Models;
using MongoDB.Driver;

namespace Examen.Models{
    public class MongoDBContext{
        private readonly IMongoDatabase _mongoDb;
        public MongoDBContext(){
            var client = new MongoClient("mongodb+srv://Cluster0:amillano123@cluster0-pmvyp.mongodb.net/AerolineaDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("AerolineaDB");
            _mongoDb = database;
        }

        public IMongoCollection<Aerolinea> Aerolinea{
            get  
            {  
                return _mongoDb.GetCollection<Aerolinea>("Aerolinea");  
            }  
        }
    }
}