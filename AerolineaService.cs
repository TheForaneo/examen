using System;
using System.Collections.Generic;
using examen.Models;
using MongoDB.Driver;
namespace Examen{
    public class AerolineaService{
        private readonly IMongoCollection<Aerolinea> _aerolinea;

        public AerolineaService(IAerolineaDataSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _aerolinea = database.GetCollection<Aerolinea>(settings.AerolineaCollectionName);
        }

        public List<Aerolinea> Get() => _aerolinea.Find<Aerolinea>(aerolinea => true).ToList();

        public Aerolinea GetId(int isd) => _aerolinea.Find<Aerolinea>(aerolinea => aerolinea.Isd==isd).FirstOrDefault();

        public Aerolinea Create(Aerolinea aero){
            _aerolinea.InsertOne(aero);
            return aero;
        } 

        public Boolean Update(int id, Aerolinea update){
            Boolean ban = false;
            var aerolinea = _aerolinea.Find<Aerolinea>(aero => aero.Isd==id).FirstOrDefault();
            if(aerolinea != null){
                try{
                    if(!(update.Isd.Equals(0))){
                        _aerolinea.FindOneAndUpdate(aero => aero.Isd==id, Builders<Aerolinea>.Update.Set("Id", update.Isd));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.Nombre.Equals(null))){
                        _aerolinea.FindOneAndUpdate(aero => aero.Isd==id, Builders<Aerolinea>.Update.Set("Nombre",update.Nombre));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.PaisOrigen.Equals(null))){
                        _aerolinea.FindOneAndUpdate(aero => aero.Isd==id, Builders<Aerolinea>.Update.Set("PaisOrigen",update.PaisOrigen));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
                try{
                    if(!(update.Calificacion.Equals(0))){
                        _aerolinea.FindOneAndUpdate(aero => aero.Isd==id, Builders<Aerolinea>.Update.Set("Calificacion",update.Calificacion));
                        ban=true;
                    }
                }
                catch(NullReferenceException ex){}
            }
            return ban;
        }
        public void Remove(Aerolinea aerolinea) => _aerolinea.DeleteOne(aero => aero.Isd == aerolinea.Isd);

        public void Remove(int id) => _aerolinea.DeleteOne(aerolinea => aerolinea.Isd == id);
    }
}
