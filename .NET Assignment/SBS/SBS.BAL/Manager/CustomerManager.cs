using AutoMapper;
using SBS.BAL.Interface;
using SBS.DAL.Database;
using SBS.DAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _CustomerRepository;
        public IMapper mapper;
        public MapperConfiguration config;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, RegisterViewModel>();
                cfg.CreateMap<RegisterViewModel, Customer>();
            });
            mapper = config.CreateMapper();
        }

        public bool CreateCustomer(RegisterViewModel customer)
        {
            DAL.Database.Customer customerfrodb = mapper.Map<RegisterViewModel, Customer>(customer);
            return _CustomerRepository.CreateCustomer(customerfrodb);
        }

        public bool DeleteCustomer(int id)
        {
            return _CustomerRepository.DeleteCustomer(id);
        }

        public bool EditCustomer(RegisterViewModel customer)
        {
            DAL.Database.Customer customerfrodb = mapper.Map<RegisterViewModel, Customer>(customer);
            return _CustomerRepository.EditCustomer(customerfrodb);
        }

        public RegisterViewModel GetCustomer(int id)
        {
            Customer customersfromdb = _CustomerRepository.GetCustomer(id);
            RegisterViewModel customer = mapper.Map<Customer,RegisterViewModel>(customersfromdb);
            return customer;
        }

        public List<RegisterViewModel> GetCustomers()
        {
            List<Customer> customersfromdb = _CustomerRepository.GetCustomers();
            List<RegisterViewModel> customers = mapper.Map<List<Customer>, List<RegisterViewModel>>(customersfromdb);
            return customers;
        }
    }
}
