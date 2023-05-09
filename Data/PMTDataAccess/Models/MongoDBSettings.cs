using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTDataAccess.Models
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string? Connection { get; set; }
        public string? Database { get; set; }    
    }
}
