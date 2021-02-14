using SBS.Common.CommonModels;
using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interface
{
    public interface IAuthenticationRepository
    {
        LoginResult Login(Customer login);
        bool Register(Customer register, Vehicle vehicle);
    }
}
