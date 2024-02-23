using MongoDB.Driver;
using CV.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CV.ClassLibrary.Data
{
    public class MongoDBService
    {
        private IMongoDatabase db;


        public MongoDBService(string database)
        {
	        
			var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
        }

        public async Task<Skills> AddAsync(string table, Skills skill)
        {
            var collection = db.GetCollection<Skills>(table);
            await collection.InsertOneAsync(skill);
            return skill;
        }

        public async Task<List<Skills>> GetAllAsync(string table)
        {
            var collection = db.GetCollection<Skills>(table);
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<Skills> GetByIDAsync(string table, string id)
        {
            var collection = db.GetCollection<Skills>(table);
            var skillList = await collection.AsQueryable().ToListAsync();
            var skill = skillList.FirstOrDefault(x => x.Id == id);
            return skill;
        }

        public async Task<Skills> UpdateAsync(string table, Skills updatedSkill, string id)
        {
            var collection = db.GetCollection<Skills>(table);
            updatedSkill.Id = id;
            await collection.ReplaceOneAsync(x => x.Id == id, updatedSkill, new ReplaceOptions { IsUpsert = true });
            return updatedSkill;
        }

        public async Task<string> DeleteAsync(string table, string id)
        {
            var collection = db.GetCollection<Skills>(table);
            var result = await collection.DeleteOneAsync(x => x.Id == id);
            
            if(result.DeletedCount > 0)
            {
                return "Success";
            }
            else
            {
                return "Item not found!";
            }
        }

       
    }
}
