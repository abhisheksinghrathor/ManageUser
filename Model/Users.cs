using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public int id { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string website { get; set; }  

        public UsersAddress address { get; set; }
        
        public Company company { get; set; }
        
    }

    public class UsersAddress
    {
        public string street { get; set; }

        public string suite { get; set; }

        public string city { get; set; }

        public string zipcode { get; set; }
        
        public GeoLocation geo { get; set; }
   
    }

    public class GeoLocation
    {
        public string lat { get; set; }

        public string lng { get; set; }        
    }

    public class Company
    {
        public string name { get; set; }

        public string catchPhrase { get; set; }  

        public string bs { get; set; }        
    }