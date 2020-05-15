using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using examen.Models;
using Examen.Models;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Examen{
    public class AerolineaService{
        private readonly IMongoCollection<Aerolinea> _aerolinea;
        MongoDBContext db = new MongoDBContext(); 

        public AerolineaService(IAerolineaDataSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _aerolinea = database.GetCollection<Aerolinea>(settings.AerolineaCollectionName);
        }

        public List<Aerolinea> Get() {
            var lista = db.Aerolinea.Find(_ => true).ToList();
            if(lista != null){
                return lista;
            }
            return null; 
        }
        //_aerolinea.Find<Aerolinea>(aerolinea => true).ToList();

        public Aerolinea GetId(int id){
            var user = db.Aerolinea.Find(aerolinea => aerolinea.IDAerolinea==id).FirstOrDefault();
            return user;
        } 
        //_aerolinea.Find<Aerolinea>(aerolinea => aerolinea.IDAerolinea == id).FirstOrDefault();

        public Aerolinea Create(Aerolinea aero){
            
                    db.Aerolinea.InsertOne(aero);
                    return aero;
            /*
            _aerolinea.InsertOne(aero);
            return aero;
            */
        } 

        public Boolean Update(int id, Aerolinea update){
            Boolean ban = false;
            var aerolinea = db.Aerolinea.Find<Aerolinea>(aero => aero.IDAerolinea == id).FirstOrDefault();
            //_aerolinea.Find<Aerolinea>(aero => aero.IDAerolinea== id).FirstOrDefault();
            if(aerolinea != null){
                try{
                    if(!(update.IDAerolinea.Equals(0))){
                        db.Aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea == id, Builders<Aerolinea>.Update.Set("Id",update.IDAerolinea));
                        //_aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea.Equals(id), Builders<Aerolinea>.Update.Set("Id", update.IDAerolinea));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.Nombre.Equals(null))){
                        db.Aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea == id, Builders<Aerolinea>.Update.Set("Nombre", update.Nombre));
                        //_aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea.Equals(id), Builders<Aerolinea>.Update.Set("Nombre",update.Nombre));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.PaisOrigen.Equals(null))){
                        db.Aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea == id, Builders<Aerolinea>.Update.Set("PaisOrigen", update.PaisOrigen));
                        //_aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea.Equals(id), Builders<Aerolinea>.Update.Set("PaisOrigen",update.PaisOrigen));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.Calificacion.Equals(0))){
                        db.Aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea == id, Builders<Aerolinea>.Update.Set("Calificacion", update.Calificacion));
                        //_aerolinea.FindOneAndUpdate(aero => aero.IDAerolinea.Equals(id), Builders<Aerolinea>.Update.Set("Calificacion",update.Calificacion));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
            }
            return ban;
        }
        public void Remove(Aerolinea aerolinea) => db.Aerolinea.DeleteOne(aero => aero.IDAerolinea == aerolinea.IDAerolinea);
        //_aerolinea.DeleteOne(aero => aero.IDAerolinea.Equals(aerolinea.IDAerolinea));

        public void Remove(int id) => db.Aerolinea.DeleteOne(aero => aero.IDAerolinea == id);
        //_aerolinea.DeleteOne(aerolinea => aerolinea.IDAerolinea==id);
    }
}
