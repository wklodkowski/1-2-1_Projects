using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Mappers.Interfaces;
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.DAL;
using WpfApp.DAL.Customers.Models;

namespace WpfApp.BLL.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly WpfAppContext _wpfAppContext;
        private readonly ICustomerMapper _customerMapper;

        public CustomerService(WpfAppContext wpfAppContext, ICustomerMapper customerMapper)
        {
            _wpfAppContext = wpfAppContext;
            _customerMapper = customerMapper;
        }

        public void CreateCustomer(CustomerModel customer)
        {
            var customerDb = _customerMapper.ToCustomer(customer);
            _wpfAppContext.Customers.Add(customerDb);
            _wpfAppContext.SaveChanges();
        }

        public async Task<List<CustomerModel>> GetCustomersAsync(CustomerModel customerModel)
        {
            var customersDb = await GetCustomersFromDataBaseAsync(customerModel);
            return customersDb.Select(customer => _customerMapper.ToCustomerModel(customer)).ToList();
        }

        private async Task<List<Customer>> GetCustomersFromDataBaseAsync(CustomerModel customerModel)
        {
            var result = new List<Customer>();
            await GetCustomerByIdAsync(result, customerModel);
            await FilterOrGetCustomersByFirstNameAsync(result, customerModel);
            await FilterOrGetCustomersByLastNameAsync(result, customerModel);
            await FilterOrGetCustomersByAddressAsync(result, customerModel);
            await FilterOrGetCustomersByTelephoneAsync(result, customerModel);

            //https://stackoverflow.com/questions/39979864/ef6-query-criteria-using-object-properties-that-arent-null
            //Użycie warunku sprawdzajacego null warotsci, spowoduje nie potrzbne nullowe zapytanie do bazy
            return result;
        }

        private async Task GetCustomerByIdAsync(List<Customer> customers, CustomerModel customerModel)
        {
            if (customerModel.CustomerId == 0)
            {
                return;
            }

            if (customers.Count > 0)
            {
                customers.RemoveAll(x => x.CustomerId != customerModel.CustomerId);
                return;
            }

            var customerDb = await _wpfAppContext.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerModel.CustomerId);
            if (customerDb == null)
            {
                return;
            }

            customers.Add(customerDb);
        }

        private async Task FilterOrGetCustomersByFirstNameAsync(List<Customer> customers, CustomerModel customerModel)
        {
            if (string.IsNullOrEmpty(customerModel.FirstName))
            {
                return;
            }

            if (customers.Count > 0)
            {
                customers.RemoveAll(x => x.FirstName != customerModel.FirstName);
                return;
            }

            var customersDb = await _wpfAppContext.Customers.Where(x => x.FirstName == customerModel.FirstName).ToListAsync();
            customers.AddRange(customersDb);
        }

        private async Task FilterOrGetCustomersByLastNameAsync(List<Customer> customers, CustomerModel customerModel)
        {
            if (string.IsNullOrEmpty(customerModel.LastName))
            {
                return;
            }

            if (customers.Count > 0)
            {
                customers.RemoveAll(x => x.LastName != customerModel.LastName);
                return;
            }

            var customersDb = await _wpfAppContext.Customers.Where(x => x.LastName == customerModel.LastName).ToListAsync();
            customers.AddRange(customersDb);
        }

        private async Task FilterOrGetCustomersByAddressAsync(List<Customer> customers, CustomerModel customerModel)
        {
            if (string.IsNullOrEmpty(customerModel.Address))
            {
                return;
            }

            if (customers.Count > 0)
            {
                customers.RemoveAll(x => !x.Address.Contains(customerModel.Address));
                return;
            }

            var customersDb = await _wpfAppContext.Customers.Where(x => x.Address.Contains(customerModel.Address)).ToListAsync();
            customers.AddRange(customersDb);
        }

        private async Task FilterOrGetCustomersByTelephoneAsync(List<Customer> customers, CustomerModel customerModel)
        {
            if (string.IsNullOrEmpty(customerModel.Telephone))
            {
                return;
            }

            if (customers.Count > 0)
            {
                customers.RemoveAll(x => x.Telephone != customerModel.Telephone);
                return;
            }

            var customersDb = await _wpfAppContext.Customers.Where(x => x.Telephone == customerModel.Telephone).ToListAsync();
            customers.AddRange(customersDb);
        }

        //public List<CustomerModel> GetCustomers(CustomerModel customerModel)
        //{
        //    var customersDb = GetCustomersFromDataBase(customerModel);
        //    return customersDb.Select(customer => _customerMapper.ToCustomerModel(customer)).ToList();
        //}

        //private List<Customer> GetCustomersFromDataBase(CustomerModel customerModel)
        //{
        //    var result = new List<Customer>();
        //    GetCustomerById(result, customerModel);
        //    FilterOrGetCustomersByFirstName(result, customerModel);
        //    FilterOrGetCustomersByLastName(result, customerModel);
        //    FilterOrGetCustomersByAddress(result, customerModel);
        //    FilterOrGetCustomersByTelephone(result, customerModel);

        //    //https://stackoverflow.com/questions/39979864/ef6-query-criteria-using-object-properties-that-arent-null
        //    //Użycie warunku sprawdzajacego null warotsci, spowoduje nie potrzbne nullowe zapytanie do bazy
        //    return result;
        //}

        //private void GetCustomerById(List<Customer> customers, CustomerModel customerModel)
        //{
        //    if (customerModel.CustomerId == 0)
        //    {
        //        return;
        //    }

        //    if (customers.Count > 0)
        //    {
        //        customers.RemoveAll(x => x.CustomerId != customerModel.CustomerId);
        //        return;
        //    }

        //    var customerDb = _wpfAppContext.Customers.SingleOrDefault(x => x.CustomerId == customerModel.CustomerId);
        //    if (customerDb == null)
        //    {
        //        return;
        //    }

        //    customers.Add(customerDb);
        //}

        //private void FilterOrGetCustomersByFirstName(List<Customer> customers, CustomerModel customerModel)
        //{
        //    if (string.IsNullOrEmpty(customerModel.FirstName))
        //    {
        //        return;
        //    }

        //    if (customers.Count > 0)
        //    {
        //        customers.RemoveAll(x => x.FirstName != customerModel.FirstName);
        //        return;
        //    }

        //    var customersDb = _wpfAppContext.Customers.Where(x => x.FirstName == customerModel.FirstName);
        //    customers.AddRange(customersDb);
        //}

        //private void FilterOrGetCustomersByLastName(List<Customer> customers, CustomerModel customerModel)
        //{
        //    if (string.IsNullOrEmpty(customerModel.LastName))
        //    {
        //        return;
        //    }

        //    if (customers.Count > 0)
        //    {
        //        customers.RemoveAll(x => x.LastName != customerModel.LastName);
        //        return;
        //    }

        //    var customersDb = _wpfAppContext.Customers.Where(x => x.LastName == customerModel.LastName);
        //    customers.AddRange(customersDb);
        //}

        //private void FilterOrGetCustomersByAddress(List<Customer> customers, CustomerModel customerModel)
        //{
        //    if (string.IsNullOrEmpty(customerModel.Address))
        //    {
        //        return;
        //    }

        //    if (customers.Count > 0)
        //    {
        //        customers.RemoveAll(x => !x.Address.Contains(customerModel.Address));
        //        return;
        //    }

        //    var customersDb = _wpfAppContext.Customers.Where(x => x.Address.Contains(customerModel.Address));
        //    customers.AddRange(customersDb);
        //}

        //private void FilterOrGetCustomersByTelephone(List<Customer> customers, CustomerModel customerModel)
        //{
        //    if (string.IsNullOrEmpty(customerModel.Telephone))
        //    {
        //        return;
        //    }

        //    if (customers.Count > 0)
        //    {
        //        customers.RemoveAll(x => x.Telephone != customerModel.Telephone);
        //        return;
        //    }

        //    var customersDb = _wpfAppContext.Customers.Where(x => x.Telephone == customerModel.Telephone);
        //    customers.AddRange(customersDb);
        //}
    }
}
