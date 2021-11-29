using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Interfaces
{
    public interface IConnectionSqlService
    {
        public Task<string> GetJsonFromSql(string quuery);
        public Task<int> CrudDataToSql(string quuery);

    }
}
