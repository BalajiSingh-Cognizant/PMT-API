using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTDataAccess.Models
{
    public interface IMongoDBSettings
    {
        string Connection { get; set; }
        string Database { get; set; }
    }
}
