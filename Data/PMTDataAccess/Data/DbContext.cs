using PMTDataAccess.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace PMTDataAccess.Data
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database = null;
        public DbContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.Connection);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
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
