using HotelManagementDBA.Repository.Interface;
using HotelManagementInterface.Interface;
using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementInterface
{
    public class LoginManager : ILogin
    {
        private readonly ILoginRepository loginRepository;

        public LoginManager(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }

        public int Create(Login login)
        {
            return loginRepository.Create(login);
        }

        public int Delete(string email)
        {
            return loginRepository.Delete(email);
        }

        public int Login(string email,string password)
        {
            return loginRepository.Login(email, password);
        }

        public int Update(Login login)
        {
            return loginRepository.Update(login);
        }
    }
}
