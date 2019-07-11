using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlUpskill
{
    public class SqlQueryService
    {
        private readonly AdventureWorks2017Entities _dbEntities;

        public SqlQueryService()
        {
            _dbEntities = new AdventureWorks2017Entities();
        }

        public void GetFirstQueryResult()
        {
            
        }

        public dynamic GetSecondQueryResult()
        {
            var result = _dbEntities.StateProvinces
                .Join(_dbEntities.Addresses,
                    sp => sp.StateProvinceID,
                    a => a.StateProvinceID,
                    (province, address) => new {StateProvince = province, Address = address})
                .Where(x => x.Address.StateProvinceID == null).Select(x => new { x.StateProvince.Name, x.StateProvince.StateProvinceID }).ToList();

            return result;
        }
    }
}
