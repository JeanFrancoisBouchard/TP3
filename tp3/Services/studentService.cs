using System.Collections.Generic;
using System.Linq;
using tp3.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace tp3.Services
{
    public class studentService
    {
        private readonly IMongoCollection<etudiants> _etudiants;

        public studentService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("tp3"));
            var db = client.GetDatabase("tp3");
            _etudiants = db.GetCollection<etudiants>("etudiants");
        }

        public List<etudiants> Get()
        {
            return _etudiants.Find(etudiants => true).ToList();
        }

        public etudiants Get(string id)
        {
            return _etudiants.Find<etudiants>(etudiants => etudiants.da == id).FirstOrDefault();
        }

        public etudiants Create(etudiants etudiant)
        {
            _etudiants.InsertOne(etudiant);
            return etudiant;
        }

        public void Update(string id, etudiants etudiant)
        {
            _etudiants.ReplaceOne(etudiants => etudiants.Id == id, etudiant);
        }

        public void Remove(etudiants etudiant)
        {
            _etudiants.DeleteOne(etudiants => etudiants.Id == etudiant.Id);
        }

        public void Remove(string id)
        {
            _etudiants.DeleteOne(etudiants => etudiants.Id == id);
        }

    }
}