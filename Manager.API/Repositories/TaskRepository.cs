using Manager.API.Data;
using Manager.API.Models;
using Manager.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace Manager.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskMember> _TaskMemberCollection;
        public TaskRepository(IDbContext dbContext)
        {
            _TaskMemberCollection = dbContext.GetTaskMembersCollection<TaskMember>();
        }

        public TaskMember AddTaskMember(TaskMember taskMember)
        {
            _TaskMemberCollection.InsertOne(taskMember);
            return taskMember;
        }

        public TaskMember GetTaskMember(string id)
        {
            return _TaskMemberCollection.Find(tm => tm.MemberId == id).FirstOrDefault();
        }
    }
}
