using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.DataAccess
{
    internal interface ISqlDataAccessInterface
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "conn");
        Task<bool> SaveData<T>(string spName);
    }
}
