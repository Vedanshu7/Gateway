using ProductInterface.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ProductDBA.Repository;
using ProductModels.Models;
using ProductModel.Models;

namespace ProductInterface
{
   public class LoginManager : ILoginManager
    {
        private readonly ILoginRepository loginRepository;

        public LoginManager(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }
        public Login GetUser(string email)
        {
            return loginRepository.GetUser(email);
        }

        public int Register(Register r)
        {
            return loginRepository.Register(r);
        }
    }
}
