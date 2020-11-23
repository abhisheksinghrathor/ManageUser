using System.Collections.Generic;
//using Users.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using System;

namespace ManageUser.Services
{
    public class ManageUserServices : IManageUserServices
    {     
        private IList<Users> _students;
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        public ManageUserServices()
        {
          mongoClient = new MongoClient("mongodb+srv://abhi:abhi@cluster0.tpryx.gcp.mongodb.net/test");
          mongoDatabase = mongoClient.GetDatabase("ManageUser");
        }
       
        public bool AddUsers(Users student)
        {

            if(student != null)
            {
                 AddUserstoDb(student);
                return true;
            }

            return false;
        }

         public async void AddUserstoDb(Users student)
        {
            try{
                 var collection = mongoDatabase.GetCollection<Users>("ManageUser");
                await collection.InsertOneAsync(student);
            }
            catch(Exception e){
                Console.WriteLine(e);
            }
        }

        public bool DeleteUsers(int id)
        {
            DeleteUserstoDb(id);    
            return true;
        }
         public async void DeleteUserstoDb(int id)
        {

            try{
                 var collection = mongoDatabase.GetCollection<Users>("ManageUser");
                await collection.DeleteOneAsync(a => a.id ==id);
            }
            catch(Exception  e){
                Console.WriteLine(e);
            }

        }

         public bool UpdateUsers(Users student)
        {
            UpdateUserstoDb(student);    
            return true;

        }

         public async void UpdateUserstoDb(Users student)
        {

            var options = new FindOneAndReplaceOptions<Users>
            {
                ReturnDocument = ReturnDocument.After
            };
            try{
                 var collection = mongoDatabase.GetCollection<Users>("ManageUser");
                await collection.FindOneAndReplaceAsync<Users>(u => u.id == student.id, student,options);
            }
            catch(Exception  e){
                Console.WriteLine(e);
            }

        }
         public async Task<IEnumerable<Users>> GetAllUsers()
        {             
            IEnumerable<Users> result = null;
    
                result = await mongoDatabase.GetCollection<Users>("ManageUser")
                                      .Find(_ => true)                                 
                                      .ToListAsync();
                    
            return result;
            
        }
    }
}