using PMTDataAccess.Models;
using MongoDB.Driver;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace PMTDataAccess.Data
{
    public class DataSeed
    {
        public static void SeedData(IMongoCollection<ProjectMember> memberCollection)
        {
            bool memberExists = memberCollection.Find(m => true).Any();
            if (!memberExists)
            {
                memberCollection.InsertManyAsync(GetPreconfiguredMembers());
            }
        }

        private static IEnumerable<ProjectMember> GetPreconfiguredMembers()
        {
            return new List<ProjectMember>()
            {
                new ProjectMember
                {
                    MemberId = "595959",
                    Name = "Swaroop Singh",
                    Experience = 11,
                    Skills = new List<string>
                    {
                      "Electrical Engineer",
                      "Communications Engineer",
                      "Awesome Programming Skills",
                      "Leader"
                    },
                    Description = "Currently working at Qualcomm",
                    StartDate = DateTime.Parse("2011-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    EndDate = DateTime.Parse("2042-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    AllocationPercentage = 50
                },
                new ProjectMember
                {
                    MemberId = "399584",
                    Name = "Balaji Singh",
                    Experience = 9,
                    Skills = new List<string>
                    {
                      "Communications Engineer",
                      "FSE"
                    },
                    Description = "Currently working at Cognizant",
                    StartDate = DateTime.Parse("2011-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    EndDate = DateTime.Parse("2049-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    AllocationPercentage = 30
                }
            };
        }
    }
}
