using Manager.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Manager.API.Data
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database = null;
        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDatabaseSettings:Connection"));
            if (client != null)
                _database = client.GetDatabase(configuration.GetValue<string>("MongoDatabaseSettings:DatabaseName"));
            DataSeed.SeedData(_database.GetCollection<ProjectMember>("ProjectMembers"));
        }

        public IMongoCollection<ProjectMember> GetProjectMembersCollection<ProjectMember>()
        {
            return _database.GetCollection<ProjectMember>("ProjectMembers");
        }

        public IMongoCollection<TaskMember> GetTaskMembersCollection<TaskMember>()
        {
            return _database.GetCollection<TaskMember>("TaskMembers");
        }
        public IMongoCollection<ProjectTaskMember> GetProjectTaskCollection<ProjectTaskMember>()
        {
            return _database.GetCollection<ProjectTaskMember>("ProjectTaskMembers");
        }
        public void DropCollection()
        {
            _database.DropCollection("ProjectMembers");
            _database.DropCollection("TaskMembers");
            _database.DropCollection("ProjectTaskMembers");
            _database.DropCollection("Users");
        }
    }
}
