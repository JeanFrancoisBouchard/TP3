using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace tp3.Models
{
    public class etudiants
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nom")]
        public string name { get; set; }

        [BsonElement("age")]
        public int age { get; set; }

        [BsonElement("da")]
        public string da { get; set; }

        [BsonElement("session")]
        public string session { get; set; }

        [BsonElement("coteR")]
        public string coteR { get; set; }
    }

}