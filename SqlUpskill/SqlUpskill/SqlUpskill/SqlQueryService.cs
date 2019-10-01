using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SqlUpskill.Models;

namespace SqlUpskill
{
    public class SqlQueryService
    {
        private readonly AdventureWorks2017Entities _dbEntities;

        public SqlQueryService()
        {
            _dbEntities = new AdventureWorks2017Entities();
        }

        public List<string> GetFirstQueryResult()
        {
            var result = _dbEntities.Addresses.Where(x => (x.City == "Toronto" && x.AddressLine2 != null) || x.PostalCode == "M4B 1V7").Select(x => x.AddressLine1).ToList();
            return result;
        }

        public List<StateProvinceModel> GetSecondQueryResult()
        {
            //var result = _dbEntities.StateProvinces.FirstOrDefault(x => x.Name == "Cantal");

            //var result = _dbEntities.StateProvinces
            //    .Join(_dbEntities.Addresses,
            //        sp => sp.StateProvinceID,
            //        a => a.StateProvinceID,
            //        (province, address) => new { StateProvince = province, Address = address })
            //    .Where(x => x.Address.StateProvinceID == null).Select(x => new { x.StateProvince.Name, x.StateProvince.StateProvinceID }).ToList();

            //var result = _dbEntities.StateProvinces
            //    .Join(_dbEntities.Addresses,
            //        sp => sp.StateProvinceID,
            //        a => a.StateProvinceID,
            //        (province, address) => new { StateProvince = province, Address = address })
            //    .Where(x => x.Address.StateProvinceID == null).Select(x => new StateProvinceModel
            //    {
            //        StateProvinceName = x.Address.AddressLine1,
            //        StateProvinceId = x.StateProvince.StateProvinceID
            //    }).ToList();

            //var result = _dbEntities.StateProvinces
            //    .Join(_dbEntities.Addresses,
            //        sp => sp.StateProvinceID,
            //        a => a.StateProvinceID,
            //        (province, address) => new StateProvinceModel
            //        {
            //            StateProvinceName = province.Name,
            //            StateProvinceId = address.StateProvinceID,
            //            StateAddressProvince = address.StateProvinceID
            //        }).Where(x => x.StateAddressProvince != null);

            //var result1 = _dbEntities.StateProvinces
            //    .Join(_dbEntities.Addresses,
            //        sp => sp.StateProvinceID,
            //        a => a.StateProvinceID,
            //        (province, address) => new
            //        {
            //            province, address
            //        }).Where(x => x.address.StateProvinceID != null).Select(o => o.province.Name).ToList();

            //var result = _dbEntities.StateProvinces
            //    .GroupJoin(_dbEntities.Addresses, sp => sp.StateProvinceID, a => a.StateProvinceID, (sp, a) => new
            //    {
            //        StateProvince = sp,
            //        Addresses = a
            //    })
            //    .SelectMany(x => x.Addresses.DefaultIfEmpty(),
            //        (x, y) => new
            //        {
            //            StateProvinceName = x.StateProvince.Name,
            //            StateProvinceId = x.StateProvince.StateProvinceID
            //        });

            //var result1 = _dbEntities.StateProvinces
            //    .GroupJoin(_dbEntities.Addresses, sp => sp.StateProvinceID, a => a.StateProvinceID, (sp, a) => new
            //    {
            //        StateProvince = sp,
            //        Addresses = a
            //    })
            //    .SelectMany(x => x.Addresses.DefaultIfEmpty(),
            //        (x, y) => new StateProvinceModel()
            //        {
            //            StateProvinceName = x.StateProvince.Name,
            //            StateProvinceId = x.StateProvince.StateProvinceID
            //        }).ToList();

            var result = _dbEntities.StateProvinces.SelectMany(
                st => _dbEntities.Addresses.Where(a => st.StateProvinceID == a.StateProvinceID).DefaultIfEmpty().Where(x => false),
                (st, a) => new StateProvinceModel
                {
                    StateProvinceName = st.Name,
                    StateProvinceId = st.StateProvinceID
                }).ToList();

            return new List<StateProvinceModel>();
        }

        public void GetThirdResult()
        {
            var result = _dbEntities.People
                .Join(_dbEntities.BusinessEntityAddresses, p => p.BusinessEntityID, bea => bea.BusinessEntityID, (p, bea) => new { p, bea})
                .Join(_dbEntities.AddressTypes, bea => bea.bea.AddressTypeID, at => at.AddressTypeID, (bea, at) => new { bea, at })
                .Join(_dbEntities.Addresses, bea => bea.bea.bea.AddressID, a => a.AddressID, (bea, a) => new { bea, a})
                .Select(q => q.bea.bea.bea.)
        }
    }
}
